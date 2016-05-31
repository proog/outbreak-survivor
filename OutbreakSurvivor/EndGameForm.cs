using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OutbreakSurvivor.Properties;

namespace OutbreakSurvivor {
	public partial class EndGameForm : Form {
		private readonly Statistics stats;

		public EndGameForm() {
			InitializeComponent();
		}

		public EndGameForm(Statistics stats) : this() {
			this.stats = stats;
		}

		private void EndGameFormLoad(object sender, EventArgs e) {
			titleLabel.Text = Resources.EndGameTitle;
			initialPopulationLabel.Text = Resources.EndGameInitialPopulationLabel;
			scoreLabel.Text = Resources.EndGameScoreLabel;
			turnsLabel.Text = Resources.EndGameTurnsLabel;
			outbreaksLabel.Text = Resources.EndGameOutbreaksLabel;
			okButton.Text = Resources.EndGameOkButton;
			quitButton.Text = Resources.EndGameQuitButton;

			initialPopulationValueLabel.Text = stats.InitialPopulation.ToString();
			scoreValueLabel.Text = stats.Score.ToString();
			turnsValueLabel.Text = stats.Turns.ToString();
			outbreaksValueLabel.Text = stats.Outbreaks.ToString();
		}

		private void OkButtonClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Yes;
			this.Close();
		}

		private void QuitButtonClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.No;
			this.Close();
		}
	}
}
