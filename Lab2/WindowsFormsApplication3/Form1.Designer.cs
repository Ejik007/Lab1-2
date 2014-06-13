namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ValueMu = new System.Windows.Forms.NumericUpDown();
            this.ValueLyamda = new System.Windows.Forms.NumericUpDown();
            this.ValueM = new System.Windows.Forms.NumericUpDown();
            this.ValueN = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ValuesM = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.m5 = new System.Windows.Forms.NumericUpDown();
            this.m4 = new System.Windows.Forms.NumericUpDown();
            this.m3 = new System.Windows.Forms.NumericUpDown();
            this.m2 = new System.Windows.Forms.NumericUpDown();
            this.m1 = new System.Windows.Forms.NumericUpDown();
            this.ValuesN = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.n5 = new System.Windows.Forms.NumericUpDown();
            this.n4 = new System.Windows.Forms.NumericUpDown();
            this.n3 = new System.Windows.Forms.NumericUpDown();
            this.n2 = new System.Windows.Forms.NumericUpDown();
            this.n1 = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonM = new System.Windows.Forms.RadioButton();
            this.radioButtonN = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValueMu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueLyamda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueN)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.ValuesM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m1)).BeginInit();
            this.ValuesN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(665, 382);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ValueMu);
            this.groupBox1.Controls.Add(this.ValueLyamda);
            this.groupBox1.Controls.Add(this.ValueM);
            this.groupBox1.Controls.Add(this.ValueN);
            this.groupBox1.Location = new System.Drawing.Point(683, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 128);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Основные параметры";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Интенсивность обслуживания  μ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Интенсивность входного потока  λ ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Места в очереди  m";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Каналы обслуживания   n";
            // 
            // ValueMu
            // 
            this.ValueMu.Location = new System.Drawing.Point(203, 97);
            this.ValueMu.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ValueMu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ValueMu.Name = "ValueMu";
            this.ValueMu.Size = new System.Drawing.Size(34, 20);
            this.ValueMu.TabIndex = 3;
            this.ValueMu.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // ValueLyamda
            // 
            this.ValueLyamda.Location = new System.Drawing.Point(203, 71);
            this.ValueLyamda.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.ValueLyamda.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ValueLyamda.Name = "ValueLyamda";
            this.ValueLyamda.Size = new System.Drawing.Size(34, 20);
            this.ValueLyamda.TabIndex = 2;
            this.ValueLyamda.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ValueM
            // 
            this.ValueM.Location = new System.Drawing.Point(203, 45);
            this.ValueM.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.ValueM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ValueM.Name = "ValueM";
            this.ValueM.Size = new System.Drawing.Size(34, 20);
            this.ValueM.TabIndex = 1;
            this.ValueM.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // ValueN
            // 
            this.ValueN.Location = new System.Drawing.Point(203, 19);
            this.ValueN.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.ValueN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ValueN.Name = "ValueN";
            this.ValueN.Size = new System.Drawing.Size(34, 20);
            this.ValueN.TabIndex = 0;
            this.ValueN.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ValuesM);
            this.groupBox2.Controls.Add(this.ValuesN);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(683, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 219);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Варьируемые параметры";
            // 
            // ValuesM
            // 
            this.ValuesM.Controls.Add(this.label11);
            this.ValuesM.Controls.Add(this.label12);
            this.ValuesM.Controls.Add(this.label13);
            this.ValuesM.Controls.Add(this.label14);
            this.ValuesM.Controls.Add(this.label15);
            this.ValuesM.Controls.Add(this.m5);
            this.ValuesM.Controls.Add(this.m4);
            this.ValuesM.Controls.Add(this.m3);
            this.ValuesM.Controls.Add(this.m2);
            this.ValuesM.Controls.Add(this.m1);
            this.ValuesM.Location = new System.Drawing.Point(125, 62);
            this.ValuesM.Name = "ValuesM";
            this.ValuesM.Size = new System.Drawing.Size(112, 151);
            this.ValuesM.TabIndex = 2;
            this.ValuesM.TabStop = false;
            this.ValuesM.Text = "Значения m";
            this.ValuesM.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "m 5";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "m 4";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(44, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "m 3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(44, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "m 2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(44, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 13);
            this.label15.TabIndex = 11;
            this.label15.Text = "m 1";
            // 
            // m5
            // 
            this.m5.Location = new System.Drawing.Point(72, 123);
            this.m5.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.m5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m5.Name = "m5";
            this.m5.Size = new System.Drawing.Size(34, 20);
            this.m5.TabIndex = 10;
            this.m5.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // m4
            // 
            this.m4.Location = new System.Drawing.Point(72, 97);
            this.m4.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.m4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m4.Name = "m4";
            this.m4.Size = new System.Drawing.Size(34, 20);
            this.m4.TabIndex = 9;
            this.m4.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // m3
            // 
            this.m3.Location = new System.Drawing.Point(72, 71);
            this.m3.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.m3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m3.Name = "m3";
            this.m3.Size = new System.Drawing.Size(34, 20);
            this.m3.TabIndex = 8;
            this.m3.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // m2
            // 
            this.m2.Location = new System.Drawing.Point(72, 45);
            this.m2.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.m2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m2.Name = "m2";
            this.m2.Size = new System.Drawing.Size(34, 20);
            this.m2.TabIndex = 7;
            this.m2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // m1
            // 
            this.m1.Location = new System.Drawing.Point(72, 19);
            this.m1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.m1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m1.Name = "m1";
            this.m1.Size = new System.Drawing.Size(34, 20);
            this.m1.TabIndex = 6;
            this.m1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ValuesN
            // 
            this.ValuesN.Controls.Add(this.label10);
            this.ValuesN.Controls.Add(this.label9);
            this.ValuesN.Controls.Add(this.label8);
            this.ValuesN.Controls.Add(this.label7);
            this.ValuesN.Controls.Add(this.label6);
            this.ValuesN.Controls.Add(this.n5);
            this.ValuesN.Controls.Add(this.n4);
            this.ValuesN.Controls.Add(this.n3);
            this.ValuesN.Controls.Add(this.n2);
            this.ValuesN.Controls.Add(this.n1);
            this.ValuesN.Location = new System.Drawing.Point(6, 62);
            this.ValuesN.Name = "ValuesN";
            this.ValuesN.Size = new System.Drawing.Size(112, 151);
            this.ValuesN.TabIndex = 1;
            this.ValuesN.TabStop = false;
            this.ValuesN.Text = "Значения n";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "n 5";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "n 4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "n 3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "n 2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "n 1";
            // 
            // n5
            // 
            this.n5.Location = new System.Drawing.Point(72, 123);
            this.n5.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.n5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.n5.Name = "n5";
            this.n5.Size = new System.Drawing.Size(34, 20);
            this.n5.TabIndex = 5;
            this.n5.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // n4
            // 
            this.n4.Location = new System.Drawing.Point(72, 97);
            this.n4.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.n4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.n4.Name = "n4";
            this.n4.Size = new System.Drawing.Size(34, 20);
            this.n4.TabIndex = 4;
            this.n4.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // n3
            // 
            this.n3.Location = new System.Drawing.Point(72, 71);
            this.n3.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.n3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.n3.Name = "n3";
            this.n3.Size = new System.Drawing.Size(34, 20);
            this.n3.TabIndex = 3;
            this.n3.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // n2
            // 
            this.n2.Location = new System.Drawing.Point(72, 45);
            this.n2.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.n2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.n2.Name = "n2";
            this.n2.Size = new System.Drawing.Size(34, 20);
            this.n2.TabIndex = 2;
            this.n2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // n1
            // 
            this.n1.Location = new System.Drawing.Point(72, 19);
            this.n1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.n1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.n1.Name = "n1";
            this.n1.Size = new System.Drawing.Size(34, 20);
            this.n1.TabIndex = 1;
            this.n1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonM);
            this.panel1.Controls.Add(this.radioButtonN);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 37);
            this.panel1.TabIndex = 0;
            // 
            // radioButtonM
            // 
            this.radioButtonM.AutoSize = true;
            this.radioButtonM.Location = new System.Drawing.Point(164, 16);
            this.radioButtonM.Name = "radioButtonM";
            this.radioButtonM.Size = new System.Drawing.Size(33, 17);
            this.radioButtonM.TabIndex = 2;
            this.radioButtonM.Text = "m";
            this.radioButtonM.UseVisualStyleBackColor = true;
            this.radioButtonM.CheckedChanged += new System.EventHandler(this.radioButtonM_CheckedChanged);
            // 
            // radioButtonN
            // 
            this.radioButtonN.AutoSize = true;
            this.radioButtonN.Checked = true;
            this.radioButtonN.Location = new System.Drawing.Point(48, 16);
            this.radioButtonN.Name = "radioButtonN";
            this.radioButtonN.Size = new System.Drawing.Size(31, 17);
            this.radioButtonN.TabIndex = 1;
            this.radioButtonN.TabStop = true;
            this.radioButtonN.Text = "n";
            this.radioButtonN.UseVisualStyleBackColor = true;
            this.radioButtonN.CheckedChanged += new System.EventHandler(this.radioButtonN_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Варьировать";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(777, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Вычислить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 403);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Form1";
            this.Text = "Значения n";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValueMu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueLyamda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueN)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ValuesM.ResumeLayout(false);
            this.ValuesM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m1)).EndInit();
            this.ValuesN.ResumeLayout(false);
            this.ValuesN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ValueMu;
        private System.Windows.Forms.NumericUpDown ValueLyamda;
        private System.Windows.Forms.NumericUpDown ValueM;
        private System.Windows.Forms.NumericUpDown ValueN;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox ValuesM;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown m5;
        private System.Windows.Forms.NumericUpDown m4;
        private System.Windows.Forms.NumericUpDown m3;
        private System.Windows.Forms.NumericUpDown m2;
        private System.Windows.Forms.NumericUpDown m1;
        private System.Windows.Forms.GroupBox ValuesN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown n5;
        private System.Windows.Forms.NumericUpDown n4;
        private System.Windows.Forms.NumericUpDown n3;
        private System.Windows.Forms.NumericUpDown n2;
        private System.Windows.Forms.NumericUpDown n1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonM;
        private System.Windows.Forms.RadioButton radioButtonN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}

