using System;
using System.Windows.Forms;
using ComputingDevice;

namespace lab04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b;
            double m, s, rvr; 
            int maxQueue = 0;
            bool flag;
            
            Device device = new Device();


            hideError();

            try
            {
                getGenerator(out a, out b);
                getAuto(out m, out s, out rvr);
            }
            catch (Exception err)
            {
                showError(err.Message);
                return;
            }

            device.ProcessByTime(a, b, m, s, rvr, ref maxQueue, out flag);
            fillRes(flag, maxQueue, "resTime");


            device.ProcessByEvents(a, b, m, s, rvr, ref maxQueue, out flag);
            fillRes(flag, maxQueue, "resEvent");
        }

        private void getGenerator(out double a, out double b)
        {
            string err = "ОШИБКА: неверный ввод параметров генератора";

            try
            {
                a = double.Parse(this.inputA.Text);
                b = double.Parse(this.inputB.Text);
            }
            catch
            {
                throw new Exception(err);
            }

            if (a >= b)
                throw new Exception(err);
        }

        private void getAuto(out double m, out double s, out double rvr)
        {
            string err = "ОШИБКА: неверный ввод параметров обслуживающего автомата";
            try
            {
                m = double.Parse(this.inputM.Text);
                s = double.Parse(this.inputS.Text);
                rvr = double.Parse(this.inputReverse.Text) / 100;     
            }
            catch
            {
                throw new Exception(err);
            }

            if (s <= 0 || rvr < 0 || rvr >= 1)
                throw new Exception(err);
        }

        private void showError(string err)
        {
            this.error.Text = err;
            this.error.Visible = true;
        }

        private void hideError()
        {
            this.error.Visible = false;
        }

        private void fillRes(bool flag, int maxQueue, string field)
        {
            if (flag)
                this.Controls[field].Text = "   ꟷ";
            else
                this.Controls[field].Text = maxQueue.ToString();
        }
    }
}
