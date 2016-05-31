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
	public partial class NewGameForm : Form {
		private const int HARD_MINIMUM_POPULATION = 2;
		private const int HARD_MINIMUM_SIZE = 2;

		public int PopulationSize {
			get { return (int) populationBox.Value; }
		}
		
		public Size BoardSize {
			get { return new Size((int) sizeBoxHoriz.Value, (int) sizeBoxVert.Value); }
		}

		public NewGameForm() {
			InitializeComponent();
		}

		private void NewGameFormLoad(object sender, EventArgs e) {
			titleLabel.Text = Resources.NewGameTitle;
			initialPopulationLabel.Text = Resources.NewGameInitialPopulationLabel;
			sizeLabel.Text = Resources.NewGameSizeLabel;
			okButton.Text = Resources.NewGameOkButton;
			quitButton.Text = Resources.NewGameQuitButton;

			populationBox.Value = 50;
			PopulationBoxValueChanged(populationBox, new EventArgs());
		}

		private void PopulationBoxValueChanged(object sender, EventArgs e) {
			/*decimal halfPop = populationBox.Value/2;

			sizeBoxHoriz.Minimum = halfPop > HARD_MINIMUM_SIZE ? halfPop : HARD_MINIMUM_SIZE;
			sizeBoxVert.Minimum = halfPop > HARD_MINIMUM_SIZE ? halfPop : HARD_MINIMUM_SIZE;

			sizeBoxHoriz.Value = sizeBoxHoriz.Minimum;
			sizeBoxVert.Value = sizeBoxVert.Minimum;*/
		}

		private void SizeBoxHorizValueChanged(object sender, EventArgs e) {
			sizeBoxVert.Value = sizeBoxHoriz.Value;
		}

		private void SizeBoxVertValueChanged(object sender, EventArgs e) {
			sizeBoxHoriz.Value = sizeBoxVert.Value;
		}

		private void OkButtonClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void QuitButtonClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
