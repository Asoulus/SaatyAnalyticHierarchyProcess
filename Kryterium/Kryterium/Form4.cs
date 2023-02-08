using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kryterium
{
    public partial class Form4 : Form
    {
        public int CriteriaAmount { get; set; }

        public List<TextBox> alternativesTextBoxes = new List<TextBox>();
        private List<string> criteriaNames = new List<string>();
        public List<List<double>> tableValues = new List<List<double>>();


        public Form4(List<string> criteriaNames)
        {
            InitializeComponent();
            names_lbl.Hide();
            saveNames_btn.Hide();
            this.criteriaNames = criteriaNames;
        }

        private void alternatives_btn_Click(object sender, EventArgs e)
        {
            if (CheckAlternativesNameTextBoxes())
            {
                alternatives_btn.Enabled = false;
                alternatives_tb.Enabled = false;

                ShowAlternativesNames();
            }
        }

        private void ShowAlternativesNames()
        {
            names_lbl.Show();

            for (int i = 0; i < CriteriaAmount; i++)
            {
                TextBox tmp = new TextBox();
                this.alternatives_pnl.Controls.Add(tmp);

                tmp.Top = 40 * i;
                tmp.Left = 5;

                tmp.MinimumSize = new Size(30, 30);
                tmp.Width = 160;
                tmp.Height = 50;

                tmp.Font = new Font(tmp.Font.FontFamily, 15);
                tmp.MaxLength = 15;
                alternativesTextBoxes.Add(tmp);

                List<double> tmpList = new List<double>();
                tableValues.Add(tmpList);
            }

            this.alternatives_pnl.Controls.Add(saveNames_btn);
            saveNames_btn.Top = 40 * CriteriaAmount;
            saveNames_btn.Left = 5;

            saveNames_btn.Show();
        }

        public bool CheckAlternativesNameTextBoxes()
        {
            if (alternatives_tb.Text.Equals(""))
            {
                return false;
            }


            CriteriaAmount = ConvertToInt(alternatives_tb.Text);

            if (CriteriaAmount > 10 || CriteriaAmount < 2)
            {
                return false;
            }

            return true;
        }

        private int ConvertToInt(string input)
        {
            int tmp = 0;

            try
            {
                tmp = Int32.Parse(input);
            }
            catch (Exception)
            {
                //TODO print error message?
                //throw;
            }

            return tmp;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            DataColumn dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Alternative Name";
            dtColumn.Caption = "Alternative Name";
            dtColumn.ReadOnly = true;
            dtColumn.Unique = true;
            dt.Columns.Add(dtColumn);

            foreach (var criteria in criteriaNames)
            {
                DataColumn tmpColumn = new DataColumn();
                tmpColumn.DataType = typeof(double);
                tmpColumn.ColumnName = criteria;
                tmpColumn.Caption = criteria;
                tmpColumn.ReadOnly = false;
                tmpColumn.Unique = false;
                dt.Columns.Add(tmpColumn);
            }

            foreach (var alternative in alternativesTextBoxes)
            {
                dt.Rows.Add(alternative.Text);
            }

            alternatives_dgv.DataSource = dt;
            alternatives_dgv.AllowUserToAddRows = false; 
            alternatives_dgv.AllowUserToDeleteRows = false;
        }

        private void saveValues_btn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rw in this.alternatives_dgv.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        return;
                    }
                }
            }

            for (int rows = 0; rows < alternatives_dgv.Rows.Count; rows++)
            {
                for (int col = 1; col < alternatives_dgv.Rows[rows].Cells.Count; col++)
                {
                    string value = alternatives_dgv.Rows[rows].Cells[col].Value.ToString();

                    var converted = ConvertToDouble(value);

                    if (!converted.Item1)
                    {
                        ClearInputSoFar();
                        return;
                    }

                    tableValues[rows].Add(converted.Item2);

                }
            }

            this.Close();

        }

        private void ClearInputSoFar() // prevention from inputing same values multiple times
        {
            for (int i = 0; i < tableValues.Count; i++)
            {
                tableValues[i].Clear(); 
            }
        }

        private (bool, double) ConvertToDouble(string input)
        {
            double tmp = 0;
            bool success = false;

            try
            {
                tmp = Double.Parse(input);
                success = true;
            }
            catch (Exception)
            {
                //TODO print error message?
                //throw;
                success = false;
            }

            return (success, tmp);
        }
    }
}
