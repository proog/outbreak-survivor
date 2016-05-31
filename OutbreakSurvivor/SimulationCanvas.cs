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
	public partial class SimulationCanvas : UserControl {
		private Simulator _simulator;
		public Simulator Simulator {
			get { return _simulator; }
			set {
				_simulator = value;
				this.Invalidate();
			}
		}
		private Size GridSize {
			get { return Simulator.GridSize; }
		}
		private Size CellSize {
			get { return new Size(this.Width/GridSize.Width, this.Height/GridSize.Height); }
		}

		private readonly Dictionary<Individual, Rectangle> populationRectangles = new Dictionary<Individual, Rectangle>();
		private readonly Dictionary<Individual, string> highlightedIndividuals = new Dictionary<Individual, string>();
		private readonly Timer fadeTimer = new Timer { Interval = 40 };
		private const int ALPHA_START = 255;
		private int alpha = ALPHA_START;
		private int fadeTurn = 0;
		private FadeState fadeState = FadeState.PreFade;
		private enum FadeState { PreFade, Fade, PostFade };

		public SimulationCanvas() {
			InitializeComponent();
			DoubleBuffered = true;
			fadeTimer.Tick += FadeTimerOnTick;
		}

		private void FadeTimerOnTick(object sender, EventArgs eventArgs) {
			if(Simulator.Turn > fadeTurn) {
				fadeTimer.Stop();
				fadeState = FadeState.PreFade;
			}
			else {
				alpha = Math.Max(0, alpha - 5);

				if(alpha == 0)
					fadeState = FadeState.PostFade;

				this.Invalidate();
			}
		}

		private void SimulationCanvasPaint(object sender, PaintEventArgs e) {
			Graphics g = e.Graphics;
			if(DesignMode)
				return;

			//DrawGrid(g);
			DrawPopulation(g);

			if(_simulator.Outbreak()) {
				if(fadeState == 0) {
					fadeTurn = Simulator.Turn;
					fadeState = FadeState.Fade;
					alpha = ALPHA_START;
					fadeTimer.Start();
				}

				DrawOutbreak(_simulator.RecentDisease, g);
			}
		}

		private void DrawGrid(Graphics g) {
			for(int i = 0; i <= GridSize.Width; i++)
				g.DrawLine(Pens.Black, CellSize.Width*i, 0, CellSize.Width*i, GridSize.Height*CellSize.Height);
			for(int i = 0; i <= GridSize.Height; i++)
				g.DrawLine(Pens.Black, 0, CellSize.Height*i, GridSize.Width*CellSize.Width, CellSize.Height*i);
		}

		private void DrawPopulation(Graphics g) {
			populationRectangles.Clear();

			foreach(var individual in Simulator.Population) {
				var cellX = individual.Position.X;
				var cellY = individual.Position.Y;
				const int spacing = 2;
				var position = new Point(cellX*CellSize.Width+spacing, cellY*CellSize.Height+spacing);
				var rect = new Rectangle(position, new Size(CellSize.Width-2*spacing, CellSize.Height-2*spacing));

				bool highlighted = highlightedIndividuals.ContainsKey(individual);
				Brush b = highlighted ? Brushes.Gold : (individual.Mature ? Brushes.Black : Brushes.Gray);
				g.FillRectangle(b, rect);

				if(highlighted) {
					var font = new Font("Tahoma", 10);
					var text = highlightedIndividuals[individual];
					var size = g.MeasureString(text, font);
					float x = rect.X + rect.Width/2f - size.Width/2f;
					float y = rect.Y + rect.Height/2f - size.Height/2f;
					var point = new PointF(x, y);
					g.DrawString(text, font, Brushes.Black, point);
				}

				// draw disease indicators
			    if (individual.Diseases.Count > 0) {
				    const int maxDiseaseRectangles = 5;
				    int i = 0;

					foreach (var disease in individual.Diseases) {
					    Brush dBrush = new SolidBrush(disease.Color);
						int xPos = position.X + (CellSize.Width / maxDiseaseRectangles) * (i % maxDiseaseRectangles);
						int yPos = position.Y + (i / maxDiseaseRectangles) * (CellSize.Height / maxDiseaseRectangles);
						var dPoint = new Point(xPos, yPos);
						var dSize = new Size(CellSize.Width / maxDiseaseRectangles, CellSize.Height / maxDiseaseRectangles);
						var dRect = new Rectangle(dPoint, dSize);
						g.FillRectangle(dBrush, dRect);
						i++;

						// draw disease radius
						if(highlightedIndividuals.ContainsKey(individual)) {
							var dPen = new Pen(dBrush, spacing) { DashStyle = DashStyle.Dash };
							xPos = position.X - (CellSize.Width * disease.Radius) - spacing;
							yPos = position.Y - (CellSize.Height * disease.Radius) - spacing;
							dPoint = new Point(xPos, yPos);
							dSize = new Size(CellSize.Width * disease.Radius * 2 + CellSize.Width, CellSize.Height * disease.Radius * 2 + CellSize.Height);
							dRect = new Rectangle(dPoint, dSize);
							g.DrawRectangle(dPen, dRect);
						}
					}
			    }

				populationRectangles.Add(individual, rect);
			}
		}

		public Individual GetIndividual(Point p) {
			return populationRectangles.FirstOrDefault(kv => kv.Value.Contains(p)).Key;
		}

		public void HighlightIndividual(Individual i) {
			HighlightIndividual(i, string.Empty);
		}

		public void HighlightIndividual(Individual i, string text) {
			highlightedIndividuals.Add(i, text);
			this.Invalidate();
		}

		public void UnhighlightIndividual(Individual i) {
			highlightedIndividuals.Remove(i);
			this.Invalidate();
		}

		private void SimulationCanvasResize(object sender, EventArgs e) {
			this.Invalidate();
		}

        public void DrawOutbreak(Disease disease, Graphics g) {
			//int alpha = 70;
	        //var inverseColor = Color.FromArgb(alpha, 255 - disease.Color.R, 255 - disease.Color.G, 255 - disease.Color.B);
            Rectangle rect = new Rectangle(new Point(0, 0), this.Size);
	        g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, disease.Color.R, disease.Color.G, disease.Color.B)), rect);
            var stringformat = new StringFormat {LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center};
	        g.DrawString(disease.Name, new Font("Old English Text MT", 50f), new SolidBrush(Color.FromArgb(alpha, Color.DarkRed)), rect, stringformat);
	    }
	}
}
