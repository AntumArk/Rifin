namespace Rifin.Forms
{
    partial class SongControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.SongProgress_Label = new System.Windows.Forms.Label();
            this.ResetSong_Button = new System.Windows.Forms.Button();
            this.SongPlay_Button = new System.Windows.Forms.CheckBox();
            this.Song_TrackBar = new System.Windows.Forms.TrackBar();
            this.AddSong_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Song_TrackBar)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.Location = new System.Drawing.Point(73, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 178);
            this.panel1.TabIndex = 11;
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // SongControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SongControl";
            this.Size = new System.Drawing.Size(433, 252);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Song_TrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SongProgress_Label;
        private System.Windows.Forms.Button ResetSong_Button;
        private System.Windows.Forms.CheckBox SongPlay_Button;
        private System.Windows.Forms.TrackBar Song_TrackBar;
        private System.Windows.Forms.Button AddSong_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
