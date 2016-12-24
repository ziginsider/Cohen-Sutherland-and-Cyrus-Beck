namespace Laba1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel_draw = new System.Windows.Forms.Panel();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_x1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_x2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_x3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_y1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_y2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_y3 = new System.Windows.Forms.NumericUpDown();
            this.timer_start = new System.Windows.Forms.Timer(this.components);
            this.checkBox_clear = new System.Windows.Forms.CheckBox();
            this.trackBar_pen = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown_rmin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_rmax = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDown_smin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_smax = new System.Windows.Forms.NumericUpDown();
            this.checkBox_scale = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDown_coef = new System.Windows.Forms.NumericUpDown();
            this.trackBar_speedanimate = new System.Windows.Forms.TrackBar();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_l3 = new System.Windows.Forms.RadioButton();
            this.radioButton_l2 = new System.Windows.Forms.RadioButton();
            this.radioButton_l1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_x1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_x2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_x3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_y1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_y2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_y3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_pen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_rmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_rmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_smin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_smax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_coef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_speedanimate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_draw
            // 
            this.panel_draw.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_draw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_draw.Location = new System.Drawing.Point(12, 2);
            this.panel_draw.Name = "panel_draw";
            this.panel_draw.Size = new System.Drawing.Size(1400, 700);
            this.panel_draw.TabIndex = 0;
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(255, 721);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(148, 46);
            this.button_start.TabIndex = 1;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(255, 782);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(148, 46);
            this.button_stop.TabIndex = 1;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(424, 717);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Координаты треугольника ABC:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 745);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "A  x:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 775);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "B  x:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(423, 806);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "C  x:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(545, 745);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(545, 775);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "y:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(545, 806);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "y:";
            // 
            // numericUpDown_x1
            // 
            this.numericUpDown_x1.Location = new System.Drawing.Point(465, 745);
            this.numericUpDown_x1.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.numericUpDown_x1.Name = "numericUpDown_x1";
            this.numericUpDown_x1.Size = new System.Drawing.Size(63, 22);
            this.numericUpDown_x1.TabIndex = 5;
            // 
            // numericUpDown_x2
            // 
            this.numericUpDown_x2.Location = new System.Drawing.Point(465, 775);
            this.numericUpDown_x2.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.numericUpDown_x2.Name = "numericUpDown_x2";
            this.numericUpDown_x2.Size = new System.Drawing.Size(63, 22);
            this.numericUpDown_x2.TabIndex = 5;
            // 
            // numericUpDown_x3
            // 
            this.numericUpDown_x3.Location = new System.Drawing.Point(464, 806);
            this.numericUpDown_x3.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.numericUpDown_x3.Name = "numericUpDown_x3";
            this.numericUpDown_x3.Size = new System.Drawing.Size(63, 22);
            this.numericUpDown_x3.TabIndex = 5;
            // 
            // numericUpDown_y1
            // 
            this.numericUpDown_y1.Location = new System.Drawing.Point(570, 745);
            this.numericUpDown_y1.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown_y1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_y1.Name = "numericUpDown_y1";
            this.numericUpDown_y1.Size = new System.Drawing.Size(63, 22);
            this.numericUpDown_y1.TabIndex = 5;
            this.numericUpDown_y1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown_y2
            // 
            this.numericUpDown_y2.Location = new System.Drawing.Point(570, 775);
            this.numericUpDown_y2.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown_y2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_y2.Name = "numericUpDown_y2";
            this.numericUpDown_y2.Size = new System.Drawing.Size(63, 22);
            this.numericUpDown_y2.TabIndex = 5;
            this.numericUpDown_y2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown_y3
            // 
            this.numericUpDown_y3.Location = new System.Drawing.Point(570, 806);
            this.numericUpDown_y3.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown_y3.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_y3.Name = "numericUpDown_y3";
            this.numericUpDown_y3.Size = new System.Drawing.Size(63, 22);
            this.numericUpDown_y3.TabIndex = 5;
            this.numericUpDown_y3.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // timer_start
            // 
            this.timer_start.Interval = 50;
            this.timer_start.Tick += new System.EventHandler(this.timer_start_Tick);
            // 
            // checkBox_clear
            // 
            this.checkBox_clear.AutoSize = true;
            this.checkBox_clear.Location = new System.Drawing.Point(664, 722);
            this.checkBox_clear.Name = "checkBox_clear";
            this.checkBox_clear.Size = new System.Drawing.Size(207, 21);
            this.checkBox_clear.TabIndex = 6;
            this.checkBox_clear.Text = "отображать все состояния";
            this.checkBox_clear.UseVisualStyleBackColor = true;
            // 
            // trackBar_pen
            // 
            this.trackBar_pen.Location = new System.Drawing.Point(653, 795);
            this.trackBar_pen.Maximum = 5;
            this.trackBar_pen.Minimum = 1;
            this.trackBar_pen.Name = "trackBar_pen";
            this.trackBar_pen.Size = new System.Drawing.Size(160, 56);
            this.trackBar_pen.TabIndex = 7;
            this.trackBar_pen.Value = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(661, 767);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Толщина пера:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(876, 721);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(217, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Пределы значений рандомного";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(876, 739);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "смещения фигуры за шаг:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(876, 767);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "По оси X (r):";
            // 
            // numericUpDown_rmin
            // 
            this.numericUpDown_rmin.Location = new System.Drawing.Point(971, 767);
            this.numericUpDown_rmin.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown_rmin.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numericUpDown_rmin.Name = "numericUpDown_rmin";
            this.numericUpDown_rmin.Size = new System.Drawing.Size(63, 22);
            this.numericUpDown_rmin.TabIndex = 5;
            // 
            // numericUpDown_rmax
            // 
            this.numericUpDown_rmax.Location = new System.Drawing.Point(1050, 767);
            this.numericUpDown_rmax.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_rmax.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            -2147483648});
            this.numericUpDown_rmax.Name = "numericUpDown_rmax";
            this.numericUpDown_rmax.Size = new System.Drawing.Size(63, 22);
            this.numericUpDown_rmax.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(876, 804);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "По оси Y (s):";
            // 
            // numericUpDown_smin
            // 
            this.numericUpDown_smin.Location = new System.Drawing.Point(971, 804);
            this.numericUpDown_smin.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown_smin.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numericUpDown_smin.Name = "numericUpDown_smin";
            this.numericUpDown_smin.Size = new System.Drawing.Size(63, 22);
            this.numericUpDown_smin.TabIndex = 5;
            // 
            // numericUpDown_smax
            // 
            this.numericUpDown_smax.Location = new System.Drawing.Point(1050, 804);
            this.numericUpDown_smax.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_smax.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            -2147483648});
            this.numericUpDown_smax.Name = "numericUpDown_smax";
            this.numericUpDown_smax.Size = new System.Drawing.Size(63, 22);
            this.numericUpDown_smax.TabIndex = 5;
            // 
            // checkBox_scale
            // 
            this.checkBox_scale.AutoSize = true;
            this.checkBox_scale.Location = new System.Drawing.Point(1148, 722);
            this.checkBox_scale.Name = "checkBox_scale";
            this.checkBox_scale.Size = new System.Drawing.Size(164, 21);
            this.checkBox_scale.TabIndex = 6;
            this.checkBox_scale.Text = "уменьшать масштаб";
            this.checkBox_scale.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1145, 750);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(191, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "Коэффициент уменьшения:";
            // 
            // numericUpDown_coef
            // 
            this.numericUpDown_coef.Location = new System.Drawing.Point(1342, 750);
            this.numericUpDown_coef.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown_coef.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_coef.Name = "numericUpDown_coef";
            this.numericUpDown_coef.Size = new System.Drawing.Size(63, 22);
            this.numericUpDown_coef.TabIndex = 5;
            this.numericUpDown_coef.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // trackBar_speedanimate
            // 
            this.trackBar_speedanimate.LargeChange = 10;
            this.trackBar_speedanimate.Location = new System.Drawing.Point(1138, 795);
            this.trackBar_speedanimate.Minimum = 1;
            this.trackBar_speedanimate.Name = "trackBar_speedanimate";
            this.trackBar_speedanimate.Size = new System.Drawing.Size(277, 56);
            this.trackBar_speedanimate.TabIndex = 9;
            this.trackBar_speedanimate.Value = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1145, 775);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(142, 17);
            this.label14.TabIndex = 8;
            this.label14.Text = "Скорость анимации:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_l3);
            this.groupBox1.Controls.Add(this.radioButton_l2);
            this.groupBox1.Controls.Add(this.radioButton_l1);
            this.groupBox1.Location = new System.Drawing.Point(16, 717);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 110);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Задания";
            // 
            // radioButton_l3
            // 
            this.radioButton_l3.AutoSize = true;
            this.radioButton_l3.Location = new System.Drawing.Point(6, 83);
            this.radioButton_l3.Name = "radioButton_l3";
            this.radioButton_l3.Size = new System.Drawing.Size(117, 21);
            this.radioButton_l3.TabIndex = 2;
            this.radioButton_l3.TabStop = true;
            this.radioButton_l3.Text = "Лаб. раб. №5";
            this.radioButton_l3.UseVisualStyleBackColor = true;
            // 
            // radioButton_l2
            // 
            this.radioButton_l2.AutoSize = true;
            this.radioButton_l2.Location = new System.Drawing.Point(6, 56);
            this.radioButton_l2.Name = "radioButton_l2";
            this.radioButton_l2.Size = new System.Drawing.Size(117, 21);
            this.radioButton_l2.TabIndex = 1;
            this.radioButton_l2.TabStop = true;
            this.radioButton_l2.Text = "Лаб. раб. №4";
            this.radioButton_l2.UseVisualStyleBackColor = true;
            // 
            // radioButton_l1
            // 
            this.radioButton_l1.AutoSize = true;
            this.radioButton_l1.Location = new System.Drawing.Point(6, 28);
            this.radioButton_l1.Name = "radioButton_l1";
            this.radioButton_l1.Size = new System.Drawing.Size(117, 21);
            this.radioButton_l1.TabIndex = 0;
            this.radioButton_l1.TabStop = true;
            this.radioButton_l1.Text = "Лаб. раб. №1";
            this.radioButton_l1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 845);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trackBar_speedanimate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.trackBar_pen);
            this.Controls.Add(this.checkBox_scale);
            this.Controls.Add(this.checkBox_clear);
            this.Controls.Add(this.numericUpDown_x3);
            this.Controls.Add(this.numericUpDown_x2);
            this.Controls.Add(this.numericUpDown_y3);
            this.Controls.Add(this.numericUpDown_y2);
            this.Controls.Add(this.numericUpDown_smax);
            this.Controls.Add(this.numericUpDown_smin);
            this.Controls.Add(this.numericUpDown_coef);
            this.Controls.Add(this.numericUpDown_rmax);
            this.Controls.Add(this.numericUpDown_rmin);
            this.Controls.Add(this.numericUpDown_y1);
            this.Controls.Add(this.numericUpDown_x1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.panel_draw);
            this.Name = "Form1";
            this.Text = "AKG BSUIR Lab 1 var 13, Lab 4 var 6, Lab 5 var 2 Marina Lynx";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_x1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_x2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_x3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_y1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_y2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_y3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_pen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_rmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_rmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_smin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_smax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_coef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_speedanimate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_draw;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown_x1;
        private System.Windows.Forms.NumericUpDown numericUpDown_x2;
        private System.Windows.Forms.NumericUpDown numericUpDown_x3;
        private System.Windows.Forms.NumericUpDown numericUpDown_y1;
        private System.Windows.Forms.NumericUpDown numericUpDown_y2;
        private System.Windows.Forms.NumericUpDown numericUpDown_y3;
        private System.Windows.Forms.Timer timer_start;
        private System.Windows.Forms.CheckBox checkBox_clear;
        private System.Windows.Forms.TrackBar trackBar_pen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown_rmin;
        private System.Windows.Forms.NumericUpDown numericUpDown_rmax;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDown_smin;
        private System.Windows.Forms.NumericUpDown numericUpDown_smax;
        private System.Windows.Forms.CheckBox checkBox_scale;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDown_coef;
        private System.Windows.Forms.TrackBar trackBar_speedanimate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_l3;
        private System.Windows.Forms.RadioButton radioButton_l2;
        private System.Windows.Forms.RadioButton radioButton_l1;
    }
}

