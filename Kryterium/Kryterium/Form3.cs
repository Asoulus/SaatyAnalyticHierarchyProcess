using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kryterium
{
    public partial class Form3 : Form
    {
        /*public double X1 { get; set; }
        public double X2 { get; set; }
        public double X3 { get; set; }
        public double X4 { get; set; }
        public double X5 { get; set; }*/

        private List<TextBox> textBoxes = new List<TextBox>();

        List<bool> activeKeyPoints = new List<bool>();

        List<int> selectedTypes = new List<int>();
        List<string> criteriaNames = new List<string>();

        private int currentIndex = 0;

        public List<List<double>> keyPoints = new List<List<double>>();

        public Form3(List<int> types, List<string> names)
        {        
            InitializeComponent();

            selectedTypes = types;
            criteriaNames = names;

            SetInitialKeyPointsValues();
            InitializeList();

            CreateTextBoxes();
            PrepareForm();      
        }

        private void PrepareForm()
        {
            if (currentIndex >= criteriaNames.Count)
            {
                this.Close();
                return;
            }

            criteriaName_lbl.Text = "Criteria name: " + criteriaNames[currentIndex].ToString();

            //string path = "C:/Users/rynsk/Desktop/WzoryRozmyte/Kryterium/Kryterium/Images/Typ" + (selectedTypes[currentIndex]).ToString() + ".png";
            //type_pctrbx.Image = Image.FromFile(path);

            type_pctrbx.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images/Typ" + (selectedTypes[currentIndex]).ToString() +".png"));
            

            ClearTextBoxes();
            LockTextBoxes(selectedTypes[currentIndex]);
        }

        private void InitializeList()
        {
            keyPoints.Clear();

            for (int i = 0; i < selectedTypes.Count; i++)
            {
                List<double> tmp = new List<double>();
                keyPoints.Add(tmp);
            }
        }

        private void SetInitialKeyPointsValues()
        {
            activeKeyPoints.Clear();
            activeKeyPoints.Add(false);
            activeKeyPoints.Add(false);
            activeKeyPoints.Add(false);
            activeKeyPoints.Add(false);
            activeKeyPoints.Add(false);
        }

        private void CreateTextBoxes()
        {

            for (int i = 0; i < 5; i++)
            {
                TextBox tmp = new TextBox();
                Label tmpLabel = new Label();
                this.x_pnl.Controls.Add(tmp);
                this.x_pnl.Controls.Add(tmpLabel);

                tmpLabel.Text = "X" + (i + 1).ToString();

                tmpLabel.Top = 40 * i;
                tmpLabel.Left = 5;

                tmp.Top = 40 * i;
                tmp.Left = 30;

                tmp.MinimumSize = new Size(30, 30);
                tmp.Width = 160;
                tmp.Height = 50;

                tmp.Font = new Font(tmp.Font.FontFamily, 15);
                tmp.MaxLength = 15;
                textBoxes.Add(tmp);

                tmp.KeyPress += CheckValidMatrixInput;
            }
        }

        private void ClearTextBoxes()
        {
            foreach (var tb in textBoxes)
            {
                tb.Text = "0";
                tb.Enabled = false;
            }
        }

        private void LockTextBoxes(int type)
        {
            switch (type)
            {
                case 1:
                    {
                        textBoxes[1].Enabled=true;
                        textBoxes[2].Enabled=true;

                        textBoxes[1].Text="";
                        textBoxes[2].Text="";

                        activeKeyPoints[1] = true;
                        activeKeyPoints[2] = true;
                    }
                    break;
                case 2:
                    {
                        textBoxes[1].Enabled = true;
                        textBoxes[2].Enabled = true;
                        textBoxes[3].Enabled = true;

                        textBoxes[1].Text = "";
                        textBoxes[2].Text = "";
                        textBoxes[3].Text = "";

                        activeKeyPoints[1] = true;
                        activeKeyPoints[2] = true;
                        activeKeyPoints[3] = true;
                    }
                    break;
                case 3:
                    {
                        textBoxes[1].Enabled = true;
                        textBoxes[2].Enabled = true;
                        textBoxes[3].Enabled = true;
                        textBoxes[4].Enabled = true;

                        textBoxes[1].Text = "";
                        textBoxes[2].Text = "";
                        textBoxes[3].Text = "";
                        textBoxes[4].Text = "";

                        activeKeyPoints[1] = true;
                        activeKeyPoints[2] = true;
                        activeKeyPoints[3] = true;
                        activeKeyPoints[4] = true;
                    }
                    break;
                case 4:
                    {
                        textBoxes[1].Enabled = true;
                        textBoxes[2].Enabled = true;
                        textBoxes[3].Enabled = true;

                        textBoxes[1].Text = "";
                        textBoxes[2].Text = "";
                        textBoxes[3].Text = "";

                        activeKeyPoints[1] = true;
                        activeKeyPoints[2] = true;
                        activeKeyPoints[3] = true;
                    }
                    break;
                case 5:
                    {
                        textBoxes[0].Enabled = true;
                        textBoxes[1].Enabled = true;
                        textBoxes[2].Enabled = true;

                        textBoxes[0].Text = "";
                        textBoxes[1].Text = "";
                        textBoxes[2].Text = "";

                        activeKeyPoints[0] = true;
                        activeKeyPoints[1] = true;
                        activeKeyPoints[2] = true;
                    }
                    break;
                case 6:
                    {
                        textBoxes[1].Enabled = true;
                        textBoxes[2].Enabled = true;

                        textBoxes[1].Text = "";
                        textBoxes[2].Text = "";

                        activeKeyPoints[1] = true;
                        activeKeyPoints[2] = true;

                    }
                    break;
                case 7:
                    {
                        textBoxes[1].Enabled = true;
                        textBoxes[2].Enabled = true;

                        textBoxes[1].Text = "";
                        textBoxes[2].Text = "";

                        activeKeyPoints[1] = true;
                        activeKeyPoints[2] = true;
                    }
                    break;
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textBoxes.Count; i++)
            {

                if (textBoxes[i].Text.Equals(""))
                {
                    keyPoints[currentIndex].Clear();
                    return;
                }

                var converted = ConvertTextBoxValueToDouble(textBoxes[i]);

                if (!converted.Item1)
                {
                    return;
                }

                keyPoints[currentIndex].Add(converted.Item2);
/*
                if (activeKeyPoints[i])
                {
                    
                    
                }*/
            }

            currentIndex++;
            SetInitialKeyPointsValues();
            PrepareForm();
        }

        private (bool, double) ConvertTextBoxValueToDouble(TextBox textBox)
        {
            double tmp = 0;
            bool success = false;

            try
            {
                tmp = Double.Parse(textBox.Text);
                success = true;
            }
            catch (Exception)
            {
                textBox.Text = "";
                success = false;
                MessageBox.Show("Value could not be converted to number");
            }

            return (success, tmp);
        }

        private void CheckValidMatrixInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow ,
            if ((e.KeyChar == ',') && (((TextBox)sender).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            // only allow -
            if ((e.KeyChar == '-') && (((TextBox)sender).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
