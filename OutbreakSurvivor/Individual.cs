using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OutbreakSurvivor {
	public class Individual {
        private const int CHILDREN_TO_CREATE = 2;
		private const int MATURE_AGE = 3;

		public const int MIN_REPRODUCABILITY = 10;
		public const int MAX_REPRODUCABILITY = 100;
		public const int MIN_RESISTANCE = 0;
		public const int MAX_RESISTANCE = 100;
        public const int INITIAL_ENERGY = 20;

        private float mutationChance;

		public int Energy { get; set; }
		public int Reproducability { get; set; }
		public Point Position { get; set; }
		public Dictionary<Disease, int> Resistances { get; set; }
		public Dictionary<Disease, int> Immunities { get; set; }
		public List<Disease> Diseases { get; set; }
		public int Age { get; set; }
		public bool Mature { get { return Age >= MATURE_AGE; } }

		public Individual() {
            Energy = INITIAL_ENERGY;
			Resistances = new Dictionary<Disease, int>();
			Immunities = new Dictionary<Disease, int>();
			Diseases = new List<Disease>();
            mutationChance = 100.0f / (Simulator.DISEASES.Count + 1);
			Age = 0;
		}

		public List<Individual> Reproduce(Individual other) {
            // Preparation
            Random randomGenerator = new Random();
            int reproductionWheel = this.Reproducability + other.Reproducability;
            List<Individual> children = new List<Individual>();
            for (int i = 0; i < CHILDREN_TO_CREATE; i++) { children.Add(new Individual()); }

            // Create children
            foreach (Individual child in children) {
                // Determine disease resistances
                foreach (Disease disease in Simulator.DISEASES) {
                    // Mutate or inherit?
                    bool inherit = randomGenerator.Next(100) > mutationChance;
                    int finalResistance;
                    if (inherit) {
                        int ancestorDeterminant = randomGenerator.Next(reproductionWheel);
                        Individual ancestor = (ancestorDeterminant <= this.Reproducability) ? this : other;
                        if (!ancestor.Resistances.TryGetValue(disease, out finalResistance)) {
                            System.Console.Error.WriteLine("Fatal error: Ancestor has missing resistance while creating child.");
                            return null;
                        }
                    } else {
                        finalResistance = randomGenerator.Next(MIN_RESISTANCE, MAX_RESISTANCE);
                    }
                    child.Resistances.Add(disease, finalResistance);
                }

                // Determine reproducability
                bool mutate = randomGenerator.Next(100) <= mutationChance;
                if (!mutate) {
                    int parentDeterminant = randomGenerator.Next(reproductionWheel);
                    child.Reproducability = (parentDeterminant <= this.Reproducability) ? this.Reproducability : other.Reproducability;
                } else {
                    child.Reproducability = randomGenerator.Next(MIN_REPRODUCABILITY, MAX_REPRODUCABILITY);
                }

                // Determine inherited diseases
                foreach (Disease disease in this.Diseases) {
                    disease.Infect(child);
                }
                foreach (Disease disease in other.Diseases) {
                    disease.Infect(child);
                }
            }

            // Set position to ancestor positions
            children[0].Position = this.Position;
            children[1].Position = other.Position;

			return children;
		}
	}
}
