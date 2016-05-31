using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OutbreakSurvivor {
	public class Simulator {
		public int Turn { get; private set; }
		public Size GridSize { get; private set; }
		public List<Individual> Population { get; private set; }
	    private List<Point> occupiedPositions = new List<Point>();
	    public const int IMMUNITY_DURATION = 5;
	    public const int OUTBREAK_INTERVAL = 5;
		public static readonly List<Disease> DISEASES = new List<Disease> {new Anthrax(), new Tuberculosis(), new Veganitis(), new Cholera(), new Rubeola(), new Diphtheria()};
        public Disease RecentDisease { get; private set; }
	    private readonly Random random = new Random();
		public Statistics Statistics = new Statistics();
		private int initialPopulation;
		public int PopulationSize {
			get { return Population.Count; }
		}

		public Simulator(int populationSize, Size gridSize) {
			Turn = 1;
			GridSize = gridSize;
			initialPopulation = populationSize;
			GenerateInitialPopulation(populationSize);
			UpdateStatistics();
		}

		private void GenerateInitialPopulation(int populationSize) {
		    Population = new List<Individual>();
			while(PopulationSize < populationSize) {
				var resistances = new Dictionary<Disease, int>();
				foreach(var disease in DISEASES) {
					resistances.Add(disease, random.Next(Individual.MIN_RESISTANCE, Individual.MAX_RESISTANCE + 1));
				}
				var reproducability = random.Next(Individual.MIN_REPRODUCABILITY, Individual.MAX_REPRODUCABILITY + 1);
				AddToPopulation(new Individual() {Position = GetFreePosition(), Resistances = resistances, Reproducability = reproducability});
			}
		}

	    private Point GetFreePosition() {
	        var positionCount = GridSize.Width*GridSize.Height;
	        if (occupiedPositions.Count >= positionCount || positionCount == PopulationSize)
	            return new Point(-1, -1);
	        while (true) {
	            var x = random.Next(0, GridSize.Width);
	            var y = random.Next(0, GridSize.Height);
	            var point = new Point(x, y);
                if(!Occupied(point))
                    return point;
	        }
	    }

	    public bool AddToPopulation(Individual individual) {
            if(Occupied(individual.Position))
                return false;
	        occupiedPositions.Add(individual.Position);
	        Population.Add(individual);
            return true;
	    }

	    public bool RemoveFromPopulation(Individual individual) {
            if(!Population.Contains(individual))
                return false;
	        occupiedPositions.Remove(individual.Position);
	        Population.Remove(individual);
            return true;
	    }

	    private bool Occupied(Point position) {
	        return occupiedPositions.Contains(position);
	    }

	    private void MoveIndividual(Individual individual) {
            var validpositions = ValidPositions(individual.Position);
            if(validpositions.Count == 0)
                return;
            occupiedPositions.Remove(individual.Position);
            individual.Position = validpositions[random.Next(0, validpositions.Count)];
            occupiedPositions.Add(individual.Position);
	    }

		private bool ReduceEnergy(Individual individual) {
			individual.Energy--;
			return individual.Energy > 0;
		}

		private void RemoveAll(Func<Individual, bool> predicate) {
			var tmp = new List<Individual>(Population);
			foreach (var individual in tmp.Where(predicate)) {
				RemoveFromPopulation(individual);
			}
		}

		private void InvokeDiseaseEffects(Individual individual) {
			foreach (var disease in individual.Diseases) {
				disease.ApplyEffect(individual);
			}
		}

	    public void NextTurn() {
            Turn++;
            RecentDisease = PickRandomDisease();
	    	foreach (var individual in Population) {
	    		InvokeDiseaseEffects(individual);
			}
			RemoveAll(i => !ReduceEnergy(i));
		    foreach (var individual in Population) {
		        MoveIndividual(individual);
		        DecrementImmunity(individual);
				SpreadDisease(individual);
		        if (Outbreak()) 
		            RecentDisease.Infect(individual);
			    individual.Age++;
		    }

			UpdateStatistics();
	    }

	    public bool Outbreak() {
            return (Turn) % OUTBREAK_INTERVAL == 0;
	    }

	    private void SpreadDisease(Individual individual) {
	        foreach (var disease in individual.Diseases) {
	            foreach (var target in IndividualsInRange(individual.Position, disease.Radius)) {
	                disease.Infect(target);
	            }
	        }
	    }

	    private List<Individual> IndividualsInRange(Point of, int radius) {
            var individuals = new List<Individual>();
	        foreach (var position in PositionsInRange(of, radius)) {
                if(Occupied(position))
	                individuals.Add(GetIndividual(position));
	        }
            return individuals;
	    }

	    private List<Point> PositionsInRange(Point of, int radius) {
            var positions = new List<Point>();
            for(int i = of.X - radius; i <= of.X + radius; i++) {
                for(int j = of.Y - radius; j <= of.Y + radius; j++) {
                    var position = new Point(i, j);
                    if(i >= 0 && j >= 0 && i < GridSize.Height && j < GridSize.Width) {
                        positions.Add(position);
                    }
                }
            }
            return positions;
	    }

	    private Individual GetIndividual(Point position) {
	        return Population.Single(i => i.Position == position);
	    }

	    private Disease PickRandomDisease() {
	        return DISEASES.Count == 0 ? null : DISEASES[random.Next(0, DISEASES.Count)];
	    }

	    private void DecrementImmunity(Individual individual) {
	        var immunities = new List<Disease>(individual.Immunities.Keys);
	        foreach (var disease in immunities) {
	            if (individual.Immunities[disease] <= 0)
	                individual.Immunities.Remove(disease);
	            else 
                    individual.Immunities[disease]--;
	        }
	    }

		/// <summary>
		/// Updates the Statistics field with a new instance of Statistics.
		/// </summary>
		private void UpdateStatistics() {
			// make a dictionary of diseases and the number of infections, for statistics
			var diseaseMap = new Dictionary<Disease, int>();
			foreach(var disease in DISEASES) {
				diseaseMap[disease] = 0;
				foreach(var individual in Population) {
					if(individual.Diseases.Contains(disease))
						diseaseMap[disease]++;
				}
			}

			// make a new statistics object so we don't modify the one referenced by statistics canvas
			var newStats = new Statistics {
				InitialPopulation = initialPopulation,
				Population = PopulationSize,
				Turns = Turn,
				Outbreaks = Statistics.Outbreaks + (Outbreak() ? 1 : 0),
				Score = Statistics.Score + 1,
				Infections = diseaseMap
			};

			Statistics = newStats;
		}

        /// <summary>
        /// Finds the positions an individual can move to.
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
	    private List<Point> ValidPositions(Point from) {
	        var validPositions = PositionsInRange(from, 1).Where(p => !Occupied(p)).ToList();
	        validPositions.Add(from); //No movement.
	        return validPositions;
	    }

		/// <summary>
		/// Calculates the diversity of the population using euclidean distances between each attribute.
		/// </summary>
		/// <returns></returns>
		public double CalculateDiversity() {
			double reproducabilityDiv = 0;
			var resistanceDiv = new Dictionary<Disease, int>();
			
			foreach(var i1 in Population) {
				foreach(var i2 in Population) {
					reproducabilityDiv += Math.Abs(i1.Reproducability - i2.Reproducability);

					foreach(var disease in DISEASES) {
						if(!resistanceDiv.ContainsKey(disease))
							resistanceDiv[disease] = 0;
						resistanceDiv[disease] += Math.Abs(i1.Resistances[disease] - i2.Resistances[disease]);
					}
				}
			}

			double normalizedDiv = reproducabilityDiv / ((Individual.MAX_REPRODUCABILITY - Individual.MIN_REPRODUCABILITY) * Math.Pow(PopulationSize, 2));
			//normalizedDiv = resistanceDiv[new Anthrax()]/(Individual.MAX_RESISTANCE*Math.Pow(PopulationSize, 2));
			return normalizedDiv;
		}
	}
}
