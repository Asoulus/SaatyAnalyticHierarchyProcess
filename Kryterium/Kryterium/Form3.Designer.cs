namespace Kryterium
{
    partial class Form3
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
            this.type_pctrbx = new System.Windows.Forms.PictureBox();
            this.x_pnl = new System.Windows.Forms.Panel();
            this.save_btn = new System.Windows.Forms.Button();
            this.criteriaName_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.type_pctrbx)).BeginInit();
            this.SuspendLayout();
            // 
            // type_pctrbx
            // 
            this.type_pctrbx.Location = new System.Drawing.Point(12, 40);
            this.type_pctrbx.Name = "type_pctrbx";
            this.type_pctrbx.Size = new System.Drawing.Size(390, 267);
            this.type_pctrbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.type_pctrbx.TabIndex = 0;
            this.type_pctrbx.TabStop = false;
            // 
            // x_pnl
            // 
            this.x_pnl.Location = new System.Drawing.Point(408, 40);
            this.x_pnl.Name = "x_pnl";
            this.x_pnl.Size = new System.Drawing.Size(204, 222);
            this.x_pnl.TabIndex = 1;
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(503, 268);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(109, 30);
            this.save_btn.TabIndex = 2;
            this.save_btn.Text = "Save Values";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // criteriaName_lbl
            // 
            this.criteriaName_lbl.AutoSize = true;
            this.criteriaName_lbl.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.criteriaName_lbl.Location = new System.Drawing.Point(12, 9);
            this.criteriaName_lbl.Name = "criteriaName_lbl";
            this.criteriaName_lbl.Size = new System.Drawing.Size(52, 28);
            this.criteriaName_lbl.TabIndex = 3;
            this.criteriaName_lbl.Text = "Text";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 319);
            this.Controls.Add(this.criteriaName_lbl);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.x_pnl);
            this.Controls.Add(this.type_pctrbx);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.type_pctrbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox type_pctrbx;
        private Panel x_pnl;
        private Button save_btn;
        private Label criteriaName_lbl;
    }
}