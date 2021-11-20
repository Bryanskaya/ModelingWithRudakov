using System;
using System.Drawing;
using System.Windows.Forms;
using randMethods;
using rw;
using calculations;

namespace lab03
{
    public partial class Form1 : Form
    {
        static Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            radioButton1_CheckedChanged(null, null);

            colorData();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.own1.ReadOnly = false;
            this.own1.BackColor = Color.FromArgb(255, 255, 255);

            this.own2.ReadOnly = true;
            this.own2.BackColor = Color.FromArgb(240, 240, 240);

            this.own3.ReadOnly = true;
            this.own3.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.own1.ReadOnly = true;
            this.own1.BackColor = Color.FromArgb(240, 240, 240);

            this.own2.ReadOnly = false;
            this.own2.BackColor = Color.FromArgb(255, 255, 255);

            this.own3.ReadOnly = true;
            this.own3.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.own1.ReadOnly = true;
            this.own1.BackColor = Color.FromArgb(240, 240, 240);

            this.own2.ReadOnly = true;
            this.own2.BackColor = Color.FromArgb(240, 240, 240);

            this.own3.ReadOnly = false;
            this.own3.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void colorData()
        {
            this.dataA1.BackColor = Color.FromArgb(255, 255, 255);
            this.dataA2.BackColor = Color.FromArgb(255, 255, 255);
            this.dataA3.BackColor = Color.FromArgb(255, 255, 255);

            this.dataT1.BackColor = Color.FromArgb(255, 255, 255);
            this.dataT2.BackColor = Color.FromArgb(255, 255, 255);
            this.dataT3.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void hideError()
        {
            this.error.Visible = false;
        }

        private void unhideError(string error)
        {
            this.error.Text = error;
            this.error.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideError();

            fillAlg();
            useTable();
            processUser();
        }

        private void fillAlg()
        {
            string nameAlg1 = "data/Alg1.txt";
            string nameAlg2 = "data/Alg2.txt";
            string nameAlg3 = "data/Alg3.txt";

            int start1 = 0, end1 = 10;
            int start2 = 10, end2 = 100;
            int start3 = 100, end3 = 1000;

            _fillAlg(start1, end1, nameAlg1, "dataA1", "criteriaA1");
            _fillAlg(start2, end2, nameAlg2, "dataA2", "criteriaA2");
            _fillAlg(start3, end3, nameAlg3, "dataA3", "criteriaA3");
        }

        private void _fillAlg(int start, int end, string filename, string field, string fieldK)
        {
            int[] arr = new int[1000];
            CongruentMethod alg = new CongruentMethod(rnd.Next());

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = alg.next(start, end);
            }

            Writer.write(arr, filename);
            fillUI(field, arr);
            fillCriteria(fieldK, MathCalc.Criteria(arr, start, end));
        }

        private void useTable()
        {
            string nameTbl1 = "data/Tbl1.txt";
            string nameTbl2 = "data/Tbl2.txt";
            string nameTbl3 = "data/Tbl3.txt";

            int start1 = 0, end1 = 10;
            int start2 = 10, end2 = 100;
            int start3 = 100, end3 = 1000;

            _useTable(start1, end1, nameTbl1, "dataT1", "criteriaT1");
            _useTable(start2, end2, nameTbl2, "dataT2", "criteriaT2");
            _useTable(start3, end3, nameTbl3, "dataT3", "criteriaT3");
        }

        private void _useTable(int start, int end, string filename, string field, string fieldK)
        {
            int[] data = new int[1000];
            int[] arr = new int[1000];
            int num = rnd.Next(0, 1000);
            int j = num;

            _getArrFromFile(filename, ref data);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = data[j];
                j = (j + 1) % data.Length;
            }

            fillUI(field, arr);
            fillCriteria(fieldK, MathCalc.Criteria(arr, start, end));
        }

        private void _getArrFromFile(string name, ref int[] arr)
        {
            string[] temp = new string[1];

            Reader.read(name, out temp);
            for (int i = 0; i < temp.Length; i++)
                arr[i] = Convert.ToInt32(temp[i]);
        }

        private void _getArrFromStr(string data, int flag, ref int[] arr)
        {
            string[] temp = new string[1000];
            int start = 0, end = 10;

            switch (flag)
            {
                case 2:
                    start = 10;
                    end = 100;
                    break;
                case 3:
                    start = 100;
                    end = 1000;
                    break;
            }

            temp = data.Split('\n');

            if (temp.Length != 10)
                throw new Exception("Неверное количество (должно быть 10)");

            for (int i = 0; i < temp.Length; i++)
            {
                try
                {
                    arr[i] = Convert.ToInt32(temp[i]);
                }
                catch
                {
                    throw new Exception("Неверный формат данных");
                }

                if (arr[i] < 0)
                    throw new Exception("Число должно быть неотрицательным");
                if (arr[i] < start || arr[i] > end)
                    throw new Exception("Неверная разрядность");
            }
        }

        private void processUser()
        {
            int[] arr = new int[10];
            int flag, start, end;
            string fieldK;

            try
            {
                _getArrFromUser(out flag, ref arr);
            }
            catch (Exception e)
            {
                unhideError(e.Message);
                return;
            }

            switch (flag)
            {
                case 1:
                    start = 0;
                    end = 10;
                    fieldK = "criteriaO1";
                    break;
                case 2:
                    start = 10;
                    end = 100;
                    fieldK = "criteriaO2";
                    break;
                default:
                    start = 100;
                    end = 1000;
                    fieldK = "criteriaO3";
                    break;
            }

            fillCriteria(fieldK, MathCalc.Criteria(arr, start, end));
        }

        private void _getArrFromUser(out int flag, ref int[] arr)
        {
            string data, name;

            if (this.radioButton1.Checked)
            {
                flag = 1;
                name = "own1";
            }
            else if (this.radioButton2.Checked)
            {
                flag = 2;
                name = "own2";
            }
            else
            {
                flag = 3;
                name = "own3";
            }

            data = this.Controls[name].Text;

            _getArrFromStr(data, flag, ref arr);
        }

        private void fillUI(string name, int[] arr)
        {
            this.Controls[name].Text = createStr(arr, 10);
        }

        private void fillCriteria(string name, double num)
        {
            this.Controls[name].Text = (Math.Round(num, 3)).ToString();
        }

        private string createStr(int[] arr, int num)
        {
            string str = "";

            for (int i = 0; i < num; i++)
            {
                str += arr[i] + "\n";
            }

            return str;
        }

    }
}
