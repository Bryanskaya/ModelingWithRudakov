using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using randMethods;
using rw;

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

            _fillAlg(start1, end1, nameAlg1, "dataA1");
            _fillAlg(start2, end2, nameAlg2, "dataA2");
            _fillAlg(start3, end3, nameAlg3, "dataA3");
        }

        private void _fillAlg(int start, int end, string filename, string field)
        {
            int[] arr = new int[1000];
            CongruentMethod alg = new CongruentMethod(rnd.Next());

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = alg.next(start, end);
            }

            rw.Writer.write(arr, filename);
            fillUI(field, arr);
        }

        private void useTable()
        {
            string nameGTbl1 = "data/GlobalTbl1.txt";
            string nameGTbl2 = "data/GlobalTbl2.txt";
            string nameGTbl3 = "data/GlobalTbl3.txt";

            string nameTbl1 = "data/Tbl1.txt";
            string nameTbl2 = "data/Tbl2.txt";
            string nameTbl3 = "data/Tbl3.txt";

            _useTable(nameGTbl1, nameTbl1, "dataT1");
            _useTable(nameGTbl2, nameTbl2, "dataT2");
            _useTable(nameGTbl3, nameTbl3, "dataT3");
        }

        private void _useTable(string tablename, string filename, string field)
        {
            int[] data = new int[1000];
            int[] arr = new int[1000];
            int num = rnd.Next(0, 1000);
            int j = num;

            _getArrFromFile(tablename, ref data);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = data[j];
                j = (j + 1) % data.Length;
            }

            rw.Writer.write(arr, filename);
            fillUI(field, arr);
        }

        private void _getArrFromFile(string name, ref int[] arr)
        {
            string[] temp = new string[1];

            Reader.read(name, out temp);
            for (int i = 0; i < temp.Length; i++)
            {
                arr[i] = Convert.ToInt32(temp[i]);
            }
        }

        private void _getArrFromStr(string data, ref int[] arr)
        {
            string[] temp = new string[1000];

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
            }
        }

        private void processUser()
        {
            int[] arr = new int[10];

            try
            {
                _getArrFromUser(ref arr);
            }
            catch (Exception e)
            {
                unhideError(e.Message);
                return;
            }

            // TODO:
        }

        private void _getArrFromUser(ref int[] arr)
        {
            string data, name;

            if (this.radioButton1.Checked)
                name = "own1";
            else if (this.radioButton2.Checked)
                name = "own2";
            else
                name = "own3";

            data = this.Controls[name].Text;

            _getArrFromStr(data, ref arr);
        }

        private void fillUI(string name, int[] arr)
        {
            this.Controls[name].Text = createStr(arr, 10);
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
