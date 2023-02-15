using System.Runtime.InteropServices;

namespace GameShuffler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (disposing)
            {
                UnregisterHotKey(this.Handle, RemoveGameKeyId);
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.runningProcessesSelectionList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.minTimeTextBox = new System.Windows.Forms.TextBox();
            this.maxTimeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // runningProcessesSelectionList
            // 
            this.runningProcessesSelectionList.FormattingEnabled = true;
            this.runningProcessesSelectionList.Location = new System.Drawing.Point(40, 40);
            this.runningProcessesSelectionList.Name = "runningProcessesSelectionList";
            this.runningProcessesSelectionList.Size = new System.Drawing.Size(720, 340);
            this.runningProcessesSelectionList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select games to shuffle:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 502);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(426, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Press PageDown to remove a game from the shuffle";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(472, 497);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(133, 34);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start Shuffling";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Clicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Minimum time before shuffling:";
            // 
            // minTimeTextBox
            // 
            this.minTimeTextBox.Location = new System.Drawing.Point(309, 386);
            this.minTimeTextBox.Name = "minTimeTextBox";
            this.minTimeTextBox.Size = new System.Drawing.Size(150, 31);
            this.minTimeTextBox.TabIndex = 5;
            this.minTimeTextBox.Text = "60";
            // 
            // maxTimeTextBox
            // 
            this.maxTimeTextBox.Location = new System.Drawing.Point(309, 423);
            this.maxTimeTextBox.Name = "maxTimeTextBox";
            this.maxTimeTextBox.Size = new System.Drawing.Size(150, 31);
            this.maxTimeTextBox.TabIndex = 6;
            this.maxTimeTextBox.Text = "120";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(266, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Maximum time before shuffling:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(465, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "seconds";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(465, 426);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "seconds";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(648, 4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(112, 34);
            this.refreshButton.TabIndex = 10;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.Refresh_Clicked);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(611, 497);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(149, 34);
            this.stopButton.TabIndex = 11;
            this.stopButton.Text = "Stop Shuffling";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Clicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 593);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maxTimeTextBox);
            this.Controls.Add(this.minTimeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runningProcessesSelectionList);
            this.Name = "Form1";
            this.Text = "Game Shuffler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckedListBox runningProcessesSelectionList;
        private Label label1;
        private Label label2;
        private Button startButton;
        private Label label3;
        private TextBox minTimeTextBox;
        private TextBox maxTimeTextBox;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button refreshButton;
        private Button stopButton;
    }
}