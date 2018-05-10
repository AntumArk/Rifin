namespace Rifin
{
    partial class MainWindow
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
            this.Main_PictureBox = new System.Windows.Forms.PictureBox();
            this.Side_PictureBox = new System.Windows.Forms.PictureBox();
            this.StartSteam_Button = new System.Windows.Forms.CheckBox();
            this.Training_Button = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SongProgress_Label = new System.Windows.Forms.Label();
            this.ResetSong_Button = new System.Windows.Forms.Button();
            this.SongPlay_Button = new System.Windows.Forms.CheckBox();
            this.Song_TrackBar = new System.Windows.Forms.TrackBar();
            this.AddSong_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Advanced_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.addDescriptorControl1 = new Rifin.Forms.AddDescriptorControl();
            this.AddObjectButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Main_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Side_PictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Song_TrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_PictureBox
            // 
            this.Main_PictureBox.Location = new System.Drawing.Point(208, 12);
            this.Main_PictureBox.Name = "Main_PictureBox";
            this.Main_PictureBox.Size = new System.Drawing.Size(640, 480);
            this.Main_PictureBox.TabIndex = 4;
            this.Main_PictureBox.TabStop = false;
            // 
            // Side_PictureBox
            // 
            this.Side_PictureBox.Location = new System.Drawing.Point(854, 12);
            this.Side_PictureBox.Name = "Side_PictureBox";
            this.Side_PictureBox.Size = new System.Drawing.Size(320, 240);
            this.Side_PictureBox.TabIndex = 5;
            this.Side_PictureBox.TabStop = false;
            // 
            // StartSteam_Button
            // 
            this.StartSteam_Button.Appearance = System.Windows.Forms.Appearance.Button;
            this.StartSteam_Button.AutoSize = true;
            this.StartSteam_Button.BackColor = System.Drawing.Color.Lime;
            this.StartSteam_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartSteam_Button.Location = new System.Drawing.Point(12, 12);
            this.StartSteam_Button.MinimumSize = new System.Drawing.Size(140, 140);
            this.StartSteam_Button.Name = "StartSteam_Button";
            this.StartSteam_Button.Size = new System.Drawing.Size(140, 140);
            this.StartSteam_Button.TabIndex = 6;
            this.StartSteam_Button.Text = "Start Video";
            this.StartSteam_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StartSteam_Button.UseVisualStyleBackColor = false;
            this.StartSteam_Button.CheckedChanged += new System.EventHandler(this.StartSteam_Button_CheckedChanged);
            // 
            // Training_Button
            // 
            this.Training_Button.Location = new System.Drawing.Point(13, 517);
            this.Training_Button.Name = "Training_Button";
            this.Training_Button.Size = new System.Drawing.Size(75, 23);
            this.Training_Button.TabIndex = 7;
            this.Training_Button.Text = "Training";
            this.Training_Button.UseVisualStyleBackColor = true;
            this.Training_Button.Click += new System.EventHandler(this.Training_Button_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Song Controls";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SongProgress_Label);
            this.panel1.Controls.Add(this.ResetSong_Button);
            this.panel1.Controls.Add(this.SongPlay_Button);
            this.panel1.Controls.Add(this.Song_TrackBar);
            this.panel1.Controls.Add(this.AddSong_Button);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(854, 270);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 222);
            this.panel1.TabIndex = 10;
            // 
            // SongProgress_Label
            // 
            this.SongProgress_Label.AutoSize = true;
            this.SongProgress_Label.Location = new System.Drawing.Point(127, 124);
            this.SongProgress_Label.Name = "SongProgress_Label";
            this.SongProgress_Label.Size = new System.Drawing.Size(29, 13);
            this.SongProgress_Label.TabIndex = 15;
            this.SongProgress_Label.Text = "Step";
            // 
            // ResetSong_Button
            // 
            this.ResetSong_Button.Location = new System.Drawing.Point(56, 88);
            this.ResetSong_Button.Name = "ResetSong_Button";
            this.ResetSong_Button.Size = new System.Drawing.Size(46, 23);
            this.ResetSong_Button.TabIndex = 14;
            this.ResetSong_Button.Text = "Reset";
            this.ResetSong_Button.UseVisualStyleBackColor = true;
            // 
            // SongPlay_Button
            // 
            this.SongPlay_Button.Appearance = System.Windows.Forms.Appearance.Button;
            this.SongPlay_Button.AutoSize = true;
            this.SongPlay_Button.BackColor = System.Drawing.Color.Lime;
            this.SongPlay_Button.Location = new System.Drawing.Point(12, 88);
            this.SongPlay_Button.Name = "SongPlay_Button";
            this.SongPlay_Button.Size = new System.Drawing.Size(37, 23);
            this.SongPlay_Button.TabIndex = 13;
            this.SongPlay_Button.Text = "Play";
            this.SongPlay_Button.UseVisualStyleBackColor = false;
            // 
            // Song_TrackBar
            // 
            this.Song_TrackBar.Location = new System.Drawing.Point(12, 143);
            this.Song_TrackBar.Name = "Song_TrackBar";
            this.Song_TrackBar.Size = new System.Drawing.Size(305, 45);
            this.Song_TrackBar.TabIndex = 12;
            // 
            // AddSong_Button
            // 
            this.AddSong_Button.Location = new System.Drawing.Point(140, 60);
            this.AddSong_Button.Name = "AddSong_Button";
            this.AddSong_Button.Size = new System.Drawing.Size(23, 23);
            this.AddSong_Button.TabIndex = 11;
            this.AddSong_Button.Text = "+";
            this.AddSong_Button.UseVisualStyleBackColor = true;
            this.AddSong_Button.Click += new System.EventHandler(this.AddSong_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Song Selection";
            // 
            // Advanced_Button
            // 
            this.Advanced_Button.Location = new System.Drawing.Point(13, 159);
            this.Advanced_Button.Name = "Advanced_Button";
            this.Advanced_Button.Size = new System.Drawing.Size(139, 23);
            this.Advanced_Button.TabIndex = 11;
            this.Advanced_Button.Text = "Advanced Controls";
            this.Advanced_Button.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(141, 517);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Objects List";
            // 
            // addDescriptorControl1
            // 
            this.addDescriptorControl1.Location = new System.Drawing.Point(290, 498);
            this.addDescriptorControl1.Name = "addDescriptorControl1";
            this.addDescriptorControl1.ObjectName = null;
            this.addDescriptorControl1.Size = new System.Drawing.Size(359, 167);
            this.addDescriptorControl1.TabIndex = 12;
            this.addDescriptorControl1.VisibleChanged += new System.EventHandler(this.addDescriptorControl1_VisibleChanged);
            // 
            // AddObjectButton
            // 
            this.AddObjectButton.Location = new System.Drawing.Point(265, 520);
            this.AddObjectButton.Name = "AddObjectButton";
            this.AddObjectButton.Size = new System.Drawing.Size(29, 23);
            this.AddObjectButton.TabIndex = 15;
            this.AddObjectButton.Text = "+";
            this.AddObjectButton.UseVisualStyleBackColor = true;
            this.AddObjectButton.Click += new System.EventHandler(this.AddObjectButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(145, 545);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.AddObjectButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addDescriptorControl1);
            this.Controls.Add(this.Advanced_Button);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Training_Button);
            this.Controls.Add(this.StartSteam_Button);
            this.Controls.Add(this.Side_PictureBox);
            this.Controls.Add(this.Main_PictureBox);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Main_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Side_PictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Song_TrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Main_PictureBox;
        private System.Windows.Forms.PictureBox Side_PictureBox;
        private System.Windows.Forms.CheckBox StartSteam_Button;
        private System.Windows.Forms.Button Training_Button;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ResetSong_Button;
        private System.Windows.Forms.CheckBox SongPlay_Button;
        private System.Windows.Forms.TrackBar Song_TrackBar;
        private System.Windows.Forms.Button AddSong_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SongProgress_Label;
        private System.Windows.Forms.Button Advanced_Button;
        private Forms.AddDescriptorControl addDescriptorControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddObjectButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

