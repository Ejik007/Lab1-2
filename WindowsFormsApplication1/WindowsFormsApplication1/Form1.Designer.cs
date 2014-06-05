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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ValueMu = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ValueLyamda = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ValueM = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ValueN = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ValuesM = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.m5 = new System.Windows.Forms.NumericUpDown();
            this.m4 = new System.Windows.Forms.NumericUpDown();
            this.m3 = new System.Windows.Forms.NumericUpDown();
            this.m2 = new System.Windows.Forms.NumericUpDown();
            this.m1 = new System.Windows.Forms.NumericUpDown();
            this.ValuesN = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.n5 = new System.Windows.Forms.NumericUpDown();
            this.n4 = new System.Windows.Forms.NumericUpDown();
            this.n3 = new System.Windows.Forms.NumericUpDown();
            this.n2 = new System.Windows.Forms.NumericUpDown();
            this.n1 = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonM = new System.Windows.Forms.RadioButton();
            this.radioButtonN = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ValueMu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ValueLyamda);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ValueM);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ValueN);
            this.groupBox1.Location = new System.Drawing.Point(668, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Основные параметры";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Интенсивность обслуживания";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Интенсивность входного потока";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Места в очереди";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Каналы обслуживания";
            // 
            // ValueMu
            // 
            this.ValueMu.Location = new System.Drawing.Point(208, 96);
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
            this.ValueMu.Size = new System.Drawing.Size(35, 20);
            this.ValueMu.TabIndex = 7;
            this.ValueMu.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "μ";
            // 
            // ValueLyamda
            // 
            this.ValueLyamda.Location = new System.Drawing.Point(208, 70);
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
            this.ValueLyamda.Size = new System.Drawing.Size(35, 20);
            this.ValueLyamda.TabIndex = 5;
            this.ValueLyamda.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "λ";
            // 
            // ValueM
            // 
            this.ValueM.Location = new System.Drawing.Point(208, 44);
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
            this.ValueM.Size = new System.Drawing.Size(35, 20);
            this.ValueM.TabIndex = 3;
            this.ValueM.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "m";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "n";
            // 
            // ValueN
            // 
            this.ValueN.Location = new System.Drawing.Point(208, 18);
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
            this.ValueN.Size = new System.Drawing.Size(35, 20);
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
            this.groupBox2.Location = new System.Drawing.Point(668, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 211);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Варьируемые параметры n";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // ValuesM
            // 
            this.ValuesM.Controls.Add(this.label19);
            this.ValuesM.Controls.Add(this.label18);
            this.ValuesM.Controls.Add(this.label17);
            this.ValuesM.Controls.Add(this.label16);
            this.ValuesM.Controls.Add(this.label15);
            this.ValuesM.Controls.Add(this.m5);
            this.ValuesM.Controls.Add(this.m4);
            this.ValuesM.Controls.Add(this.m3);
            this.ValuesM.Controls.Add(this.m2);
            this.ValuesM.Controls.Add(this.m1);
            this.ValuesM.Location = new System.Drawing.Point(128, 49);
            this.ValuesM.Name = "ValuesM";
            this.ValuesM.Size = new System.Drawing.Size(111, 154);
            this.ValuesM.TabIndex = 2;
            this.ValuesM.TabStop = false;
            this.ValuesM.Text = "Значения m";
            this.ValuesM.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(35, 125);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(24, 13);
            this.label19.TabIndex = 13;
            this.label19.Text = "m 5";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(35, 99);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "m 4";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(35, 73);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "m 3";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(35, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "m 2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(35, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "m 1";
            // 
            // m5
            // 
            this.m5.Location = new System.Drawing.Point(70, 123);
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
            this.m5.Size = new System.Drawing.Size(35, 20);
            this.m5.TabIndex = 8;
            this.m5.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // m4
            // 
            this.m4.Location = new System.Drawing.Point(70, 97);
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
            this.m4.Size = new System.Drawing.Size(35, 20);
            this.m4.TabIndex = 7;
            this.m4.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // m3
            // 
            this.m3.Location = new System.Drawing.Point(70, 71);
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
            this.m3.Size = new System.Drawing.Size(35, 20);
            this.m3.TabIndex = 6;
            this.m3.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // m2
            // 
            this.m2.Location = new System.Drawing.Point(70, 45);
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
            this.m2.Size = new System.Drawing.Size(35, 20);
            this.m2.TabIndex = 5;
            this.m2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // m1
            // 
            this.m1.Location = new System.Drawing.Point(70, 19);
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
            this.m1.Size = new System.Drawing.Size(35, 20);
            this.m1.TabIndex = 4;
            this.m1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ValuesN
            // 
            this.ValuesN.Controls.Add(this.label14);
            this.ValuesN.Controls.Add(this.label13);
            this.ValuesN.Controls.Add(this.label12);
            this.ValuesN.Controls.Add(this.label11);
            this.ValuesN.Controls.Add(this.label10);
            this.ValuesN.Controls.Add(this.n5);
            this.ValuesN.Controls.Add(this.n4);
            this.ValuesN.Controls.Add(this.n3);
            this.ValuesN.Controls.Add(this.n2);
            this.ValuesN.Controls.Add(this.n1);
            this.ValuesN.Location = new System.Drawing.Point(11, 49);
            this.ValuesN.Name = "ValuesN";
            this.ValuesN.Size = new System.Drawing.Size(111, 154);
            this.ValuesN.TabIndex = 1;
            this.ValuesN.TabStop = false;
            this.ValuesN.Text = "Значения n";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(36, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "n 5";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(36, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "n 4";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "n 3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "n 2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "n 1";
            // 
            // n5
            // 
            this.n5.Location = new System.Drawing.Point(70, 123);
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
            this.n5.Size = new System.Drawing.Size(35, 20);
            this.n5.TabIndex = 6;
            this.n5.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // n4
            // 
            this.n4.Location = new System.Drawing.Point(70, 97);
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
            this.n4.Size = new System.Drawing.Size(35, 20);
            this.n4.TabIndex = 5;
            this.n4.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // n3
            // 
            this.n3.Location = new System.Drawing.Point(70, 71);
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
            this.n3.Size = new System.Drawing.Size(35, 20);
            this.n3.TabIndex = 4;
            this.n3.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // n2
            // 
            this.n2.Location = new System.Drawing.Point(70, 45);
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
            this.n2.Size = new System.Drawing.Size(35, 20);
            this.n2.TabIndex = 3;
            this.n2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // n1
            // 
            this.n1.Location = new System.Drawing.Point(70, 19);
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
            this.n1.Size = new System.Drawing.Size(35, 20);
            this.n1.TabIndex = 2;
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
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(11, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 24);
            this.panel1.TabIndex = 0;
            // 
            // radioButtonM
            // 
            this.radioButtonM.AutoSize = true;
            this.radioButtonM.Location = new System.Drawing.Point(155, 3);
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
            this.radioButtonN.Location = new System.Drawing.Point(39, 3);
            this.radioButtonN.Name = "radioButtonN";
            this.radioButtonN.Size = new System.Drawing.Size(31, 17);
            this.radioButtonN.TabIndex = 1;
            this.radioButtonN.TabStop = true;
            this.radioButtonN.Text = "n";
            this.radioButtonN.UseVisualStyleBackColor = true;
            this.radioButtonN.CheckedChanged += new System.EventHandler(this.radioButtonN_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(76, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Варьировать";
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
            this.zedGraphControl1.Size = new System.Drawing.Size(650, 393);
            this.zedGraphControl1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(758, 361);
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
            this.ClientSize = new System.Drawing.Size(929, 417);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
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

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown ValueM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ValueN;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown ValueLyamda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown ValueMu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonM;
        private System.Windows.Forms.RadioButton radioButtonN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox ValuesM;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown m5;
        private System.Windows.Forms.NumericUpDown m4;
        private System.Windows.Forms.NumericUpDown m3;
        private System.Windows.Forms.NumericUpDown m2;
        private System.Windows.Forms.NumericUpDown m1;
        private System.Windows.Forms.GroupBox ValuesN;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown n5;
        private System.Windows.Forms.NumericUpDown n4;
        private System.Windows.Forms.NumericUpDown n3;
        private System.Windows.Forms.NumericUpDown n2;
        private System.Windows.Forms.NumericUpDown n1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button button1;
    }
}

