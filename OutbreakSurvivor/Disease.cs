using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OutbreakSurvivor {
	public abstract class Disease {
		public abstract string Name { get; }
		public abstract string Description { get; }
		public abstract int Radius { get; }
		public abstract Color Color { get; }

		public abstract void ApplyEffect(Individual i);
		public abstract void Infect(Individual i);

		public override bool Equals(object obj) {
			if(obj is Disease && this.Name == (obj as Disease).Name)
				return true;
			return false;
		}

        public override int GetHashCode() {
            return Name.GetHashCode();
        }

		public override string ToString() {
			return Name;
		}
	}
}
