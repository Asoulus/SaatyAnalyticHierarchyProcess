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
    public partial class Form5 : Form
    {
        private List<double> DD1 = new List<double>();
        private List<double> DD2 = new List<double>();
        private List<double> DD3 = new List<double>();

        private List<string> names = new List<string>();

        public Form5(List<string> names, List<double> DD1, List<double> DD2, List<double> DD3)
        {
            InitializeComponent();

            this.DD1 = DD1;
            this.DD2 = DD2; 
            this.DD3 = DD3;

            this.names = names;

            PrintRezults();
        }

        private void PrintRezults()
        {
            PrintNames();
            PrintDDs();
            PrintValues();
        }

        private void PrintNames()
        {
            for (int i = 0; i < names.Count; i++)
            {
                Label tmp = new Label();
                this.names_pnl.Controls.Add(tmp);

                tmp.Top = 50 * i;
                tmp.Left = 5;

                tmp.Font = new Font(tmp.Font.FontFamily, 15);

                tmp.Text = names[i];
            }
        }

        private void PrintDDs()
        {
            Label dd1 = new Label();
            Label dd2 = new Label();
            Label dd3 = new Label();

            this.dds_pnl.Controls.Add(dd1);
            dd1.Top = 0;
            dd1.Left = 5;
            dd1.Font = new Font(dd1.Font.FontFamily, 15);
            dd1.Text = "DD1";

            this.dds_pnl.Controls.Add(dd2);
            dd2.Top = 0;
            dd2.Left = 105;
            dd2.Font = new Font(dd1.Font.FontFamily, 15);
            dd2.Text = "DD2";

            this.dds_pnl.Controls.Add(dd3);
            dd3.Top = 0;
            dd3.Left = 205;
            dd3.Font = new Font(dd1.Font.FontFamily, 15);
            dd3.Text = "DD3";

        }

        private void PrintValues()
        {
            for (int i = 0; i < DD3.Count; i++)
            {
                Label tmp = new Label();
                this.rezults_pnl.Controls.Add(tmp);
                tmp.Top = 50 * i;
                tmp.Left = 5;
                tmp.Font = new Font(tmp.Font.FontFamily, 15);
                double tmpDBL = Math.Round(DD1[i], 2);
                tmp.Text = tmpDBL.ToString();

                Label tmp1 = new Label();
                this.rezults_pnl.Controls.Add(tmp1);
                tmp1.Top = 50 * i;
                tmp1.Left = 105;
                tmp1.Font = new Font(tmp.Font.FontFamily, 15);
                tmpDBL = Math.Round(DD2[i], 2);
                tmp1.Text = tmpDBL.ToString();

                Label tmp2 = new Label();
                this.rezults_pnl.Controls.Add(tmp2);
                tmp2.Top = 50 * i;
                tmp2.Left = 205;
                tmp2.Font = new Font(tmp.Font.FontFamily, 15);
                tmpDBL = Math.Round(DD3[i], 2);
                tmp2.Text = tmpDBL.ToString();
            }
        }
    }
}
