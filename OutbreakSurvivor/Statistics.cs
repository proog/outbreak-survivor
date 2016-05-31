using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutbreakSurvivor {
	public class Statistics {
		public int Population = 0;
		public int InitialPopulation = 0;
		public int Outbreaks = 0;
		public int Turns = 0;
		public int Score = 0;

		public Dictionary<Disease, int> Infections = new Dictionary<Disease, int>();
	}
}
