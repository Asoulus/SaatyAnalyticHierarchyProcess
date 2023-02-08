namespace Kryterium
{
    partial class Form5
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
            this.names_pnl = new System.Windows.Forms.Panel();
            this.dds_pnl = new System.Windows.Forms.Panel();
            this.rezults_pnl = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // names_pnl
            // 
            this.names_pnl.Location = new System.Drawing.Point(12, 70);
            this.names_pnl.Name = "names_pnl";
            this.names_pnl.Size = new System.Drawing.Size(180, 600);
            this.names_pnl.TabIndex = 0;
            // 
            // dds_pnl
            // 
            this.dds_pnl.Location = new System.Drawing.Point(198, 12);
            this.dds_pnl.Name = "dds_pnl";
            this.dds_pnl.Size = new System.Drawing.Size(777, 52);
            this.dds_pnl.TabIndex = 1;
            // 
            // rezults_pnl
            // 
            this.rezults_pnl.Location = new System.Drawing.Point(198, 70);
            this.rezults_pnl.Name = "rezults_pnl";
            this.rezults_pnl.Size = new System.Drawing.Size(777, 600);
            this.rezults_pnl.TabIndex = 2;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 682);
            this.Controls.Add(this.rezults_pnl);
            this.Controls.Add(this.dds_pnl);
            this.Controls.Add(this.names_pnl);
            this.Name = "Form5";
            this.Text = "Rezults";
            this.ResumeLayout(false);

        }

        #endregion

        private Panel names_pnl;
        private Panel dds_pnl;
        private Panel rezults_pnl;
    }
}