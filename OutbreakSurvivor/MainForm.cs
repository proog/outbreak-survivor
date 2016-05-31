using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OutbreakSurvivor.Properties;

namespace OutbreakSurvivor {
	public partial class MainForm : Form {
		private const int AUTO_PLAY_SPEED = 1000;

        private int reproductionCount;
		private Individual leftMate;
		private Individual rightMate;

		private Timer playTimer;
		private bool autoPlaying = false;

		public MainForm() {
			InitializeComponent();
		}

		/// <summary>
		/// Shows a new game dialog and initializes a new game.
		/// </summary>
		private void NewGame() {
			var newGameDialog = new NewGameForm();
			DialogResult result = newGameDialog.ShowDialog(this);

			if(result == DialogResult.OK) {
				simulationCanvas.Simulator = new Simulator(newGameDialog.PopulationSize, newGameDialog.BoardSize);

                reproductionCount = DetermineReproductionCount(newGameDialog.PopulationSize);

				// initialize autoplay timer
				playTimer = new Timer();
				playTimer.Interval = AUTO_PLAY_SPEED;
				playTimer.Tick += PlayTimerOnTick;

				UpdateOverview();
				UpdateReproductionView();
				statisticsCanvas.ClearStatistics();
				statisticsCanvas.AddStatistics(simulationCanvas.Simulator.Statistics);

				playButton.Text = Resources.Play;
				nextTurnButton.Enabled = true;
			}
			else {
				this.Close();
			}
		}

        private int DetermineReproductionCount(int populationSize) {
            int retVal = populationSize / 4;
            return retVal;
        }

		private void ReproduceButtonClick(object sender, EventArgs e) {
			reproductionCount--;

            List<Individual> children = leftMate.Reproduce(rightMate);
            simulationCanvas.Simulator.RemoveFromPopulation(leftMate);
            simulationCanvas.Simulator.RemoveFromPopulation(rightMate);
            simulationCanvas.Simulator.AddToPopulation(children[0]);
            simulationCanvas.Simulator.AddToPopulation(children[1]);
            UpdateLeftMate(children[0]);
            UpdateRightMate(children[1]);
	        simulationCanvas.Invalidate();
		}

		private void NextTurnButtonClick(object sender, EventArgs e) {
			NextTurn();
		}

		private void NextTurn() {
			simulationCanvas.Simulator.NextTurn();
			UpdateOverview();
			statisticsCanvas.AddStatistics(simulationCanvas.Simulator.Statistics);

			if(!simulationCanvas.Simulator.Population.Contains(leftMate))
				UpdateLeftMate(null);
			if(!simulationCanvas.Simulator.Population.Contains(rightMate))
				UpdateRightMate(null);

			reproductionCount = DetermineReproductionCount(simulationCanvas.Simulator.Population.Count);
			UpdateReproductionView();

			simulationCanvas.Invalidate();

			Console.WriteLine(simulationCanvas.Simulator.CalculateDiversity());

			// game over?
			if(simulationCanvas.Simulator.PopulationSize == 0) {
				playTimer.Stop();
				autoPlaying = false;

				var endGameForm = new EndGameForm(simulationCanvas.Simulator.Statistics);
				if(endGameForm.ShowDialog(this) == DialogResult.Yes) {
					// new game
					NewGame();
				}
				else {
					// quit game
					this.Close();
				}
			}
		}

		private void SimulationCanvasMouseClick(object sender, MouseEventArgs e) {
			var individual = simulationCanvas.GetIndividual(e.Location);
			if(individual == null)
				return;

			if(leftMate == individual || rightMate == individual)
				return;

			if(e.Button == MouseButtons.Left)
				UpdateLeftMate(individual);
			else if(e.Button == MouseButtons.Right)
				UpdateRightMate(individual);
		}

		private void UpdateLeftMate(Individual i) {
			if(leftMate != null)
				simulationCanvas.UnhighlightIndividual(leftMate);
			if(i != null)
				simulationCanvas.HighlightIndividual(i, "A");

			leftMate = i;
			UpdateReproductionView();
		}

		private void UpdateRightMate(Individual i) {
			if(rightMate != null)
				simulationCanvas.UnhighlightIndividual(rightMate);
			if(i != null)
				simulationCanvas.HighlightIndividual(i, "B");

			rightMate = i;
			UpdateReproductionView();
		}

