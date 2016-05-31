namespace OutbreakSurvivor {
	partial class EndGameForm {
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
			this.titleLabel = new System.Windows.Forms.Label();
			this.scoreLabel = new System.Windows.Forms.Label();
			this.turnsLabel = new System.Windows.Forms.Label();
			this.scoreValueLabel = new System.Windows.Forms.Label();
			this.turnsValueLabel = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.initialPopulationValueLabel = new System.Windows.Forms.Label();
			this.initialPopulationLabel = new System.Windows.Forms.Label();
			this.outbreaksValueLabel = new System.Windows.Forms.Label();
			this.outbreaksLabel = new System.Windows.Forms.Label();
			this.quitButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// titleLabel
			// 
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.Location = new System.Drawing.Point(12, 9);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(198, 33);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "Game Over";
			this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// scoreLabel
			// 
			this.scoreLabel.AutoSize = true;
			this.scoreLabel.Location = new System.Drawing.Point(12, 88);
			this.scoreLabel.Name = "scoreLabel";
			this.scoreLabel.Size = new System.Drawing.Size(38, 13);
			this.scoreLabel.TabIndex = 1;
			this.scoreLabel.Text = "Score:";
			// 
			// turnsLabel
			// 
			this.turnsLabel.AutoSize = true;
			this.turnsLabel.Location = new System.Drawing.Point(12, 117);
			this.turnsLabel.Name = "turnsLabel";
			this.turnsLabel.Size = new System.Drawing.Size(37, 13);
			this.turnsLabel.TabIndex = 2;
			this.turnsLabel.Text = "Turns:";
			// 
			// scoreValueLabel
			// 
			this.scoreValueLabel.AutoSize = true;
			this.scoreValueLabel.Location = new System.Drawing.Point(197, 88);
			this.scoreValueLabel.Name = "scoreValueLabel";
			this.scoreValueLabel.Size = new System.Drawing.Size(13, 13);
			this.scoreValueLabel.TabIndex = 3;
			this.scoreValueLabel.Text = "0";
			this.scoreValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// turnsValueLabel
			// 
			this.turnsValueLabel.AutoSize = true;
			this.turnsValueLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.turnsValueLabel.Location = new System.Drawing.Point(197, 117);
			this.turnsValueLabel.Name = "turnsValueLabel";
			this.turnsValueLabel.Size = new System.Drawing.Size(13, 13);
			this.turnsValueLabel.TabIndex = 4;
			this.turnsValueLabel.Text = "0";
			this.turnsValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(12, 201);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 5;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OkButtonClick);
			// 
			// initialPopulationValueLabel
			// 
			this.initialPopulationValueLabel.AutoSize = true;
			this.initialPopulationValueLabel.Location = new System.Drawing.Point(197, 59);
			this.initialPopulationValueLabel.Name = "initialPopulationValueLabel";
			this.initialPopulationValueLabel.Size = new System.Drawing.Size(13, 13);
			this.initialPopulationValueLabel.TabIndex = 7;
			this.initialPopulationValueLabel.Text = "0";
			this.initialPopulationValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// initialPopulationLabel
			// 
			this.initialPopulationLabel.AutoSize = true;
			this.initialPopulationLabel.Location = new System.Drawing.Point(12, 59);
			this.initialPopulationLabel.Name = "initialPopulationLabel";
			this.initialPopulationLabel.Size = new System.Drawing.Size(86, 13);
			this.initialPopulationLabel.TabIndex = 6;
			this.initialPopulationLabel.Text = "Initial population:";
			// 
			// outbreaksValueLabel
			// 
			this.outbreaksValueLabel.AutoSize = true;
			this.outbreaksValueLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.outbreaksValueLabel.Location = new System.Drawing.Point(197, 145);
			this.outbreaksValueLabel.Name = "outbreaksValueLabel";
			this.outbreaksValueLabel.Size = new System.Drawing.Size(13, 13);
			this.outbreaksValueLabel.TabIndex = 9;
			this.outbreaksValueLabel.Text = "0";
			this.outbreaksValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// outbreaksLabel
			// 
			this.outbreaksLabel.AutoSize = true;
			this.outbreaksLabel.Location = new System.Drawing.Point(12, 145);
			this.outbreaksLabel.Name = "outbreaksLabel";
			this.outbreaksLabel.Size = new System.Drawing.Size(59, 13);
			this.outbreaksLabel.TabIndex = 8;
			this.outbreaksLabel.Text = "Outbreaks:";
			// 
			// quitButton
			// 
			this.quitButton.Location = new System.Drawing.Point(135, 201);
			this.quitButton.Name = "quitButton";
			this.quitButton.Size = new System.Drawing.Size(75, 23);
			this.quitButton.TabIndex = 10;
			this.quitButton.Text = "Quit";
			this.quitButton.UseVisualStyleBackColor = true;
			this.quitButton.Click += new System.EventHandler(this.QuitButtonClick);
			// 
			// EndGameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(222, 236);
			this.ControlBox = false;
			this.Controls.Add(this.quitButton);
			this.Controls.Add(this.outbreaksValueLabel);
			this.Controls.Add(this.outbreaksLabel);
			this.Controls.Add(this.initialPopulationValueLabel);
			this.Controls.Add(this.initialPopulationLabel);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.turnsValueLabel);
			this.Controls.Add(this.scoreValueLabel);
			this.Controls.Add(this.turnsLabel);
			this.Controls.Add(this.scoreLabel);
			this.Controls.Add(this.titleLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EndGameForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Game Over";
			this.Load += new System.EventHandler(this.EndGameFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Label scoreLabel;
		private System.Windows.Forms.Label turnsLabel;
		private System.Windows.Forms.Label scoreValueLabel;
		private System.Windows.Forms.Label turnsValueLabel;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label initialPopulationValueLabel;
		private System.Windows.Forms.Label initialPopulationLabel;
		private System.Windows.Forms.Label outbreaksValueLabel;
		private System.Windows.Forms.Label outbreaksLabel;
		private System.Windows.Forms.Button quitButton;
	}
}