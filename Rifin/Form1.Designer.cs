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
            this.haarRemove_Button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.haarAdd_Button = new System.Windows.Forms.Button();
            this.haarObjects_ListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.hogAdd_Button = new System.Windows.Forms.Button();
            this.hogObjects_ListBox = new System.Windows.Forms.CheckedListBox();
            this.hogRemove_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.addDescriptorControl1 = new Rifin.Forms.AddDescriptorControl();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
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
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Object List";
            // 
            // haarRemove_Button
            // 
            this.haarRemove_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.haarRemove_Button.Location = new System.Drawing.Point(115, 141);
            this.haarRemove_Button.Name = "haarRemove_Button";
            this.haarRemove_Button.Size = new System.Drawing.Size(108, 60);
            this.haarRemove_Button.TabIndex = 15;
            this.haarRemove_Button.Text = "Remove selected objects";
            this.haarRemove_Button.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.addDescriptorControl1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 96);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(479, 415);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.haarAdd_Button);
            this.groupBox1.Controls.Add(this.haarObjects_ListBox);
            this.groupBox1.Controls.Add(this.haarRemove_Button);
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
            // haarAdd_Button
            // 
            this.haarAdd_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.haarAdd_Button.Location = new System.Drawing.Point(9, 141);
            this.haarAdd_Button.Name = "haarAdd_Button";
            this.haarAdd_Button.Size = new System.Drawing.Size(100, 28);
            this.haarAdd_Button.TabIndex = 16;
            this.haarAdd_Button.Text = "Add object";
            this.haarAdd_Button.UseVisualStyleBackColor = true;
            this.haarAdd_Button.Click += new System.EventHandler(this.haarAdd_Button_Click);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.hogAdd_Button);
            this.groupBox2.Controls.Add(this.hogObjects_ListBox);
            this.groupBox2.Controls.Add(this.hogRemove_Button);
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
            // hogAdd_Button
            // 
            this.hogAdd_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hogAdd_Button.Location = new System.Drawing.Point(9, 141);
            this.hogAdd_Button.Name = "hogAdd_Button";
            this.hogAdd_Button.Size = new System.Drawing.Size(100, 28);
            this.hogAdd_Button.TabIndex = 16;
            this.hogAdd_Button.Text = "Add object";
            this.hogAdd_Button.UseVisualStyleBackColor = true;
            this.hogAdd_Button.Click += new System.EventHandler(this.hogAdd_Button_Click);
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
            // hogRemove_Button
            // 
            this.hogRemove_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hogRemove_Button.Location = new System.Drawing.Point(115, 141);
            this.hogRemove_Button.Name = "hogRemove_Button";
            this.hogRemove_Button.Size = new System.Drawing.Size(108, 60);
            this.hogRemove_Button.TabIndex = 15;
            this.hogRemove_Button.Text = "Remove selected objects";
            this.hogRemove_Button.UseVisualStyleBackColor = true;
            this.hogRemove_Button.Click += new System.EventHandler(this.hogRemove_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Object List";
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
            this.groupBox3.Controls.Add(this.logBox);
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(12, 517);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(884, 152);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Stats";
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(238, 23);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(495, 96);
            this.logBox.TabIndex = 19;
            this.logBox.Text = "";
            // 
            // addDescriptorControl1
            // 
            this.addDescriptorControl1.DescriptorPath = null;
            this.addDescriptorControl1.LoadingSuccessful = false;
            this.addDescriptorControl1.Location = new System.Drawing.Point(3, 234);
            this.addDescriptorControl1.Name = "addDescriptorControl1";
            this.addDescriptorControl1.ObjectName = null;
            this.addDescriptorControl1.ObjectType = 0;
            this.addDescriptorControl1.Size = new System.Drawing.Size(286, 110);
            this.addDescriptorControl1.TabIndex = 2;
            this.addDescriptorControl1.VisibleChanged += new System.EventHandler(this.addDescriptorControl1_VisibleChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 69);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 17);
            this.radioButton1.TabIndex = 20;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Use HAAR";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(250, 69);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 17);
            this.radioButton2.TabIndex = 21;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Use HOG";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 681);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
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
        private System.Windows.Forms.Button haarRemove_Button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox haarObjects_ListBox;
        private System.Windows.Forms.Button haarAdd_Button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button hogAdd_Button;
        private System.Windows.Forms.CheckedListBox hogObjects_ListBox;
        private System.Windows.Forms.Button hogRemove_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox logBox;
        private Forms.AddDescriptorControl addDescriptorControl1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

