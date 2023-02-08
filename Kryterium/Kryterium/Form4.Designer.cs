namespace Kryterium
{
    partial class Form4
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
            this.alternatives_tb = new System.Windows.Forms.TextBox();
            this.alternatives_lbl = new System.Windows.Forms.Label();
            this.alternatives_btn = new System.Windows.Forms.Button();
            this.alternatives_pnl = new System.Windows.Forms.Panel();
            this.names_lbl = new System.Windows.Forms.Label();
            this.saveNames_btn = new System.Windows.Forms.Button();
            this.alternatives_dgv = new System.Windows.Forms.DataGridView();
            this.saveValues_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.alternatives_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // alternatives_tb
            // 
            this.alternatives_tb.Location = new System.Drawing.Point(12, 33);
            this.alternatives_tb.Name = "alternatives_tb";
            this.alternatives_tb.Size = new System.Drawing.Size(100, 23);
            this.alternatives_tb.TabIndex = 0;
            // 
            // alternatives_lbl
            // 
            this.alternatives_lbl.AutoSize = true;
            this.alternatives_lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.alternatives_lbl.Location = new System.Drawing.Point(12, 9);
            this.alternatives_lbl.Name = "alternatives_lbl";
            this.alternatives_lbl.Size = new System.Drawing.Size(152, 21);
            this.alternatives_lbl.TabIndex = 1;
            this.alternatives_lbl.Text = "Alternatives Amount";
            // 
            // alternatives_btn
            // 
            this.alternatives_btn.Location = new System.Drawing.Point(118, 33);
            this.alternatives_btn.Name = "alternatives_btn";
            this.alternatives_btn.Size = new System.Drawing.Size(75, 23);
            this.alternatives_btn.TabIndex = 2;
            this.alternatives_btn.Text = "Confirm";
            this.alternatives_btn.UseVisualStyleBackColor = true;
            this.alternatives_btn.Click += new System.EventHandler(this.alternatives_btn_Click);
            // 
            // alternatives_pnl
            // 
            this.alternatives_pnl.Location = new System.Drawing.Point(12, 102);
            this.alternatives_pnl.Name = "alternatives_pnl";
            this.alternatives_pnl.Size = new System.Drawing.Size(200, 454);
            this.alternatives_pnl.TabIndex = 3;
            // 
            // names_lbl
            // 
            this.names_lbl.AutoSize = true;
            this.names_lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.names_lbl.Location = new System.Drawing.Point(12, 78);
            this.names_lbl.Name = "names_lbl";
            this.names_lbl.Size = new System.Drawing.Size(185, 21);
            this.names_lbl.TabIndex = 4;
            this.names_lbl.Text = "Enter Alternatives Names";
            // 
            // saveNames_btn
            // 
            this.saveNames_btn.Location = new System.Drawing.Point(118, 562);
            this.saveNames_btn.Name = "saveNames_btn";
            this.saveNames_btn.Size = new System.Drawing.Size(94, 23);
            this.saveNames_btn.TabIndex = 5;
            this.saveNames_btn.Text = "Save Names";
            this.saveNames_btn.UseVisualStyleBackColor = true;
            this.saveNames_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // alternatives_dgv
            // 
            this.alternatives_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.alternatives_dgv.Location = new System.Drawing.Point(279, 9);
            this.alternatives_dgv.Name = "alternatives_dgv";
            this.alternatives_dgv.RowTemplate.Height = 25;
            this.alternatives_dgv.Size = new System.Drawing.Size(689, 547);
            this.alternatives_dgv.TabIndex = 6;
            // 
            // saveValues_btn
            // 
            this.saveValues_btn.Location = new System.Drawing.Point(885, 562);
            this.saveValues_btn.Name = "saveValues_btn";
            this.saveValues_btn.Size = new System.Drawing.Size(83, 23);
            this.saveValues_btn.TabIndex = 7;
            this.saveValues_btn.Text = "Save Values";
            this.saveValues_btn.UseVisualStyleBackColor = true;
            this.saveValues_btn.Click += new System.EventHandler(this.saveValues_btn_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 597);
            this.Controls.Add(this.saveValues_btn);
            this.Controls.Add(this.alternatives_dgv);
            this.Controls.Add(this.saveNames_btn);
            this.Controls.Add(this.names_lbl);
            this.Controls.Add(this.alternatives_pnl);
            this.Controls.Add(this.alternatives_btn);
            this.Controls.Add(this.alternatives_lbl);
            this.Controls.Add(this.alternatives_tb);
            this.Name = "Form4";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.alternatives_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox alternatives_tb;
        private Label alternatives_lbl;
        private Button alternatives_btn;
        private Panel alternatives_pnl;
        private Label names_lbl;
        private Button saveNames_btn;
        private DataGridView alternatives_dgv;
        private Button saveValues_btn;
    }
}