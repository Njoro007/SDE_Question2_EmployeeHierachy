namespace EmployeeHeirarchy
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCSVFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectCSVFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCSVFilePath);
            this.groupBox1.Controls.Add(this.btnSelectCSVFile);
            this.groupBox1.Location = new System.Drawing.Point(120, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 134);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File CSV Picker";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "File Path:";
            // 
            // txtCSVFilePath
            // 
            this.txtCSVFilePath.Location = new System.Drawing.Point(233, 66);
            this.txtCSVFilePath.Name = "txtCSVFilePath";
            this.txtCSVFilePath.Size = new System.Drawing.Size(272, 23);
            this.txtCSVFilePath.TabIndex = 2;
            // 
            // btnSelectCSVFile
            // 
            this.btnSelectCSVFile.Location = new System.Drawing.Point(16, 51);
            this.btnSelectCSVFile.Name = "btnSelectCSVFile";
            this.btnSelectCSVFile.Size = new System.Drawing.Size(154, 39);
            this.btnSelectCSVFile.TabIndex = 1;
            this.btnSelectCSVFile.Text = "Select CSV File";
            this.btnSelectCSVFile.UseVisualStyleBackColor = true;
            this.btnSelectCSVFile.Click += new System.EventHandler(this.btnSelectCSVFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(35, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(696, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = " .NET library assembly (DLL) for a system that handles the employee hierarchy";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Hierarchy";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCSVFilePath;
        private System.Windows.Forms.Button btnSelectCSVFile;
        private System.Windows.Forms.Label label1;
    }
}
