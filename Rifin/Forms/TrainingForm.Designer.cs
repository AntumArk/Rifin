namespace Rifin.Forms
{
    partial class TrainingForm
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Train_Button = new System.Windows.Forms.Button();
            this.NegDataFolder_Button = new System.Windows.Forms.Button();
            this.PosDataFolder_Button = new System.Windows.Forms.Button();
            this.TrainingType_ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PosCount_Label = new System.Windows.Forms.Label();
            this.NegCount_Label = new System.Windows.Forms.Label();
            this.AddItemButton = new System.Windows.Forms.Button();
            this.addDescriptorControl1 = new Rifin.Forms.AddDescriptorControl();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 234);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(307, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // Train_Button
            // 
            this.Train_Button.Location = new System.Drawing.Point(9, 205);
            this.Train_Button.Name = "Train_Button";
            this.Train_Button.Size = new System.Drawing.Size(75, 23);
            this.Train_Button.TabIndex = 6;
            this.Train_Button.Text = "Train";
            this.Train_Button.UseVisualStyleBackColor = true;
            this.Train_Button.Click += new System.EventHandler(this.Train_Button_ClickAsync);
            // 
            // NegDataFolder_Button
            // 
            this.NegDataFolder_Button.Location = new System.Drawing.Point(9, 132);
            this.NegDataFolder_Button.Name = "NegDataFolder_Button";
            this.NegDataFolder_Button.Size = new System.Drawing.Size(79, 67);
            this.NegDataFolder_Button.TabIndex = 5;
            this.NegDataFolder_Button.Text = "Select Negative Data folder";
            this.NegDataFolder_Button.UseVisualStyleBackColor = true;
            this.NegDataFolder_Button.Click += new System.EventHandler(this.NegDataFolder_Button_Click);
            // 
            // PosDataFolder_Button
            // 
            this.PosDataFolder_Button.Location = new System.Drawing.Point(9, 60);
            this.PosDataFolder_Button.Name = "PosDataFolder_Button";
            this.PosDataFolder_Button.Size = new System.Drawing.Size(79, 66);
            this.PosDataFolder_Button.TabIndex = 4;
            this.PosDataFolder_Button.Text = "Select Positive Data folder";
            this.PosDataFolder_Button.UseVisualStyleBackColor = true;
            this.PosDataFolder_Button.Click += new System.EventHandler(this.PosDataFolder_Button_Click);
            // 
            // TrainingType_ComboBox
            // 
            this.TrainingType_ComboBox.FormattingEnabled = true;
            this.TrainingType_ComboBox.Location = new System.Drawing.Point(12, 33);
            this.TrainingType_ComboBox.Name = "TrainingType_ComboBox";
            this.TrainingType_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.TrainingType_ComboBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select what to train";
            // 
            // PosCount_Label
            // 
            this.PosCount_Label.AutoSize = true;
            this.PosCount_Label.Location = new System.Drawing.Point(95, 61);
            this.PosCount_Label.Name = "PosCount_Label";
            this.PosCount_Label.Size = new System.Drawing.Size(88, 13);
            this.PosCount_Label.TabIndex = 10;
            this.PosCount_Label.Text = "Positive samples:";
            // 
            // NegCount_Label
            // 
            this.NegCount_Label.AutoSize = true;
            this.NegCount_Label.Location = new System.Drawing.Point(98, 78);
            this.NegCount_Label.Name = "NegCount_Label";
            this.NegCount_Label.Size = new System.Drawing.Size(94, 13);
            this.NegCount_Label.TabIndex = 11;
            this.NegCount_Label.Text = "Negative samples:";
            // 
            // AddItemButton
            // 
            this.AddItemButton.Location = new System.Drawing.Point(140, 33);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(25, 23);
            this.AddItemButton.TabIndex = 12;
            this.AddItemButton.Text = "+";
            this.AddItemButton.UseVisualStyleBackColor = true;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // addDescriptorControl1
            // 
            this.addDescriptorControl1.Location = new System.Drawing.Point(9, 5);
            this.addDescriptorControl1.Name = "addDescriptorControl1";
            this.addDescriptorControl1.Size = new System.Drawing.Size(357, 252);
            this.addDescriptorControl1.TabIndex = 13;
            // 
            // TrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 259);
            this.Controls.Add(this.addDescriptorControl1);
            this.Controls.Add(this.AddItemButton);
            this.Controls.Add(this.NegCount_Label);
            this.Controls.Add(this.PosCount_Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TrainingType_ComboBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Train_Button);
            this.Controls.Add(this.NegDataFolder_Button);
            this.Controls.Add(this.PosDataFolder_Button);
            this.Name = "TrainingForm";
            this.Text = "TrainingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrainingForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button Train_Button;
        private System.Windows.Forms.Button NegDataFolder_Button;
        private System.Windows.Forms.Button PosDataFolder_Button;
        private System.Windows.Forms.ComboBox TrainingType_ComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PosCount_Label;
        private System.Windows.Forms.Label NegCount_Label;
        private System.Windows.Forms.Button AddItemButton;
        private AddDescriptorControl addDescriptorControl1;
    }
}