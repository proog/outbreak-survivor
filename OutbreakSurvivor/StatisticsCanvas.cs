using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OutbreakSurvivor {
	public partial class StatisticsCanvas : UserControl {
		private List<Statistics> stats = new List<Statistics>();

		public StatisticsCanvas() {
			InitializeComponent();
			this.DoubleBuffered = true;
		}

		public void AddStatistics(Statistics s) {
			stats.Add(s);
			this.Invalidate();
		}

		public void ClearStatistics() {
			stats.Clear();
			this.Invalidate();
		}

		private void StatisticsCanvasPaint(object sender, PaintEventArgs e) {
			if(DesignMode)
				return;

			var g = e.Graphics;
			g.SmoothingMode = SmoothingMode.HighQuality;

			var textFont = new Font("Tahoma", 10);
			var textBrush = Brushes.Black;
			var populationPen = Pens.Black;

			int width = this.Width;
			int height = this.Height;
			int xMin = 20;
			int yMin = 10;
			int xMax = width - 10;
			int yMax = height - 10;
			float spacing = (xMax - xMin) / (float)stats.Count;
			float unit = (yMax - yMin) / (float)stats[0].InitialPopulation;

			// draw baseline
			var basePen = Pens.Black;
			g.DrawLine(basePen, xMin, yMax, xMax, yMax);
			g.DrawString(0.ToString(), textFont, textBrush, 0, yMax - 8);
			g.DrawString(stats[0].InitialPopulation.ToString(), textFont, textBrush, 0, yMin - 8);

			// draw stats
			for(int i = 0; i + 1 < stats.Count; i++) {
				var s1 = stats[i];
				var s2 = stats[i + 1];

				// draw population line
				float x1 = xMin + spacing*i;
				float y1 = Math.Abs(yMax - unit*s1.Population);
				float x2 = xMin + spacing*(i + 1);
				float y2 = Math.Abs(yMax - unit*s2.Population);
				g.DrawLine(populationPen, x1, y1, x2, y2);

				// draw disease lines
				foreach(var disease in Simulator.DISEASES) {
					y1 = Math.Abs(yMax - unit*s1.Infections[disease]);
					y2 = Math.Abs(yMax - unit*s2.Infections[disease]);
					var pen = new Pen(disease.Color);
					g.DrawLine(pen, x1, y1, x2, y2);
				}

				//g.DrawString(s1.Turns.ToString(), textFont, textBrush, spacing*i, yStart);
				//g.DrawString(s2.Turns.ToString(), textFont, textBrush, spacing*(i + 1), yStart);
			}
		}
	}
}
