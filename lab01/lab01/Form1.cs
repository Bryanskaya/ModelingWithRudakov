using System;
using System.Windows.Forms;

namespace lab01
{
    public partial class Form1 : Form
    {
        double[] arrX;
        double[] arrf;
        double[] arrF;
        public Form1()
        {
            InitializeComponent();

            paramsEval.Visible = true;
            paramsNormal.Visible = false;
            button1_Click(null, null);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _ClearAll();

            paramsEval.Visible = true;
            paramsNormal.Visible = false;

            button1_Click(null, null);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _ClearAll();

            paramsEval.Visible = false;
            paramsNormal.Visible = true;

            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double defA, defB;
            double defM, defS;

            _ClearAll();

            if (radioButton1.Checked)
            {
                try
                {
                    defA = double.Parse(a.Text);
                    defB = double.Parse(b.Text);
                }
                catch
                {
                    error.Visible = true;
                    return;
                }

                try
                {
                    Distribution.Equal(defA, defB, out arrX, out arrf, out arrF);

                    for (int i = 0; i < arrX.Length; i++)
                    {
                        chart1.Series[0].Points.AddXY(arrX[i], arrf[i]);
                        chart2.Series[0].Points.AddXY(arrX[i], arrF[i]);
                    }
                }
                catch
                {
                    error.Visible = true;
                }
            }
            else if (radioButton2.Checked)
            {
                try
                {
                    defM = double.Parse(mu.Text);
                    defS = double.Parse(sigma.Text);

                    if (defS <= 0)
                    {
                        error.Visible = true;
                        return;
                    }
                }
                catch
                {
                    error.Visible = true;
                    return;
                }

                try
                {
                    Distribution.Normal(defM, defS, out arrX, out arrf, out arrF);

                    for (int i = 0; i < arrX.Length; i++)
                    {
                        chart1.Series[0].Points.AddXY(arrX[i], arrf[i]);
                        chart2.Series[0].Points.AddXY(arrX[i], arrF[i]);
                    }
                }
                catch
                {
                    error.Visible = true;
                }
            }
        }

        private void _ClearAll()
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();

            error.Visible = false;
        }
    }
}
