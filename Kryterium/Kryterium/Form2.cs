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
    public partial class Form2 : Form
    {
        public List<int> selectedTypes = new List<int>();

        private int CriteriaAmount { get; set; }

        private List<TextBox> selectedTypeTextBoxes = new List<TextBox>();

        public Form2(List<string> criteriaNames)
        {
            InitializeComponent();
            type1_pctrbx.Image = Image.FromFile("C:/Users/rynsk/Desktop/WzoryRozmyte/Kryterium/Kryterium/Images/Typ1.png");
            type2_pctrbx.Image = Image.FromFile("C:/Users/rynsk/Desktop/WzoryRozmyte/Kryterium/Kryterium/Images/Typ2.png");
            type3_pctrbx.Image = Image.FromFile("C:/Users/rynsk/Desktop/WzoryRozmyte/Kryterium/Kryterium/Images/Typ3.png");
            type4_pctrbx.Image = Image.FromFile("C:/Users/rynsk/Desktop/WzoryRozmyte/Kryterium/Kryterium/Images/Typ4.png");
            type5_pctrbx.Image = Image.FromFile("C:/Users/rynsk/Desktop/WzoryRozmyte/Kryterium/Kryterium/Images/Typ5.png");
            type6_pctrbx.Image = Image.FromFile("C:/Users/rynsk/Desktop/WzoryRozmyte/Kryterium/Kryterium/Images/Typ6.png");
            type7_pctrbx.Image = Image.FromFile("C:/Users/rynsk/Desktop/WzoryRozmyte/Kryterium/Kryterium/Images/Typ7.png");

            this.CriteriaAmount = criteriaNames.Count;
            CreateTextBoxes(criteriaNames);
        }

        private void CreateTextBoxes(List<string> names)
        {
            for (int i = 0; i < CriteriaAmount; i++)
            {
                TextBox tmp = new TextBox();
                Label tmpLabel = new Label();

                this.selectedTypes_pnl.Controls.Add(tmp);
                this.criteriaNames_pnl.Controls.Add(tmpLabel);

                tmpLabel.Top = 40 * i;
                tmpLabel.Left = 5;

                tmp.Top = 40 * i;
                tmp.Left = 5;
               
                tmp.MinimumSize = new Size(30, 30);
                tmp.Width = 150;
                tmp.Height = 50;

                tmp.Font = new Font(tmp.Font.FontFamily, 15);
                tmp.MaxLength = 15;

                tmpLabel.MaximumSize = new Size(500, 500);
                tmpLabel.Height = 30;
                tmpLabel.Width = 200;

                tmpLabel.Font = new Font(tmp.Font.FontFamily, 15);

                tmpLabel.Text = names[i];

                selectedTypeTextBoxes.Add(tmp);
            }

            this.selectedTypes_pnl.Controls.Add(save_btn);
            save_btn.Top = 40 * CriteriaAmount;
            save_btn.Left = 5;
        }

    private void save_btn_Click(object sender, EventArgs e)
        {
            if (CheckAlternativesNameTextBoxes())
            {
                this.Close();
            }
        }

        public bool CheckAlternativesNameTextBoxes()
        {

            foreach (TextBox tb in selectedTypeTextBoxes)
            {
                if (tb.Text.Equals(""))
                {
                    selectedTypes.Clear();
                    return false;
                }
                else
                {
                    selectedTypes.Add(ConvertToInt(tb.Text));
                }
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

    }
}
