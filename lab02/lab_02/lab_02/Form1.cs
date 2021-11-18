using System;
using System.Windows.Forms;

namespace lab_02
{
    public partial class Form1 : Form
    {
        SModel model;

        public Form1()
        {
            model = new SModel();

            InitializeComponent();
            _blockInput(model.defaultNum);
        }

        private void _exitError()
        {
            error.Visible = true;
            
            _clearSeries();
            _clearOutput();
        }

        private void _hideError()
        {
            error.Visible = false;

            _clearSeries();
            _clearOutput();
        }

        private void _clearOutput()
        {
            string tempStr;

            for (int i = 0; i < SModel.inputNum; i++)
            {
                tempStr = "p" + (i + 1).ToString();
                this.Controls[tempStr].Text = "";

                tempStr = "t" + (i + 1).ToString();
                this.Controls[tempStr].Text = "";
            }
        }

        private void _clearSeries()
        {
            for (int i = 0; i < chart1.Series.Count; i++)
            {
                chart1.Series[i].Points.Clear();
            }
        }

        private void _blockInput(int ind)
        {
            string temp, name = "arr";

            _hideError();

            for (int i = 1; i <= model.numState; i++)
            {
                for (int j = 1; j <= model.numState; j++)
                {
                    temp = name + i.ToString() + j.ToString();

                    if (i <= ind && j <= ind)
                        this.Controls[temp].Enabled = true;
                    else
                        this.Controls[temp].Enabled = false;
                }
            }
        }

        private void _getNum_Click(object sender, EventArgs e)
        {
            int num;

            _hideError();

            try 
            {
                num = int.Parse(userNum.Text);
            }
            catch 
            {
                _exitError();
                return;
            }

            SModel.inputNum = num;
            _blockInput(num);
        }

        private void _go_Click(object sender, EventArgs e)
        {
            string tempStr, tempP, name = "arr";
            double tempNum;

            _hideError();

            for (int i = 0; i < SModel.inputNum; i++)
                for (int j = 0; j < SModel.inputNum; j++)
                {
                    tempStr = name + (i + 1).ToString() + (j + 1).ToString();

                    try
                    {
                        tempP = this.Controls[tempStr].Text;
                        if (String.Compare(tempP, "") == 0)
                            model.mtr[i, j] = 0;
                        else
                        {
                            tempNum = double.Parse(this.Controls[tempStr].Text);

                            if (tempNum < 0 || tempNum > 1)
                            {
                                _exitError();
                                return;
                            }

                            model.mtr[i, j] = tempNum;
                        }
                    }
                    catch
                    {
                        _exitError();
                        return;
                    }
                }

            model.Emulate(ref chart1);
            _outData(model.timeArr, "t");
            _outData(model.pArr, "p"); ;
        }

        private void _outData(double[] arr, string name)
        {
            string tempStr;

            for (int i = 0; i < SModel.inputNum; i++)
            {
                tempStr = name + (i + 1).ToString();
                this.Controls[tempStr].Text = Math.Round(arr[i], 3).ToString();
            }
        }
    }
}
