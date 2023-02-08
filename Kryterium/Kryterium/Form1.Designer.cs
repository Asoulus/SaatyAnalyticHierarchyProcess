namespace Kryterium
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
            this.matrix_pnl = new System.Windows.Forms.Panel();
            this.criteriaAmount_tb = new System.Windows.Forms.TextBox();
            this.liczba_kryteriow_lbl = new System.Windows.Forms.Label();
            this.confirm_btn = new System.Windows.Forms.Button();
            this.leftLabel_pnl = new System.Windows.Forms.Panel();
            this.criteria_pnl = new System.Windows.Forms.Panel();
            this.criteriaAlphas_pnl = new System.Windows.Forms.Panel();
            this.names_lbl = new System.Windows.Forms.Label();
            this.criteriaNames_btn = new System.Windows.Forms.Button();
            this.topLabel_pnl = new System.Windows.Forms.Panel();
            this.calculate_btn = new System.Windows.Forms.Button();
            this.criteriaAlphas_lbl = new System.Windows.Forms.Label();
            this.matrixOperation_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // matrix_pnl
            // 
            this.matrix_pnl.Location = new System.Drawing.Point(485, 215);
            this.matrix_pnl.Name = "matrix_pnl";
            this.matrix_pnl.Size = new System.Drawing.Size(493, 497);
            this.matrix_pnl.TabIndex = 0;
            // 
            // criteriaAmount_tb
            // 
            this.criteriaAmount_tb.Location = new System.Drawing.Point(14, 33);
            this.criteriaAmount_tb.Name = "criteriaAmount_tb";
            this.criteriaAmount_tb.Size = new System.Drawing.Size(100, 23);
            this.criteriaAmount_tb.TabIndex = 1;
            this.criteriaAmount_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.liczbaKryteriow_tb_KeyPress);
            // 
            // liczba_kryteriow_lbl
            // 
            this.liczba_kryteriow_lbl.AutoSize = true;
            this.liczba_kryteriow_lbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.liczba_kryteriow_lbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.liczba_kryteriow_lbl.Location = new System.Drawing.Point(15, 10);
            this.liczba_kryteriow_lbl.Name = "liczba_kryteriow_lbl";
            this.liczba_kryteriow_lbl.Size = new System.Drawing.Size(115, 20);
            this.liczba_kryteriow_lbl.TabIndex = 2;
            this.liczba_kryteriow_lbl.Text = "Criteria amount:";
            // 
            // confirm_btn
            // 
            this.confirm_btn.Location = new System.Drawing.Point(120, 33);
            this.confirm_btn.Name = "confirm_btn";
            this.confirm_btn.Size = new System.Drawing.Size(75, 23);
            this.confirm_btn.TabIndex = 3;
            this.confirm_btn.Text = "Confirm";
            this.confirm_btn.UseVisualStyleBackColor = true;
            this.confirm_btn.Click += new System.EventHandler(this.confirm_Click);
            // 
            // leftLabel_pnl
            // 
            this.leftLabel_pnl.Location = new System.Drawing.Point(279, 215);
            this.leftLabel_pnl.Name = "leftLabel_pnl";
            this.leftLabel_pnl.Size = new System.Drawing.Size(200, 497);
            this.leftLabel_pnl.TabIndex = 4;
            // 
            // criteria_pnl
            // 
            this.criteria_pnl.Location = new System.Drawing.Point(14, 106);
            this.criteria_pnl.Name = "criteria_pnl";
            this.criteria_pnl.Size = new System.Drawing.Size(165, 435);
            this.criteria_pnl.TabIndex = 6;
            // 
            // criteriaAlphas_pnl
            // 
            this.criteriaAlphas_pnl.Location = new System.Drawing.Point(185, 106);
            this.criteriaAlphas_pnl.Name = "criteriaAlphas_pnl";
            this.criteriaAlphas_pnl.Size = new System.Drawing.Size(88, 435);
            this.criteriaAlphas_pnl.TabIndex = 13;
            // 
            // names_lbl
            // 
            this.names_lbl.AutoSize = true;
            this.names_lbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.names_lbl.Location = new System.Drawing.Point(15, 82);
            this.names_lbl.Name = "names_lbl";
            this.names_lbl.Size = new System.Drawing.Size(143, 20);
            this.names_lbl.TabIndex = 7;
            this.names_lbl.Text = "Enter criteria names:";
            // 
            // criteriaNames_btn
            // 
            this.criteriaNames_btn.Location = new System.Drawing.Point(99, 547);
            this.criteriaNames_btn.Name = "criteriaNames_btn";
            this.criteriaNames_btn.Size = new System.Drawing.Size(80, 23);
            this.criteriaNames_btn.TabIndex = 8;
            this.criteriaNames_btn.Text = "Save Criteria";
            this.criteriaNames_btn.UseVisualStyleBackColor = true;
            this.criteriaNames_btn.Click += new System.EventHandler(this.confirmNames_btn_Click);
            // 
            // topLabel_pnl
            // 
            this.topLabel_pnl.Location = new System.Drawing.Point(485, 4);
            this.topLabel_pnl.Name = "topLabel_pnl";
            this.topLabel_pnl.Size = new System.Drawing.Size(493, 205);
            this.topLabel_pnl.TabIndex = 9;
            // 
            // calculate_btn
            // 
            this.calculate_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.calculate_btn.Location = new System.Drawing.Point(388, 179);
            this.calculate_btn.Name = "calculate_btn";
            this.calculate_btn.Size = new System.Drawing.Size(91, 30);
            this.calculate_btn.TabIndex = 10;
            this.calculate_btn.Text = "Calculate";
            this.calculate_btn.UseVisualStyleBackColor = true;
            this.calculate_btn.Click += new System.EventHandler(this.calculate_btn_Click);
            // 
            // criteriaAlphas_lbl
            // 
            this.criteriaAlphas_lbl.AutoSize = true;
            this.criteriaAlphas_lbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.criteriaAlphas_lbl.Location = new System.Drawing.Point(185, 83);
            this.criteriaAlphas_lbl.Name = "criteriaAlphas_lbl";
            this.criteriaAlphas_lbl.Size = new System.Drawing.Size(57, 20);
            this.criteriaAlphas_lbl.TabIndex = 14;
            this.criteriaAlphas_lbl.Text = "Alphas:";
            // 
            // matrixOperation_lbl
            // 
            this.matrixOperation_lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.matrixOperation_lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.matrixOperation_lbl.Location = new System.Drawing.Point(279, 106);
            this.matrixOperation_lbl.Name = "matrixOperation_lbl";
            this.matrixOperation_lbl.Size = new System.Drawing.Size(200, 75);
            this.matrixOperation_lbl.TabIndex = 19;
            this.matrixOperation_lbl.Text = "Current Operation Info";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 724);
            this.Controls.Add(this.matrixOperation_lbl);
            this.Controls.Add(this.criteriaAlphas_lbl);
            this.Controls.Add(this.criteriaAlphas_pnl);
            this.Controls.Add(this.calculate_btn);
            this.Controls.Add(this.topLabel_pnl);
            this.Controls.Add(this.criteriaNames_btn);
            this.Controls.Add(this.names_lbl);
            this.Controls.Add(this.criteria_pnl);
            this.Controls.Add(this.leftLabel_pnl);
            this.Controls.Add(this.confirm_btn);
            this.Controls.Add(this.liczba_kryteriow_lbl);
            this.Controls.Add(this.criteriaAmount_tb);
            this.Controls.Add(this.matrix_pnl);
            this.Name = "Form1";
            this.Text = "Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel matrix_pnl;
        private TextBox criteriaAmount_tb;
        private Label liczba_kryteriow_lbl;
        private Button confirm_btn;
        private Panel leftLabel_pnl;
        private Panel criteria_pnl;
        private Label names_lbl;
        private Button criteriaNames_btn;
        private Panel topLabel_pnl;
        private Button calculate_btn;
        private Panel criteriaAlphas_pnl;
        private Label criteriaAlphas_lbl;
        private Label matrixOperation_lbl;
    }
}