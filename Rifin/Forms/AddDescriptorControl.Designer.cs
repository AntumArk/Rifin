namespace Rifin.Forms
{
    partial class AddDescriptorControl
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
            this.NewObjectTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.type_Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CloseControlButton = new System.Windows.Forms.Button();
            this.SaveNewObjectButton = new System.Windows.Forms.Button();
            this.LoadedImagesLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoadResourcesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewObjectTextBox
            // 
            this.NewObjectTextBox.Location = new System.Drawing.Point(122, 3);
            this.NewObjectTextBox.Name = "NewObjectTextBox";
            this.NewObjectTextBox.Size = new System.Drawing.Size(100, 20);
            this.NewObjectTextBox.TabIndex = 0;
            this.NewObjectTextBox.TextChanged += new System.EventHandler(this.NewObjectTextBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.type_Label);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CloseControlButton);
            this.panel1.Controls.Add(this.SaveNewObjectButton);
            this.panel1.Controls.Add(this.LoadedImagesLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LoadResourcesButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.NewObjectTextBox);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 105);
            this.panel1.TabIndex = 1;
            // 
            // type_Label
            // 
            this.type_Label.AutoSize = true;
            this.type_Label.Location = new System.Drawing.Point(213, 40);
            this.type_Label.Name = "type_Label";
            this.type_Label.Size = new System.Drawing.Size(31, 13);
            this.type_Label.TabIndex = 11;
            this.type_Label.Text = "none";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Descriptor type:";
            // 
            // CloseControlButton
            // 
            this.CloseControlButton.Location = new System.Drawing.Point(245, 3);
            this.CloseControlButton.Name = "CloseControlButton";
            this.CloseControlButton.Size = new System.Drawing.Size(25, 24);
            this.CloseControlButton.TabIndex = 9;
            this.CloseControlButton.Text = "X";
            this.CloseControlButton.UseVisualStyleBackColor = true;
            this.CloseControlButton.Click += new System.EventHandler(this.CloseControlButton_Click);
            // 
            // SaveNewObjectButton
            // 
            this.SaveNewObjectButton.Location = new System.Drawing.Point(8, 74);
            this.SaveNewObjectButton.Name = "SaveNewObjectButton";
            this.SaveNewObjectButton.Size = new System.Drawing.Size(262, 23);
            this.SaveNewObjectButton.TabIndex = 8;
            this.SaveNewObjectButton.Text = "Save";
            this.SaveNewObjectButton.UseVisualStyleBackColor = true;
            this.SaveNewObjectButton.Click += new System.EventHandler(this.SaveNewObjectButton_Click);
            // 
            // LoadedImagesLabel
            // 
            this.LoadedImagesLabel.AutoSize = true;
            this.LoadedImagesLabel.Location = new System.Drawing.Point(213, 27);
            this.LoadedImagesLabel.Name = "LoadedImagesLabel";
            this.LoadedImagesLabel.Size = new System.Drawing.Size(31, 13);
            this.LoadedImagesLabel.TabIndex = 6;
            this.LoadedImagesLabel.Text = "none";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descriptor loaded:";
            // 
            // LoadResourcesButton
            // 
            this.LoadResourcesButton.Location = new System.Drawing.Point(8, 27);
            this.LoadResourcesButton.Name = "LoadResourcesButton";
            this.LoadResourcesButton.Size = new System.Drawing.Size(100, 41);
            this.LoadResourcesButton.TabIndex = 3;
            this.LoadResourcesButton.Text = "Select descriptor";
            this.LoadResourcesButton.UseVisualStyleBackColor = true;
            this.LoadResourcesButton.Click += new System.EventHandler(this.LoadResourcesButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Object Name";
            // 
            // AddDescriptorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AddDescriptorControl";
            this.Size = new System.Drawing.Size(286, 110);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox NewObjectTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CloseControlButton;
        private System.Windows.Forms.Button SaveNewObjectButton;
        private System.Windows.Forms.Label LoadedImagesLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LoadResourcesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label type_Label;
        private System.Windows.Forms.Label label3;
    }
}
