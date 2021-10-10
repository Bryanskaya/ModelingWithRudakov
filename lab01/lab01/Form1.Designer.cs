namespace lab01
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.paramsEval = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.a = new System.Windows.Forms.TextBox();
            this.b = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.paramsNormal = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.sigma = new System.Windows.Forms.TextBox();
            this.mu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.paramsEval.SuspendLayout();
            this.paramsNormal.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(288, 31);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(594, 303);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            title1.Name = "Title1";
            title1.Text = "График функции плотности распределения";
            this.chart1.Titles.Add(title1);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(12, 31);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(247, 21);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Равномерное распределение";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.Location = new System.Drawing.Point(12, 58);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(239, 21);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "Нормальное распределение";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Location = new System.Drawing.Point(288, 349);
            this.chart2.Name = "chart2";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(594, 303);
            this.chart2.TabIndex = 3;
            this.chart2.Text = "chart2";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            title2.Name = "Title1";
            title2.Text = "График функции распределения";
            this.chart2.Titles.Add(title2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Параметры:";
            // 
            // paramsEval
            // 
            this.paramsEval.Controls.Add(this.label6);
            this.paramsEval.Controls.Add(this.b);
            this.paramsEval.Controls.Add(this.a);
            this.paramsEval.Controls.Add(this.label3);
            this.paramsEval.Controls.Add(this.label2);
            this.paramsEval.Location = new System.Drawing.Point(12, 181);
            this.paramsEval.Name = "paramsEval";
            this.paramsEval.Size = new System.Drawing.Size(236, 100);
            this.paramsEval.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "a:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "b:";
            // 
            // a
            // 
            this.a.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.a.Location = new System.Drawing.Point(40, 10);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(100, 23);
            this.a.TabIndex = 10;
            this.a.Text = "-5";
            // 
            // b
            // 
            this.b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b.Location = new System.Drawing.Point(40, 47);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(100, 23);
            this.b.TabIndex = 11;
            this.b.Text = "5";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(85, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "Готово";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(28, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "* при указании вещественного числа";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(28, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "   используйте запятую";
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.error.ForeColor = System.Drawing.Color.Red;
            this.error.Location = new System.Drawing.Point(8, 334);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(274, 17);
            this.error.TabIndex = 10;
            this.error.Text = "ОШИБКА: данные введены неверно";
            this.error.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(159, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "a < b";
            // 
            // paramsNormal
            // 
            this.paramsNormal.Controls.Add(this.label7);
            this.paramsNormal.Controls.Add(this.sigma);
            this.paramsNormal.Controls.Add(this.mu);
            this.paramsNormal.Controls.Add(this.label8);
            this.paramsNormal.Controls.Add(this.label9);
            this.paramsNormal.Location = new System.Drawing.Point(12, 181);
            this.paramsNormal.Name = "paramsNormal";
            this.paramsNormal.Size = new System.Drawing.Size(236, 100);
            this.paramsNormal.TabIndex = 13;
            this.paramsNormal.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(159, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "σ > 0";
            // 
            // sigma
            // 
            this.sigma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sigma.Location = new System.Drawing.Point(40, 47);
            this.sigma.Name = "sigma";
            this.sigma.Size = new System.Drawing.Size(100, 23);
            this.sigma.TabIndex = 11;
            this.sigma.Text = "1";
            // 
            // mu
            // 
            this.mu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mu.Location = new System.Drawing.Point(40, 10);
            this.mu.Name = "mu";
            this.mu.Size = new System.Drawing.Size(100, 23);
            this.mu.TabIndex = 10;
            this.mu.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "σ:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(12, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "μ:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 677);
            this.Controls.Add(this.paramsNormal);
            this.Controls.Add(this.error);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.paramsEval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Лабораторная работа 1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.paramsEval.ResumeLayout(false);
            this.paramsEval.PerformLayout();
            this.paramsNormal.ResumeLayout(false);
            this.paramsNormal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel paramsEval;
        private System.Windows.Forms.TextBox a;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox b;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel paramsNormal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox sigma;
        private System.Windows.Forms.TextBox mu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

