namespace OutbreakSurvivor {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("General", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Resistances", System.Windows.Forms.HorizontalAlignment.Left);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.reproductionListView = new System.Windows.Forms.ListView();
			this.attributeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.leftMateColum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.rightMateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.reproduceButton = new System.Windows.Forms.Button();
			this.nextTurnButton = new System.Windows.Forms.Button();
			this.overviewBox = new System.Windows.Forms.GroupBox();
			this.detailsLabel = new System.Windows.Forms.RichTextBox();
			this.outbreakLabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.turnLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.sickLabel = new System.Windows.Forms.Label();
			this.totalLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.playButton = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.statisticsCanvas = new OutbreakSurvivor.StatisticsCanvas();
			this.simulationCanvas = new OutbreakSurvivor.SimulationCanvas();
			this.groupBox1.SuspendLayout();
			this.overviewBox.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.reproductionListView);
			this.groupBox1.Controls.Add(this.reproduceButton);
			this.groupBox1.Location = new System.Drawing.Point(555, 273);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(352, 281);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Reproduction";
			// 
			// reproductionListView
			// 
			this.reproductionListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.reproductionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.attributeColumn,
            this.leftMateColum,
            this.rightMateColumn});
			this.reproductionListView.FullRowSelect = true;
			listViewGroup1.Header = "General";
			listViewGroup1.Name = "general";
			listViewGroup2.Header = "Resistances";
			listViewGroup2.Name = "resistances";
			this.reproductionListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.reproductionListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.reproductionListView.Location = new System.Drawing.Point(6, 19);
			this.reproductionListView.MultiSelect = false;
			this.reproductionListView.Name = "reproductionListView";
			this.reproductionListView.ShowItemToolTips = true;
			this.reproductionListView.Size = new System.Drawing.Size(340, 227);
			this.reproductionListView.TabIndex = 3;
			this.reproductionListView.UseCompatibleStateImageBehavior = false;
			this.reproductionListView.View = System.Windows.Forms.View.Details;
			// 
			// attributeColumn
			// 
			this.attributeColumn.Text = "Attribute";
			this.attributeColumn.Width = 173;
			// 
			// leftMateColum
			// 
			this.leftMateColum.Text = "Mate A";
			this.leftMateColum.Width = 66;
			// 
			// rightMateColumn
			// 
			this.rightMateColumn.Text = "Mate B";
			this.rightMateColumn.Width = 76;
			// 
			// reproduceButton
			// 
			this.reproduceButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.reproduceButton.Enabled = false;
			this.reproduceButton.Location = new System.Drawing.Point(92, 252);
			this.reproduceButton.Name = "reproduceButton";
			this.reproduceButton.Size = new System.Drawing.Size(179, 23);
			this.reproduceButton.TabIndex = 2;
			this.reproduceButton.Text = "Reproduce";
			this.reproduceButton.UseVisualStyleBackColor = true;
			this.reproduceButton.Click += new System.EventHandler(this.ReproduceButtonClick);
			// 
			// nextTurnButton
			// 
			this.nextTurnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nextTurnButton.Location = new System.Drawing.Point(832, 82);
			this.nextTurnButton.Name = "nextTurnButton";
			this.nextTurnButton.Size = new System.Drawing.Size(75, 23);
			this.nextTurnButton.TabIndex = 8;
			this.nextTurnButton.Text = "Next turn";
			this.nextTurnButton.UseVisualStyleBackColor = true;
			this.nextTurnButton.Click += new System.EventHandler(this.NextTurnButtonClick);
			// 
			// overviewBox
			// 
			this.overviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.overviewBox.Controls.Add(this.detailsLabel);
			this.overviewBox.Controls.Add(this.outbreakLabel);
			this.overviewBox.Controls.Add(this.label5);
			this.overviewBox.Controls.Add(this.turnLabel);
			this.overviewBox.Controls.Add(this.label4);
			this.overviewBox.Controls.Add(this.sickLabel);
			this.overviewBox.Controls.Add(this.totalLabel);
			this.overviewBox.Controls.Add(this.label2);
			this.overviewBox.Controls.Add(this.label1);
			this.overviewBox.Location = new System.Drawing.Point(555, 12);
			this.overviewBox.Name = "overviewBox";
			this.overviewBox.Size = new System.Drawing.Size(271, 93);
			this.overviewBox.TabIndex = 2;
			this.overviewBox.TabStop = false;
			this.overviewBox.Text = "Overview";
			// 
			// detailsLabel
			// 
			this.detailsLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.detailsLabel.Location = new System.Drawing.Point(105, 16);
			this.detailsLabel.Name = "detailsLabel";
			this.detailsLabel.ReadOnly = true;
			this.detailsLabel.Size = new System.Drawing.Size(160, 71);
			this.detailsLabel.TabIndex = 9;
			this.detailsLabel.Text = "";
			// 
			// outbreakLabel
			// 
			this.outbreakLabel.AutoSize = true;
			this.outbreakLabel.Location = new System.Drawing.Point(74, 55);
			this.outbreakLabel.Name = "outbreakLabel";
			this.outbreakLabel.Size = new System.Drawing.Size(13, 13);
			this.outbreakLabel.TabIndex = 7;
			this.outbreakLabel.Text = "0";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 55);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(62, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Outbreak in";
			// 
			// turnLabel
			// 
			this.turnLabel.AutoSize = true;
			this.turnLabel.Location = new System.Drawing.Point(74, 42);
			this.turnLabel.Name = "turnLabel";
			this.turnLabel.Size = new System.Drawing.Size(13, 13);
			this.turnLabel.TabIndex = 5;
			this.turnLabel.Text = "0";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 42);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Turn";
			// 
			// sickLabel
			// 
			this.sickLabel.AutoSize = true;
			this.sickLabel.Location = new System.Drawing.Point(74, 29);
			this.sickLabel.Name = "sickLabel";
			this.sickLabel.Size = new System.Drawing.Size(13, 13);
			this.sickLabel.TabIndex = 3;
			this.sickLabel.Text = "0";
			// 
			// totalLabel
			// 
			this.totalLabel.AutoSize = true;
			this.totalLabel.Location = new System.Drawing.Point(74, 16);
			this.totalLabel.Name = "totalLabel";
			this.totalLabel.Size = new System.Drawing.Size(13, 13);
			this.totalLabel.TabIndex = 2;
			this.totalLabel.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Sick";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Total";
			// 
			// playButton
			// 
			this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.playButton.Location = new System.Drawing.Point(832, 53);
			this.playButton.Name = "playButton";
			this.playButton.Size = new System.Drawing.Size(75, 23);
			this.playButton.TabIndex = 9;
			this.playButton.Text = "Play";
			this.playButton.UseVisualStyleBackColor = true;
			this.playButton.Click += new System.EventHandler(this.PlayButtonClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.statisticsCanvas);
			this.groupBox2.Location = new System.Drawing.Point(555, 111);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(352, 156);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Population";
			// 
			// statisticsCanvas
			// 
			this.statisticsCanvas.Location = new System.Drawing.Point(6, 19);
			this.statisticsCanvas.Name = "statisticsCanvas";
			this.statisticsCanvas.Size = new System.Drawing.Size(340, 131);
			this.statisticsCanvas.TabIndex = 0;
			// 
			// simulationCanvas
			// 
			this.simulationCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.simulationCanvas.Location = new System.Drawing.Point(12, 12);
			this.simulationCanvas.Name = "simulationCanvas";
			this.simulationCanvas.Simulator = null;
			this.simulationCanvas.Size = new System.Drawing.Size(537, 542);
			this.simulationCanvas.TabIndex = 3;
			this.simulationCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SimulationCanvasMouseClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(919, 566);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.playButton);
			this.Controls.Add(this.simulationCanvas);
			this.Controls.Add(this.nextTurnButton);
			this.Controls.Add(this.overviewBox);
			this.Controls.Add(this.groupBox1);
			this.MinimumSize = new System.Drawing.Size(800, 500);
			this.Name = "MainForm";
			this.Text = "Outbreak Survivor!";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.groupBox1.ResumeLayout(false);
			this.overviewBox.ResumeLayout(false);
			this.overviewBox.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox overviewBox;
		private System.Windows.Forms.Label outbreakLabel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label turnLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label sickLabel;
		private System.Windows.Forms.Label totalLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button reproduceButton;
		private System.Windows.Forms.Button nextTurnButton;
		private SimulationCanvas simulationCanvas;
		private System.Windows.Forms.ListView reproductionListView;
		private System.Windows.Forms.ColumnHeader attributeColumn;
		private System.Windows.Forms.ColumnHeader leftMateColum;
		private System.Windows.Forms.ColumnHeader rightMateColumn;
		private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.RichTextBox detailsLabel;
		private System.Windows.Forms.GroupBox groupBox2;
		private StatisticsCanvas statisticsCanvas;
	}
}

