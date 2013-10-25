namespace game
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StartButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.trackBarScores = new System.Windows.Forms.TrackBar();
            this.progressBarTime = new System.Windows.Forms.ProgressBar();
            this.labelPercents = new System.Windows.Forms.Label();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.TimeSetter = new System.Windows.Forms.NumericUpDown();
            this.HelpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeSetter)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Khaki;
            this.StartButton.Location = new System.Drawing.Point(12, 243);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(98, 42);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Lat\'s play bro";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.GameStartClick);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 12);
            this.listBox.Name = "listBox";
            this.listBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox.Size = new System.Drawing.Size(98, 225);
            this.listBox.TabIndex = 1;
            // 
            // trackBarScores
            // 
            this.trackBarScores.Enabled = false;
            this.trackBarScores.LargeChange = 1;
            this.trackBarScores.Location = new System.Drawing.Point(125, 273);
            this.trackBarScores.Maximum = 16;
            this.trackBarScores.Name = "trackBarScores";
            this.trackBarScores.Size = new System.Drawing.Size(252, 45);
            this.trackBarScores.TabIndex = 2;
            this.trackBarScores.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // progressBarTime
            // 
            this.progressBarTime.Location = new System.Drawing.Point(125, 337);
            this.progressBarTime.Name = "progressBarTime";
            this.progressBarTime.Size = new System.Drawing.Size(252, 23);
            this.progressBarTime.Step = 1;
            this.progressBarTime.TabIndex = 3;
            // 
            // labelPercents
            // 
            this.labelPercents.AutoSize = true;
            this.labelPercents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPercents.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPercents.Location = new System.Drawing.Point(125, 372);
            this.labelPercents.Name = "labelPercents";
            this.labelPercents.Size = new System.Drawing.Size(69, 27);
            this.labelPercents.TabIndex = 5;
            this.labelPercents.Text = "100%";
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSeconds.Location = new System.Drawing.Point(215, 372);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(78, 27);
            this.labelSeconds.TabIndex = 5;
            this.labelSeconds.Text = "60 sec";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // TimeSetter
            // 
            this.TimeSetter.Location = new System.Drawing.Point(12, 372);
            this.TimeSetter.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.TimeSetter.Name = "TimeSetter";
            this.TimeSetter.Size = new System.Drawing.Size(69, 20);
            this.TimeSetter.TabIndex = 6;
            this.TimeSetter.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.SystemColors.Info;
            this.HelpButton.Location = new System.Drawing.Point(296, 372);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(81, 27);
            this.HelpButton.TabIndex = 7;
            this.HelpButton.Text = "Ціль гри";
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.HelpButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::game.Properties.Resources.back2;
            this.ClientSize = new System.Drawing.Size(389, 408);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.TimeSetter);
            this.Controls.Add(this.labelSeconds);
            this.Controls.Add(this.labelPercents);
            this.Controls.Add(this.progressBarTime);
            this.Controls.Add(this.trackBarScores);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.StartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "the Game";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeSetter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TrackBar trackBarScores;
        private System.Windows.Forms.ProgressBar progressBarTime;
        private System.Windows.Forms.Label labelPercents;
        private System.Windows.Forms.Label labelSeconds;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.NumericUpDown TimeSetter;
        private System.Windows.Forms.Button HelpButton;

    }
}

