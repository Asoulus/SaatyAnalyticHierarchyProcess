namespace Kryterium
{
    public partial class Form1 : Form
    {
        private int criteriaAmount = 0;
        private int alternativesAmount = 0;

        //RI -> random match factor
        static List<double> ri = new List<double>() { 0, 0, 0.52, 0.89, 1.11, 1.25, 1.35, 1.4, 1.45, 1.49 };

        //Name Input TextBoxes
        private List<TextBox> critiriaTextBoxes = new List<TextBox>();
        private List<TextBox> alternativesTextBoxes = new List<TextBox>();

        //Criteria Calculations Lists
        private List<string> criteriaNames = new List<string>();
        private List<double> criteriaTotals = new List<double>();
        private List<double> criteriaAlphas = new List<double>();
        private List<double> criteriaMatrixInput = new List<double>();

        //Calculation Matrix
        private List<List<TextBox>> matrixList = new List<List<TextBox>>();

        //Matrix Labels
        private List<Label> topMatrixLabels = new List<Label>();
        private List<Label> leftMatrixLabels = new List<Label>();

        //Alternatives Calculations Lists
        private List<string> alternativesNames = new List<string>();
        private List<List<double>> alternativesTotals = new List<List<double>>();
        private List<List<double>> alternativesAlphas = new List<List<double>>();
        private List<List<double>> alternativesMatrixInput = new List<List<double>>();
        private List<List<double>> valuesOfMembershipFunction = new List<List<double>>();
        private List<List<double>> keyPointsList = new List<List<double>>();

        //DD's
        private List<double> DD1s = new List<double>();
        private List<double> DD2s = new List<double>();
        private List<double> DD3s = new List<double>();

        //List containing results
        private List<double> resultList = new List<double>();

        //State of Criteria/Alternative
        private string calculationState = String.Empty;

        //Index Of Current Criteria
        private int currentCriteriaIndex = 0;

        //New Forms
        private Form2 membershipChoiceForm;
        private Form3 keyPoints;
        private Form4 alternativesTable;

        //Selected Function Type
        public List<int> selectedTypes = new List<int>();

        //Key Points Of Function
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double X3 { get; set; }
        public double X4 { get; set; }
        public double X5 { get; set; }

        public int CriteriaAmount
        {
            get { return criteriaAmount; }
            set { criteriaAmount = value; }
        }

        public int AlternativesAmount
        {
            get { return alternativesAmount; }
            set { alternativesAmount = value; }
        }

        public Form1()
        {
            InitializeComponent();
            calculate_btn.Hide();
            criteriaNames_btn.Hide();
            names_lbl.Hide();
            criteriaAlphas_lbl.Hide();
            matrixOperation_lbl.Text = "";
        }

        private void confirm_Click(object sender, EventArgs e)
        {

            if (CheckCriteriaNameTextBoxes())// && CheckAlternativesNameTextBoxes())
            {
                confirm_btn.Enabled = false;
                criteriaAmount_tb.Enabled = false;
                //alternativesAmount_tb.Enabled = false;

                
                ShowCritiriaNames();
            }
        }

        public bool CheckCriteriaNameTextBoxes()
        {
            if (criteriaAmount_tb.Text.Equals(""))
            {
                return false;
            }


            CriteriaAmount = ConvertToInt(criteriaAmount_tb.Text);

            if (CriteriaAmount > 10 || CriteriaAmount < 2)
            {
                return false;
            }

            return true;
        }


        private void liczbaKryteriow_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckValidIntigerInput(sender, e);
        }

        private void ShowCritiriaNames()
        {
            names_lbl.Show();

            for (int i = 0; i < CriteriaAmount; i++)
            {
                TextBox tmp = new TextBox();
                this.criteria_pnl.Controls.Add(tmp);

                tmp.Top = 40 * i;
                tmp.Left = 5;

                tmp.MinimumSize = new Size(30, 30);
                tmp.Width = 160;
                tmp.Height = 50;

                tmp.Font = new Font(tmp.Font.FontFamily, 15);
                tmp.MaxLength = 15;
                critiriaTextBoxes.Add(tmp);
            }

            this.criteria_pnl.Controls.Add(criteriaNames_btn);
            criteriaNames_btn.Top = 40 * CriteriaAmount;
            criteriaNames_btn.Left = 5;

            criteriaNames_btn.Show();
        }

        private void CreateMatrix(int size)
        {
            for (int i = 0; i < size; i++)
            {
                List<TextBox> tmpList = new List<TextBox>();

                for (int j = 0; j < size; j++)
                {
                    TextBox tmp = new TextBox();
                    this.matrix_pnl.Controls.Add(tmp);
                    tmp.Top = 50 * i;
                    tmp.Left = 50 * j;
                    tmp.MinimumSize = new Size(30, 30);
                    tmp.Width = 40;
                    tmp.Height = 40;
                    tmp.Font = new Font(tmp.Font.FontFamily, 15);
                    tmp.TextAlign = HorizontalAlignment.Center;

                    if (i == j)
                    {
                        tmp.Text = "1";
                        tmp.Enabled = false;
                    }


                    tmpList.Add(tmp);

                    tmp.KeyPress += CheckValidMatrixInput;

                    tmp.Leave += CheckMatrixInput;
                }

                matrixList.Add(tmpList);
            }

            calculate_btn.Show();
        }

        private void CheckMatrixInput(object sender, EventArgs e)
        {
            string[] tmpArray = ((TextBox)sender).Text.Split("/");

            TextBox tmp = ((TextBox)sender);


            if (tmpArray.Length == 1)
            {
                int value = ConvertToInt(tmpArray[0]);

                if (value < 1 || value > 9)
                {
                    CleanTextBox(tmp);
                    return;
                }
                else
                {
                    for (int i = 0; i < matrixList.Count; i++)
                    {
                        for (int j = 0; j < matrixList[i].Count; j++)
                        {
                            if (matrixList[i][j] == tmp)
                            {
                                if (matrixList[i][j].Text.Equals("1"))
                                {
                                    matrixList[j][i].Text = value.ToString();
                                }
                                else
                                {
                                    matrixList[j][i].Text = "1/" + value.ToString();
                                }

                            }
                        }
                    }
                }
            }
            else
            {
                int upperValue = ConvertToInt(tmpArray[0]);
                int lowerValue = ConvertToInt(tmpArray[1]);


                if (lowerValue < 2 || lowerValue > 9 || upperValue != 1)
                {
                    CleanTextBox(tmp);
                    return;
                }
                else
                {
                    for (int i = 0; i < matrixList.Count; i++)
                    {
                        for (int j = 0; j < matrixList[i].Count; j++)
                        {
                            if (matrixList[i][j] == tmp)
                            {
                                matrixList[j][i].Text = lowerValue.ToString();
                            }
                        }
                    }
                }
            }

        }

        private void CleanTextBox(TextBox txtBox)
        {
            txtBox.Text = "";
        }

        private void CheckValidMatrixInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '/'))
            {
                e.Handled = true;
            }

            // only allow one dash
            if ((e.KeyChar == '/') && (((TextBox)sender).Text.IndexOf('/') > -1))
            {
                e.Handled = true;
            }
        }

        private void CheckValidIntigerInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void confirmNames_btn_Click(object sender, EventArgs e)
        {
            foreach (TextBox txtBox in critiriaTextBoxes)
            {
                if (txtBox.Text.Equals(""))
                {
                    PrintError("All criteria must be filled");
                    return;
                }
            }

            for (int i = 0; i < critiriaTextBoxes.Count; i++)
            {
                for (int j = 0; j < critiriaTextBoxes.Count; j++)
                {
                    if (i != j && critiriaTextBoxes[i].Text.Equals(critiriaTextBoxes[j].Text))
                    {
                        PrintError("All criteria must have diffrent names");
                        return;
                    }
                }

            }

            foreach (TextBox txtBox in critiriaTextBoxes)
            {
                criteriaNames.Add(txtBox.Text);
                txtBox.Enabled = false;
                criteriaNames_btn.Enabled = false;
            }

            calculationState = "criteria";
            CreateMatrixWithLabels(criteriaNames,"Even comparisons of criteria.");
        }

        private void CreateMatrixWithLabels(List<string> names, string operaionName)
        {
            CreateMatrixLeftLabels(names);
            CreateMatrixTopLabels(names);
            CreateMatrix(names.Count);
            LockTextBoxes();
            DisplayOperationName(operaionName);
        }

        private void DisplayOperationName(string operaionName)
        {
            matrixOperation_lbl.BorderStyle = BorderStyle.FixedSingle;
            matrixOperation_lbl.Text = "CURRENT OPERATION:\n"+operaionName;
        }

        private void LockTextBoxes()
        {
            for (int i = 0; i < matrixList.Count; i++)
            {
                for (int j = 0; j < matrixList[i].Count; j++)
                {
                    if (j < i)
                    {
                        matrixList[i][j].Enabled = false;
                    }
                }
            }
        }

        private void CreateMatrixTopLabels(List<string> names)
        {

            for (int i = 0; i < names.Count; i++)
            {
                HorizontalLabel tmp = new HorizontalLabel();

                tmp.Text = "";
                tmp.AutoSize = false;
                tmp.NewText = names[i];
                tmp.RotateAngle = -90;

                topLabel_pnl.Controls.Add(tmp);

                tmp.Left = -50 + 50 * i;
                tmp.Top = -50;

                tmp.MaximumSize = new Size(500, 500);
                tmp.Height = 500;

                tmp.TextAlign = ContentAlignment.MiddleLeft;

                tmp.Font = new Font(tmp.Font.FontFamily, 15);
                topMatrixLabels.Add(tmp);

            }
        }

        private void FillAlternativesCalculationList()
        {
            for (int i = 0; i < criteriaNames.Count; i++)
            {
                List<double> tmp = new List<double>();
                alternativesTotals.Add(tmp);
            }

            for (int i = 0; i < criteriaNames.Count; i++)
            {
                List<double> tmp = new List<double>();
                alternativesAlphas.Add(tmp);
            }

            for (int i = 0; i < criteriaNames.Count; i++)
            {
                List<double> tmp = new List<double>();
                alternativesMatrixInput.Add(tmp);
            }
            
        }

        private void CreateMatrixLeftLabels(List<string> names)
        {
            for (int i = 0; i < names.Count; i++)
            {
                Label tmp = new Label();
                leftLabel_pnl.Controls.Add(tmp);
                tmp.Text = names[i];

                tmp.Left = 0;
                tmp.Top = 50 * i;

                tmp.MaximumSize = new Size(500, 500);
                tmp.Height = 30;
                tmp.Width = 200;

                tmp.TextAlign = ContentAlignment.MiddleRight;
                tmp.Font = new Font(tmp.Font.FontFamily, 15);
                leftMatrixLabels.Add(tmp);
            }
        }

        private void calculate_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < matrixList.Count; i++)
            {
                for (int j = 0; j < matrixList[i].Count; j++)
                {
                    if (matrixList[i][j].Text.Equals(String.Empty))
                    {
                        return;
                    }
                }
            }

            SaveCriteriaMatrixValues(criteriaMatrixInput);
            CalculateTotals(criteriaTotals, CriteriaAmount);
            CalculateAlphas(criteriaAlphas, criteriaTotals, CriteriaAmount);

            if (!CheckDataConsistency(criteriaMatrixInput, CriteriaAmount, criteriaAlphas))
            {
                return;
            }
            ShowAlphas(this.criteriaAlphas_pnl, criteriaAlphas);

            PrepareForAlternatives();

            membershipChoiceForm = new Form2(criteriaNames);

            membershipChoiceForm.Show();

            membershipChoiceForm.FormClosed += new FormClosedEventHandler(FunctionTypeSelectionFormClosedEvent);
        }

        private void FunctionTypeSelectionFormClosedEvent(object? sender, FormClosedEventArgs e)
        {
            selectedTypes = membershipChoiceForm.selectedTypes;

            keyPoints = new Form3(selectedTypes, criteriaNames);
            keyPoints.Show();

            keyPoints.FormClosed += new FormClosedEventHandler(KeyPointsFormClosedEvent);
        }

        private void KeyPointsFormClosedEvent(object? sender, FormClosedEventArgs e)
        {
            keyPointsList = keyPoints.keyPoints;

            alternativesTable = new Form4(criteriaNames);
            alternativesTable.Show();

            alternativesTable.FormClosed += new FormClosedEventHandler(AlternativesFormClosed);
        }

        private void AlternativesFormClosed(object? sender, FormClosedEventArgs e)
        {

            for (int i = 0; i < alternativesTable.tableValues.Count; i++)
            {
                for (int j = 0; j < alternativesTable.tableValues[i].Count; j++)
                {
                    for (int k = 0; k < alternativesTable.tableValues.Count; k++)
                    {
                        if (alternativesMatrixInput[j].Count < alternativesTable.tableValues.Count)
                        {
                            alternativesMatrixInput[j].Add(alternativesTable.tableValues[k][j]);
                        }
                    }
                }
            }

            foreach (var tb in alternativesTable.alternativesTextBoxes)
            {
                alternativesNames.Add(tb.Text);
            }

           
            CalculateMembershipFunctionValue();
        }

        private void CalculateMembershipFunctionValue()
        {
            for (int i = 0; i < alternativesMatrixInput.Count; i++) //criteria
            {
                List<double> tmpList = new List<double>();

                valuesOfMembershipFunction.Add(tmpList);

                for (int j = 0; j < alternativesMatrixInput[i].Count; j++) //alternatives
                {
                    double tmp =  GetMembershipValue(selectedTypes[i], i, alternativesMatrixInput[i][j]); 
                    valuesOfMembershipFunction[i].Add(tmp);
                }
            }

            FlipList();
        }

        private void FlipList()
        {
            List<List<double>> tmp = new List<List<double>>();

            for (int i = 0; i < valuesOfMembershipFunction[0].Count; i++)
            {
                List<double> tmpList = new List<double>();
                tmp.Add(tmpList);
            }

            for (int i = 0; i < valuesOfMembershipFunction.Count; i++)
            {
                for (int j = 0; j < valuesOfMembershipFunction[i].Count; j++)
                {
                    for (int k = 0; k < valuesOfMembershipFunction.Count; k++)
                    {
                        if (tmp[j].Count < valuesOfMembershipFunction.Count)
                        {
                            tmp[j].Add(valuesOfMembershipFunction[k][j]);
                        }
                    }
                }
            }

            valuesOfMembershipFunction.Clear();
            valuesOfMembershipFunction = tmp;

            CalculateGlobalAlternatives();
        }

        private void CalculateGlobalAlternatives()
        {

            //DD1
            for (int i = 0; i < valuesOfMembershipFunction.Count; i++)
            {
                List<double> tmp = new List<double>();

                for (int j = 0; j < valuesOfMembershipFunction[i].Count; j++)
                {
                    tmp.Add(Math.Pow(valuesOfMembershipFunction[i][j], criteriaAlphas[j]));
                }

                DD1s.Add(tmp.Min());
            }

            //DD2
            for (int i = 0; i < valuesOfMembershipFunction.Count; i++)
            {
                double tmp = 1;

                for (int j = 0; j < valuesOfMembershipFunction[i].Count; j++)
                {
                    tmp *= Math.Pow(valuesOfMembershipFunction[i][j], criteriaAlphas[j]);
                }

                DD2s.Add(tmp);
            }

            //DD3
            for (int i = 0; i < valuesOfMembershipFunction.Count; i++)
            {
                double tmp = 0;

                for (int j = 0; j < valuesOfMembershipFunction[i].Count; j++)
                {
                    tmp += valuesOfMembershipFunction[i][j] * criteriaAlphas[j];
                }
                tmp = tmp / criteriaAmount;

                DD3s.Add(tmp);
            }

            Form5 rezults = new Form5(alternativesNames, DD1s, DD2s, DD3s);
            rezults.Show();
            //this.Close();
        }

        private double GetMembershipValue(int typeNumber, int index, double userInputValue)
        {
            double value = 0;
            double X1 = keyPointsList[index][0];
            double X2 = keyPointsList[index][1];
            double X3 = keyPointsList[index][2];
            double X4 = keyPointsList[index][3];
            double X5 = keyPointsList[index][4];


            switch (typeNumber)
            {
                case 1:
                    {
                        if (userInputValue <= X2)
                        {
                            value = 1;
                            break;
                        }

                        if (X2 < userInputValue && userInputValue <= X3)
                        {
                            value = Math.Round((X3 - userInputValue) / (X3 - X2), 2);
                            break;
                        }

                        if (userInputValue > X3)
                        {
                            value = 0;
                            break;
                        }
                    }
                    break;
                case 2:
                    {
                        if (userInputValue <= X2)
                        {
                            value = 0;
                            break;
                        }

                        if (X2 < userInputValue && userInputValue <= X3)
                        {
                            value = 1;
                            break;
                        }

                        if (X3 < userInputValue && userInputValue <= X4)
                        {
                            value = Math.Round((X4 - userInputValue) / (X4 - X3), 2);
                            break;
                        }

                        if (userInputValue > X4)
                        {
                            value = 0;
                            break;
                        }
                    }
                    break;
                case 3:
                    {
                        if (userInputValue <= X2)
                        {
                            value = 0;
                            break;
                        }

                        if (X2 < userInputValue && userInputValue <= X3)
                        {
                            value = Math.Round((userInputValue - X2) / (X3 - X2), 2);
                            break;
                        }

                        if (X3 < userInputValue && userInputValue <= X4)
                        {
                            value = 1;
                            break;
                        }


                        if (X4 < userInputValue && userInputValue <= X5)
                        {
                            value = Math.Round((X5 - userInputValue) / (X5 - X4), 2);
                            break;
                        }

                        if (userInputValue > X5)
                        {
                            value = 0;
                            break;
                        }
                    }
                    break;
                case 4:
                    {
                        if (userInputValue <= X2)
                        {
                            value = 0;
                            break;
                        }

                        if (X2 < userInputValue && userInputValue <= X3)
                        {
                            value = Math.Round((userInputValue - X2) / (X3 - X2), 2);
                            break;
                        }

                        if (X3 < userInputValue && userInputValue <= X4)
                        {
                            value = Math.Round((X4 - userInputValue) / (X4 - X3), 2);
                            break;
                        }

                        if (userInputValue > X4)
                        {
                            value = 0;
                            break;
                        }
                    }
                    break;
                case 5:
                    {
                        if (userInputValue <= X1)
                        {
                            value = 0;
                            break;
                        }

                        if (X1 < userInputValue && userInputValue <= X2)
                        {
                            value = Math.Round((userInputValue - X1) / (X2 - X1), 2);
                            break;
                        }

                        if (X2 < userInputValue && userInputValue <= X3)
                        {
                            value = 1;
                            break;
                        }

                        if (userInputValue > X3)
                        {
                            value = 0;
                            break;
                        }
                    }
                    break;
                case 6:
                    {
                        if (userInputValue <= X2)
                        {
                            value = 0;
                            break;
                        }

                        if (X2 < userInputValue && userInputValue <= X3)
                        {
                            value = Math.Round((userInputValue - X2) / (X3 - X2), 2);
                            break;
                        }

                        if (userInputValue > X3)
                        {
                            value = 0;
                            break;
                        }
                    }
                    break;
                case 7:
                    {
                        if (userInputValue <= X2)
                        {
                            value = 0;
                            break;
                        }

                        if (X2 < userInputValue && userInputValue <= X3)
                        {
                            value = 1;
                            break;
                        }

                        if (userInputValue > X3)
                        {
                            value = 0;
                            break;
                        }
                    }
                    break;
            }

            return value;
        }

        private void PrepareForAlternatives()
        {


            ClearMatrixLabels();
            ClearMatrixList();

            FillAlternativesCalculationList();
        }



        private void LockAllInput()
        {
            calculate_btn.Enabled = false;

            for (int i = 0; i < matrixList.Count; i++)
            {
                for (int j = 0; j < matrixList[i].Count; j++)
                {
                    matrixList[i][j].Enabled = false;
                }
            }
        }



        private bool CheckDataConsistency(List<double> matrixInputList, int matrixSize, List<double> alphasList)
        {
            double lambda = 0;

            for (int i = 0; i < matrixInputList.Count; i++)
            { 
                double tmp = 0;
                tmp = matrixInputList[i] * alphasList[i];
                lambda += tmp;
            }

            lambda = lambda / matrixSize;

            double ci = (lambda - matrixSize) / (matrixSize - 1);
            if (ci > 0.1)
            {
                PrintError("CI is more than 0.1\nCI value equal: " + ci);
                LockAllInput();
                return false;
            }

            double cr = Math.Abs(ci / ri[matrixSize]);
            if (cr > 0.1)
            {
                LockAllInput();
                PrintError("CR is more than 0.1\nCR value equal: " + ci);
                return false;
            }

            return true;
        }

        private void CalculateTotals(List<double> totalsList, int size)
        {
            for (int i = 0; i < matrixList.Count; i++)
            {
                double columnSum = 1;

                for (int j = 0; j < matrixList[i].Count; j++)
                {
                    string[] tmpArray = matrixList[i][j].Text.Split("/");

                    if (tmpArray.Length == 2)
                    {
                        columnSum *= (ConvertToDouble(tmpArray[0]) / ConvertToDouble(tmpArray[1]));
                    }
                    else
                    {
                        columnSum *= ConvertToDouble(tmpArray[0]);
                    }

                }

                
                totalsList.Add(Math.Pow(columnSum, (1.0 / size)));
            }
        }

        private void SaveCriteriaMatrixValues(List<double> saveMatrixList)
        {
            for (int i = 0; i < matrixList.Count; i++)
            {
                double rowSum = 0;

                for (int j = 0; j < matrixList[i].Count; j++)
                {
                    string[] tmpArray = matrixList[j][i].Text.Split("/");

                    if (tmpArray.Length == 2)
                    {
                        rowSum += (ConvertToDouble(tmpArray[0]) / ConvertToDouble(tmpArray[1]));
                    }
                    else
                    {
                        rowSum += ConvertToDouble(tmpArray[0]);
                    }

                }

                saveMatrixList.Add(rowSum);
            }
        }

        private void CalculateAlphas(List<double> alphasList, List<double> totalsList, int size)
        {
            for (int i = 0; i < totalsList.Count; i++)
            {
                alphasList.Add((totalsList[i] / totalsList.Sum() * size));         
            }
        }

        private void ShowAlphas(Panel panelToDisplayOn, List<double> alphasList)
        {
            for (int i = 0; i < alphasList.Count; i++)
            {
                Label tmp = new Label();
                panelToDisplayOn.Controls.Add(tmp);

                tmp.Text = Math.Round(alphasList[i], 2).ToString();

                tmp.Top = 40 * i;
                tmp.Left = 0;
                tmp.AutoSize = false;

                tmp.MinimumSize = new Size(30, 30);
                tmp.MaximumSize = new Size(300, 300);
                tmp.Width = 250;
                tmp.Height = 35;

                tmp.ForeColor = Color.DarkOrange;

                tmp.TextAlign = ContentAlignment.MiddleLeft;
                tmp.Font = new Font(tmp.Font.FontFamily, 15);
            }

            panelToDisplayOn.Show();
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

        private double ConvertToDouble(string input)
        {
            double tmp = 0;

            try
            {
                tmp = Double.Parse(input);
            }
            catch (Exception)
            {
                //TODO print error message?
                //throw;
            }

            return tmp;
        }

        class HorizontalLabel : System.Windows.Forms.Label
        {
            public int RotateAngle { get; set; }
            public string? NewText { get; set; }
            protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
            {
                Brush b = new SolidBrush(this.ForeColor);
                e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
                e.Graphics.RotateTransform(this.RotateAngle);
                e.Graphics.DrawString(this.NewText, this.Font, b, 0f, 0f);
                base.OnPaint(e);
            }
        }

        private void alternativesAmount_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckValidIntigerInput(sender, e);
        }

        private void PrintError(string message)
        {
            MessageBox.Show(message,"Error");
        }

        private void ClearMatrixList()
        {
            for (int i = 0; i < matrixList.Count; i++)
            {
                for (int j = 0; j < matrixList[i].Count; j++)
                {
                    this.Controls.Remove(matrixList[i][j]);
                    matrixList[i][j].Dispose();
                }
            }

            matrixList.Clear();

            calculate_btn.Hide();
        }

        private void ClearMatrixLabels()
        {
            for (int i = 0; i < topMatrixLabels.Count; i++)
            {
                this.Controls.Remove(topMatrixLabels[i]);
                topMatrixLabels[i].Dispose();
            }

            topMatrixLabels.Clear();

            for (int i = 0; i < leftMatrixLabels.Count; i++)
            {
                this.Controls.Remove(leftMatrixLabels[i]);
                leftMatrixLabels[i].Dispose();
            }

            leftMatrixLabels.Clear();

            matrixOperation_lbl.Text = "";
            matrixOperation_lbl.BorderStyle = BorderStyle.None;
        }

        /*private void alternativesNames_btn_Click(object sender, EventArgs e)
        {
            foreach (TextBox txtBox in alternativesTextBoxes)
            {
                if (txtBox.Text.Equals(""))
                {
                    PrintError("All alternatives must be filled");
                    return;
                }
            }

            for (int i = 0; i < alternativesTextBoxes.Count; i++)
            {
                for (int j = 0; j < alternativesTextBoxes.Count; j++)
                {
                    if (i != j && alternativesTextBoxes[i].Text.Equals(alternativesTextBoxes[j].Text))
                    {
                        PrintError("All alternatives must have diffrent names");
                        return;
                    }
                }
                
            }

            foreach (TextBox txtBox in alternativesTextBoxes)
            {
                alternativesNames.Add(txtBox.Text);
                txtBox.Enabled = false;
                alternativesNames_btn.Enabled = false;
            }

            calculationState = "alternatives";
            CreateMatrixWithLabels(alternativesNames, "Assessing alternatives of '" + criteriaNames[0]+"' criteria.");
        }*/

        
    }
}