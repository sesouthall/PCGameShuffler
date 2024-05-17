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
            runningProcessesSelectionList = new CheckedListBox();
            label1 = new Label();
            label2 = new Label();
            startButton = new Button();
            label3 = new Label();
            minTimeTextBox = new TextBox();
            maxTimeTextBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            refreshButton = new Button();
            stopButton = new Button();
            label7 = new Label();
            SuspendLayout();
            // 
            // runningProcessesSelectionList
            // 
            runningProcessesSelectionList.FormattingEnabled = true;
            runningProcessesSelectionList.Location = new Point(40, 40);
            runningProcessesSelectionList.Name = "runningProcessesSelectionList";
            runningProcessesSelectionList.Size = new Size(720, 340);
            runningProcessesSelectionList.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 9);
            label1.Name = "label1";
            label1.Size = new Size(200, 25);
            label1.TabIndex = 1;
            label1.Text = "Select games to shuffle:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 502);
            label2.Name = "label2";
            label2.Size = new Size(426, 25);
            label2.TabIndex = 2;
            label2.Text = "Press PageDown to remove a game from the shuffle";
            // 
            // startButton
            // 
            startButton.Location = new Point(472, 497);
            startButton.Name = "startButton";
            startButton.Size = new Size(133, 34);
            startButton.TabIndex = 3;
            startButton.Text = "Start Shuffling";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButton_Clicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 389);
            label3.Name = "label3";
            label3.Size = new Size(263, 25);
            label3.TabIndex = 4;
            label3.Text = "Minimum time before shuffling:";
            // 
            // minTimeTextBox
            // 
            minTimeTextBox.Location = new Point(309, 386);
            minTimeTextBox.Name = "minTimeTextBox";
            minTimeTextBox.Size = new Size(150, 31);
            minTimeTextBox.TabIndex = 5;
            minTimeTextBox.Text = "60";
            // 
            // maxTimeTextBox
            // 
            maxTimeTextBox.Location = new Point(309, 423);
            maxTimeTextBox.Name = "maxTimeTextBox";
            maxTimeTextBox.Size = new Size(150, 31);
            maxTimeTextBox.TabIndex = 6;
            maxTimeTextBox.Text = "120";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 426);
            label4.Name = "label4";
            label4.Size = new Size(266, 25);
            label4.TabIndex = 7;
            label4.Text = "Maximum time before shuffling:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(465, 389);
            label5.Name = "label5";
            label5.Size = new Size(77, 25);
            label5.TabIndex = 8;
            label5.Text = "seconds";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(465, 426);
            label6.Name = "label6";
            label6.Size = new Size(77, 25);
            label6.TabIndex = 9;
            label6.Text = "seconds";
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(648, 4);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(112, 34);
            refreshButton.TabIndex = 10;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += Refresh_Clicked;
            // 
            // stopButton
            // 
            stopButton.Enabled = false;
            stopButton.Location = new Point(611, 497);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(149, 34);
            stopButton.TabIndex = 11;
            stopButton.Text = "Stop Shuffling";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += StopButton_Clicked;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(40, 531);
            label7.Name = "label7";
            label7.Size = new Size(331, 25);
            label7.TabIndex = 12;
            label7.Text = "Press PageUp to move to the next game";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 593);
            Controls.Add(label7);
            Controls.Add(stopButton);
            Controls.Add(refreshButton);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(maxTimeTextBox);
            Controls.Add(minTimeTextBox);
            Controls.Add(label3);
            Controls.Add(startButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(runningProcessesSelectionList);
            Name = "Form1";
            Text = "Game Shuffler";
            ResumeLayout(false);
            PerformLayout();
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
        private Label label7;
    }
}