		private void UpdateReproductionView() {
			reproductionListView.BeginUpdate();
			reproductionListView.Items.Clear();

			ListViewGroup generalGroup = reproductionListView.Groups["general"];
			ListViewGroup resistanceGroup = reproductionListView.Groups["resistances"];

			// energy attribute
			var energy = new ListViewItem(Resources.Energy, generalGroup);
			energy.ToolTipText = Resources.EnergyDescription;

			var leftMateEnergy = leftMate != null ? leftMate.Energy.ToString() : "";
			var leftMateEnergySubItem = new ListViewItem.ListViewSubItem(energy, leftMateEnergy);
			energy.SubItems.Add(leftMateEnergySubItem);

			var rightMateEnergy = rightMate != null ? rightMate.Energy.ToString() : "";
			var rightMateEnergySubItem = new ListViewItem.ListViewSubItem(energy, rightMateEnergy);
			energy.SubItems.Add(rightMateEnergySubItem);

			reproductionListView.Items.Add(energy);

			// reproducability attribute
			var rep = new ListViewItem(Resources.Reproducability, generalGroup);
			rep.ToolTipText = Resources.ReproducabilityDescription;

			var leftMateRepr = leftMate != null ? leftMate.Reproducability.ToString() : "";
			var leftMateReprSubItem = new ListViewItem.ListViewSubItem(rep, leftMateRepr);
			rep.SubItems.Add(leftMateReprSubItem);

			var rightMateRepr = rightMate != null ? rightMate.Reproducability.ToString() : "";
			var rightMateReprSubItem = new ListViewItem.ListViewSubItem(rep, rightMateRepr);
			rep.SubItems.Add(rightMateReprSubItem);

			reproductionListView.Items.Add(rep);

			// maturity attribute
			var mat = new ListViewItem(Resources.Maturity, generalGroup);
			mat.ToolTipText = Resources.MaturityDescription;

			var leftMateMat = leftMate != null ? leftMate.Mature.ToString() : "";
			var leftMateMatSubItem = new ListViewItem.ListViewSubItem(mat, leftMateMat);
			mat.SubItems.Add(leftMateMatSubItem);

			var rightMateMat = rightMate != null ? rightMate.Mature.ToString() : "";
			var rightMateMatSubItem = new ListViewItem.ListViewSubItem(mat, rightMateMat);
			mat.SubItems.Add(rightMateMatSubItem);

			reproductionListView.Items.Add(mat);

			// resistance attributes
			foreach(var disease in Simulator.DISEASES) {
				var item = new ListViewItem(disease.ToString(), resistanceGroup);
				item.ForeColor = disease.Color;
				item.ToolTipText = disease.Description;

				var leftResistance = "";
				if(leftMate != null)
					leftResistance = leftMate.Resistances.FirstOrDefault(kv => kv.Key.Equals(disease)).Value.ToString();
				var leftMateSubItem = new ListViewItem.ListViewSubItem(item, leftResistance);
				item.SubItems.Add(leftMateSubItem);

				var rightResistance = "";
				if(rightMate != null)
					rightResistance = rightMate.Resistances.FirstOrDefault(kv => kv.Key.Equals(disease)).Value.ToString();
				var rightMateSubItem = new ListViewItem.ListViewSubItem(item, rightResistance);
				item.SubItems.Add(rightMateSubItem);

				reproductionListView.Items.Add(item);
			}

			reproductionListView.EndUpdate();

			// enable or disable reproduce button
			reproduceButton.Enabled = reproductionCount > 0 && leftMate != null && rightMate != null && leftMate.Mature && rightMate.Mature;
			reproduceButton.Text = Resources.Reproduce + " (" + reproductionCount + Resources.ReproduceLeft + ")";
		}

		private void UpdateOverview() {
			var sim = simulationCanvas.Simulator;
			totalLabel.Text = sim.PopulationSize.ToString();
			sickLabel.Text = sim.Population.Count(i => i.Diseases.Count > 0).ToString();
			turnLabel.Text = sim.Turn.ToString();
			outbreakLabel.Text = (Simulator.OUTBREAK_INTERVAL-(sim.Turn % Simulator.OUTBREAK_INTERVAL)).ToString();
		    detailsLabel.Text = sim.Outbreak() ? sim.RecentDisease.Name + ": " + sim.RecentDisease.Description : "";
		}

		private void MainFormLoad(object sender, EventArgs e) {
			NewGame();
		}

		private void PlayButtonClick(object sender, EventArgs e) {
			if(autoPlaying) {
				playTimer.Stop();
				playButton.Text = Resources.Play;
				autoPlaying = false;
				nextTurnButton.Enabled = true;
			}
			else {
				playButton.Text = Resources.Pause;
				autoPlaying = true;
				nextTurnButton.Enabled = false;
				playTimer.Start();
			}
		}

		private void PlayTimerOnTick(object sender, EventArgs e) {
			NextTurn();
		}
	}
}
