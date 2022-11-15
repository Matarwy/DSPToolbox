namespace DSPUI.ComponentsAttriutesEditor
{
    partial class FileInputSignal
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
            this.label1 = new System.Windows.Forms.Label();
            this.FilePathTXTBX = new System.Windows.Forms.TextBox();
            this.ChangeFileBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PlotSignalBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Path:";
            // 
            // FilePathTXTBX
            // 
            this.FilePathTXTBX.Location = new System.Drawing.Point(93, 25);
            this.FilePathTXTBX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FilePathTXTBX.Name = "FilePathTXTBX";
            this.FilePathTXTBX.Size = new System.Drawing.Size(625, 22);
            this.FilePathTXTBX.TabIndex = 1;
            this.FilePathTXTBX.TextChanged += new System.EventHandler(this.FilePathTXTBX_TextChanged);
            // 
            // ChangeFileBTN
            // 
            this.ChangeFileBTN.Location = new System.Drawing.Point(93, 58);
            this.ChangeFileBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChangeFileBTN.Name = "ChangeFileBTN";
            this.ChangeFileBTN.Size = new System.Drawing.Size(143, 28);
            this.ChangeFileBTN.TabIndex = 2;
            this.ChangeFileBTN.Text = "New Signal File";
            this.ChangeFileBTN.UseVisualStyleBackColor = true;
            this.ChangeFileBTN.Click += new System.EventHandler(this.ChangeFileBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Signal";
            // 
            // PlotSignalBTN
            // 
            this.PlotSignalBTN.Location = new System.Drawing.Point(93, 113);
            this.PlotSignalBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PlotSignalBTN.Name = "PlotSignalBTN";
            this.PlotSignalBTN.Size = new System.Drawing.Size(100, 28);
            this.PlotSignalBTN.TabIndex = 4;
            this.PlotSignalBTN.Text = "Plot";
            this.PlotSignalBTN.UseVisualStyleBackColor = true;
            this.PlotSignalBTN.Click += new System.EventHandler(this.PlotSignalBTN_Click);
            // 
            // FileInputSignal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 164);
            this.Controls.Add(this.PlotSignalBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChangeFileBTN);
            this.Controls.Add(this.FilePathTXTBX);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileInputSignal";
            this.Text = "Load File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FilePathTXTBX;
        private System.Windows.Forms.Button ChangeFileBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PlotSignalBTN;

    }
}