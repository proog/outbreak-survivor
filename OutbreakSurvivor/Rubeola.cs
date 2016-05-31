using System;
using System.Drawing;

namespace OutbreakSurvivor {
    using OutbreakSurvivor.Properties;

    class Rubeola : Disease {

        private Random random = new Random();
        public override string Name {
            get { return Resources.DiseaseRubeolaName; }
        }

        public override string Description {
            get { return Resources.DiseaseRubeolaDescription + " [" + Resources.DiseaseRadiusText + "=" + Radius + "]"; }
        }

        public override int Radius {
            get { return 3; }
        }

        public override Color Color {
            get { return Color.Red; }
        }

        public override void ApplyEffect(Individual i) {
            var newResistance = i.Resistances[new Anthrax()]*0.9;

            i.Resistances[new Anthrax()] = (int)newResistance;
        }

        /// <summary>
        /// Possibly infect an individual.
        /// </summary>
        /// <param name="i">The individual.</param>
        public override void Infect(Individual i) {
            // roll chance for infection and apply it to the individual's attributes.
            if(i.Immunities.ContainsKey(this) || i.Diseases.Contains(this))
                return;
            var resistance = i.Resistances[this];
            if(random.Next(Individual.MIN_RESISTANCE, Individual.MAX_RESISTANCE) > resistance) {
                i.Diseases.Add(this);
            } else {
                i.Immunities.Add(this, Simulator.IMMUNITY_DURATION);
            }
        }
    }
}
