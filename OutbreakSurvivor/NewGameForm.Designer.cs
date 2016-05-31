namespace OutbreakSurvivor {
	partial class NewGameForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.quitButton = new System.Windows.Forms.Button();
			this.initialPopulationLabel = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.sizeLabel = new System.Windows.Forms.Label();
			this.titleLabel = new System.Windows.Forms.Label();
			this.populationBox = new System.Windows.Forms.NumericUpDown();
			this.sizeBoxHoriz = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.sizeBoxVert = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.populationBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sizeBoxHoriz)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sizeBoxVert)).BeginInit();
			this.SuspendLayout();
			// 
			// quitButton
			// 
			this.quitButton.Location = new System.Drawing.Point(135, 201);
			this.quitButton.Name = "quitButton";
			this.quitButton.Size = new System.Drawing.Size(75, 23);
			this.quitButton.TabIndex = 21;
			this.quitButton.Text = "Quit";
			this.quitButton.UseVisualStyleBackColor = true;
			this.quitButton.Click += new System.EventHandler(this.QuitButtonClick);
			// 
			// initialPopulationLabel
			// 
			this.initialPopulationLabel.AutoSize = true;
			this.initialPopulationLabel.Location = new System.Drawing.Point(12, 59);
			this.initialPopulationLabel.Name = "initialPopulationLabel";
			this.initialPopulationLabel.Size = new System.Drawing.Size(60, 13);
			this.initialPopulationLabel.TabIndex = 17;
			this.initialPopulationLabel.Text = "Population:";
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(12, 201);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 16;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OkButtonClick);
			// 
			// sizeLabel
			// 
			this.sizeLabel.AutoSize = true;
			this.sizeLabel.Location = new System.Drawing.Point(12, 88);
			this.sizeLabel.Name = "sizeLabel";
			this.sizeLabel.Size = new System.Drawing.Size(30, 13);
			this.sizeLabel.TabIndex = 12;
			this.sizeLabel.Text = "Size:";
			// 
			// titleLabel
			// 
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.Location = new System.Drawing.Point(12, 9);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(198, 33);
			this.titleLabel.TabIndex = 11;
			this.titleLabel.Text = "Game new";
			this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// populationBox
			// 
			this.populationBox.Location = new System.Drawing.Point(78, 57);
			this.populationBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.populationBox.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.populationBox.Name = "populationBox";
			this.populationBox.Size = new System.Drawing.Size(132, 20);
			this.populationBox.TabIndex = 22;
			this.populationBox.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.populationBox.ValueChanged += new System.EventHandler(this.PopulationBoxValueChanged);
			// 
			// sizeBoxHoriz
			// 
			this.sizeBoxHoriz.Location = new System.Drawing.Point(78, 86);
			this.sizeBoxHoriz.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.sizeBoxHoriz.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.sizeBoxHoriz.Name = "sizeBoxHoriz";
			this.sizeBoxHoriz.Size = new System.Drawing.Size(56, 20);
			this.sizeBoxHoriz.TabIndex = 23;
			this.sizeBoxHoriz.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.sizeBoxHoriz.ValueChanged += new System.EventHandler(this.SizeBoxHorizValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(140, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(12, 13);
			this.label1.TabIndex = 24;
			this.label1.Text = "x";
			// 
			// sizeBoxVert
			// 
			this.sizeBoxVert.Location = new System.Drawing.Point(158, 86);
			this.sizeBoxVert.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.sizeBoxVert.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.sizeBoxVert.Name = "sizeBoxVert";
			this.sizeBoxVert.Size = new System.Drawing.Size(52, 20);
			this.sizeBoxVert.TabIndex = 25;
			this.sizeBoxVert.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.sizeBoxVert.ValueChanged += new System.EventHandler(this.SizeBoxVertValueChanged);
			// 
			// NewGameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(222, 236);
			this.ControlBox = false;
			this.Controls.Add(this.sizeBoxVert);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.sizeBoxHoriz);
			this.Controls.Add(this.populationBox);
			this.Controls.Add(this.quitButton);
			this.Controls.Add(this.initialPopulationLabel);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.sizeLabel);
			this.Controls.Add(this.titleLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewGameForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Game";
			this.Load += new System.EventHandler(this.NewGameFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.populationBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sizeBoxHoriz)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sizeBoxVert)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button quitButton;
		private System.Windows.Forms.Label initialPopulationLabel;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label sizeLabel;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.NumericUpDown populationBox;
		private System.Windows.Forms.NumericUpDown sizeBoxHoriz;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown sizeBoxVert;
	}
}