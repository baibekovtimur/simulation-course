namespace lab2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.edThickness = new System.Windows.Forms.NumericUpDown();
            this.edNodes = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.edTimeStep = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.edTempLeft = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.edTempRight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.edTemp = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.edAlpha = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.edEndTime = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.btmStart = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblCenterTemp = new System.Windows.Forms.Label();
            this.lblSimTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.edThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edNodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edTimeStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edTempLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edTempRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thickness:";
            // 
            // edThickness
            // 
            this.edThickness.DecimalPlaces = 3;
            this.edThickness.Location = new System.Drawing.Point(77, 12);
            this.edThickness.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.edThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.edThickness.Name = "edThickness";
            this.edThickness.Size = new System.Drawing.Size(83, 20);
            this.edThickness.TabIndex = 1;
            this.edThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // edNodes
            // 
            this.edNodes.Location = new System.Drawing.Point(77, 40);
            this.edNodes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.edNodes.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.edNodes.Name = "edNodes";
            this.edNodes.Size = new System.Drawing.Size(83, 20);
            this.edNodes.TabIndex = 3;
            this.edNodes.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nodes:";
            // 
            // edTimeStep
            // 
            this.edTimeStep.DecimalPlaces = 4;
            this.edTimeStep.Location = new System.Drawing.Point(77, 69);
            this.edTimeStep.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edTimeStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.edTimeStep.Name = "edTimeStep";
            this.edTimeStep.Size = new System.Drawing.Size(83, 20);
            this.edTimeStep.TabIndex = 5;
            this.edTimeStep.Value = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time step:";
            // 
            // edTempLeft
            // 
            this.edTempLeft.Location = new System.Drawing.Point(286, 12);
            this.edTempLeft.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edTempLeft.Name = "edTempLeft";
            this.edTempLeft.Size = new System.Drawing.Size(83, 20);
            this.edTempLeft.TabIndex = 7;
            this.edTempLeft.Value = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Temperature left:";
            // 
            // edTempRight
            // 
            this.edTempRight.Location = new System.Drawing.Point(286, 40);
            this.edTempRight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edTempRight.Name = "edTempRight";
            this.edTempRight.Size = new System.Drawing.Size(83, 20);
            this.edTempRight.TabIndex = 9;
            this.edTempRight.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Temperature right:";
            // 
            // edTemp
            // 
            this.edTemp.Location = new System.Drawing.Point(286, 69);
            this.edTemp.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.edTemp.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edTemp.Name = "edTemp";
            this.edTemp.Size = new System.Drawing.Size(83, 20);
            this.edTemp.TabIndex = 11;
            this.edTemp.Value = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Temperature:";
            // 
            // edAlpha
            // 
            this.edAlpha.DecimalPlaces = 7;
            this.edAlpha.Location = new System.Drawing.Point(460, 12);
            this.edAlpha.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.edAlpha.Name = "edAlpha";
            this.edAlpha.Size = new System.Drawing.Size(111, 20);
            this.edAlpha.TabIndex = 13;
            this.edAlpha.Value = new decimal(new int[] {
            10,
            0,
            0,
            196608});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(395, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Alpha:";
            // 
            // edEndTime
            // 
            this.edEndTime.Location = new System.Drawing.Point(460, 40);
            this.edEndTime.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.edEndTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edEndTime.Name = "edEndTime";
            this.edEndTime.Size = new System.Drawing.Size(83, 20);
            this.edEndTime.TabIndex = 15;
            this.edEndTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(395, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "End Time:";
            // 
            // btmStart
            // 
            this.btmStart.Location = new System.Drawing.Point(610, 15);
            this.btmStart.Name = "btmStart";
            this.btmStart.Size = new System.Drawing.Size(75, 23);
            this.btmStart.TabIndex = 16;
            this.btmStart.Text = "Launch";
            this.btmStart.UseVisualStyleBackColor = true;
            this.btmStart.Click += new System.EventHandler(this.btmStart_Click);
            // 
            // chart1
            // 
            chartArea13.AxisY.Maximum = 100D;
            chartArea13.AxisY.Minimum = -100D;
            chartArea13.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea13);
            legend13.Enabled = false;
            legend13.Name = "Legend1";
            this.chart1.Legends.Add(legend13);
            this.chart1.Location = new System.Drawing.Point(15, 127);
            this.chart1.Name = "chart1";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.Legend = "Legend1";
            series13.Name = "Temperature";
            this.chart1.Series.Add(series13);
            this.chart1.Size = new System.Drawing.Size(536, 300);
            this.chart1.TabIndex = 17;
            this.chart1.Text = "chart1";
            // 
            // lblCenterTemp
            // 
            this.lblCenterTemp.AutoSize = true;
            this.lblCenterTemp.Location = new System.Drawing.Point(561, 147);
            this.lblCenterTemp.Name = "lblCenterTemp";
            this.lblCenterTemp.Size = new System.Drawing.Size(124, 13);
            this.lblCenterTemp.TabIndex = 18;
            this.lblCenterTemp.Text = "Температура в центре:";
            // 
            // lblSimTime
            // 
            this.lblSimTime.AutoSize = true;
            this.lblSimTime.Location = new System.Drawing.Point(561, 181);
            this.lblSimTime.Name = "lblSimTime";
            this.lblSimTime.Size = new System.Drawing.Size(101, 13);
            this.lblSimTime.TabIndex = 19;
            this.lblSimTime.Text = "Время симуляции:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSimTime);
            this.Controls.Add(this.lblCenterTemp);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btmStart);
            this.Controls.Add(this.edEndTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.edAlpha);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edTemp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edTempRight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edTempLeft);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edTimeStep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edNodes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edThickness);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edNodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edTimeStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edTempLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edTempRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown edThickness;
        private System.Windows.Forms.NumericUpDown edNodes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown edTimeStep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown edTempLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown edTempRight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown edTemp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown edAlpha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown edEndTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btmStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblCenterTemp;
        private System.Windows.Forms.Label lblSimTime;
    }
}

