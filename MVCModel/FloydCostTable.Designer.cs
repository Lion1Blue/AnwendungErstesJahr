namespace WinFormMVC.Model
{
    partial class FloydCostTable
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
            this.pictureBoxFloydCostTable = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFloydCostTable)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFloydCostTable
            // 
            this.pictureBoxFloydCostTable.BackColor = System.Drawing.Color.White;
            this.pictureBoxFloydCostTable.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxFloydCostTable.Name = "pictureBoxFloydCostTable";
            this.pictureBoxFloydCostTable.Size = new System.Drawing.Size(480, 480);
            this.pictureBoxFloydCostTable.TabIndex = 1;
            this.pictureBoxFloydCostTable.TabStop = false;
            // 
            // FloydCostTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 504);
            this.Controls.Add(this.pictureBoxFloydCostTable);
            this.Name = "FloydCostTable";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFloydCostTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFloydCostTable;
    }
}