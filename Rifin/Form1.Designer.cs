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
            this.StartSteam_Button = new System.Windows.Forms.CheckBox();
            this.Advanced_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.AddObjectButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.haarObjects_ListBox = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.hogObjects_ListBox = new System.Windows.Forms.CheckedListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addDescriptorControl1 = new Rifin.Forms.AddDescriptorControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Main_PictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_PictureBox
            // 
            this.Main_PictureBox.Location = new System.Drawing.Point(676, 12);
            this.Main_PictureBox.Name = "Main_PictureBox";
            this.Main_PictureBox.Size = new System.Drawing.Size(640, 480);
            this.Main_PictureBox.TabIndex = 4;
            this.Main_PictureBox.TabStop = false;
            // 
            // StartSteam_Button
            // 
            this.StartSteam_Button.Appearance = System.Windows.Forms.Appearance.Button;
            this.StartSteam_Button.AutoSize = true;
            this.StartSteam_Button.BackColor = System.Drawing.Color.Lime;
            this.StartSteam_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartSteam_Button.Location = new System.Drawing.Point(12, 12);
            this.StartSteam_Button.MinimumSize = new System.Drawing.Size(50, 50);
            this.StartSteam_Button.Name = "StartSteam_Button";
            this.StartSteam_Button.Size = new System.Drawing.Size(90, 50);
            this.StartSteam_Button.TabIndex = 6;
            this.StartSteam_Button.Text = "Start Video";
            this.StartSteam_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StartSteam_Button.UseVisualStyleBackColor = false;
            this.StartSteam_Button.CheckedChanged += new System.EventHandler(this.StartSteam_Button_CheckedChanged);
            // 
            // Advanced_Button
            // 
            this.Advanced_Button.Location = new System.Drawing.Point(130, 27);
            this.Advanced_Button.Name = "Advanced_Button";
            this.Advanced_Button.Size = new System.Drawing.Size(75, 23);
            this.Advanced_Button.TabIndex = 11;
            this.Advanced_Button.Text = "Advanced Controls";
            this.Advanced_Button.UseVisualStyleBackColor = true;
            this.Advanced_Button.Click += new System.EventHandler(this.Advanced_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Objects List";
            // 
            // AddObjectButton
            // 
            this.AddObjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddObjectButton.Location = new System.Drawing.Point(115, 141);
            this.AddObjectButton.Name = "AddObjectButton";
            this.AddObjectButton.Size = new System.Drawing.Size(108, 60);
            this.AddObjectButton.TabIndex = 15;
            this.AddObjectButton.Text = "Remove selected objects";
            this.AddObjectButton.UseVisualStyleBackColor = true;
            this.AddObjectButton.Click += new System.EventHandler(this.AddObjectButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.addDescriptorControl1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 77);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(479, 415);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.haarObjects_ListBox);
            this.groupBox1.Controls.Add(this.AddObjectButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HAAR";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // haarObjects_ListBox
            // 
            this.haarObjects_ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.haarObjects_ListBox.FormattingEnabled = true;
            this.haarObjects_ListBox.Location = new System.Drawing.Point(9, 47);
            this.haarObjects_ListBox.Name = "haarObjects_ListBox";
            this.haarObjects_ListBox.Size = new System.Drawing.Size(125, 84);
            this.haarObjects_ListBox.Sorted = true;
            this.haarObjects_ListBox.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(9, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 16;
            this.button1.Text = "Add object";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.hogObjects_ListBox);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(238, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 225);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HOG";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(9, 141);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 16;
            this.button2.Text = "Add object";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // hogObjects_ListBox
            // 
            this.hogObjects_ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hogObjects_ListBox.FormattingEnabled = true;
            this.hogObjects_ListBox.Location = new System.Drawing.Point(9, 47);
            this.hogObjects_ListBox.Name = "hogObjects_ListBox";
            this.hogObjects_ListBox.Size = new System.Drawing.Size(138, 84);
            this.hogObjects_ListBox.Sorted = true;
            this.hogObjects_ListBox.TabIndex = 15;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(115, 141);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 60);
            this.button3.TabIndex = 15;
            this.button3.Text = "Remove selected objects";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Objects List";
            // 
            // addDescriptorControl1
            // 
            this.addDescriptorControl1.Location = new System.Drawing.Point(3, 234);
            this.addDescriptorControl1.Name = "addDescriptorControl1";
            this.addDescriptorControl1.ObjectName = null;
            this.addDescriptorControl1.Size = new System.Drawing.Size(359, 167);
            this.addDescriptorControl1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(12, 517);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 152);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Stats";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 681);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Advanced_Button);
            this.Controls.Add(this.StartSteam_Button);
            this.Controls.Add(this.Main_PictureBox);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Main_PictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Main_PictureBox;
        private System.Windows.Forms.CheckBox StartSteam_Button;
        private System.Windows.Forms.Button Advanced_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddObjectButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox haarObjects_ListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox hogObjects_ListBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private Forms.AddDescriptorControl addDescriptorControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

