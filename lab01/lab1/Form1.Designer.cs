namespace lab1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBoxControls = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPlanet = new System.Windows.Forms.Label();
            this.comboBoxPlanet = new System.Windows.Forms.ComboBox();
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.edStep = new System.Windows.Forms.NumericUpDown();
            this.labelWeight = new System.Windows.Forms.Label();
            this.edWeight = new System.Windows.Forms.NumericUpDown();
            this.labelSize = new System.Windows.Forms.Label();
            this.edSize = new System.Windows.Forms.NumericUpDown();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.edSpeed = new System.Windows.Forms.NumericUpDown();
            this.labelAngle = new System.Windows.Forms.Label();
            this.edAngle = new System.Windows.Forms.NumericUpDown();
            this.labelHeight = new System.Windows.Forms.Label();
            this.edHeight = new System.Windows.Forms.NumericUpDown();
            this.groupBoxChart = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelDistance = new System.Windows.Forms.Label();
            this.labelDistanceValue = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelLastPointSpeed = new System.Windows.Forms.Label();
            this.labelLastPointSpeedValue = new System.Windows.Forms.Label();
            this.labelMaxHeight = new System.Windows.Forms.Label();
            this.labelMaxHeightValue = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edHeight)).BeginInit();
            this.groupBoxChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxControls
            // 
            this.groupBoxControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxControls.Controls.Add(this.label2);
            this.groupBoxControls.Controls.Add(this.labelPlanet);
            this.groupBoxControls.Controls.Add(this.comboBoxPlanet);
            this.groupBoxControls.Controls.Add(this.buttonLaunch);
            this.groupBoxControls.Controls.Add(this.label1);
            this.groupBoxControls.Controls.Add(this.edStep);
            this.groupBoxControls.Controls.Add(this.labelWeight);
            this.groupBoxControls.Controls.Add(this.edWeight);
            this.groupBoxControls.Controls.Add(this.labelSize);
            this.groupBoxControls.Controls.Add(this.edSize);
            this.groupBoxControls.Controls.Add(this.labelSpeed);
            this.groupBoxControls.Controls.Add(this.edSpeed);
            this.groupBoxControls.Controls.Add(this.labelAngle);
            this.groupBoxControls.Controls.Add(this.edAngle);
            this.groupBoxControls.Controls.Add(this.labelHeight);
            this.groupBoxControls.Controls.Add(this.edHeight);
            this.groupBoxControls.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBoxControls.Location = new System.Drawing.Point(12, 12);
            this.groupBoxControls.Name = "groupBoxControls";
            this.groupBoxControls.Size = new System.Drawing.Size(890, 123);
            this.groupBoxControls.TabIndex = 0;
            this.groupBoxControls.TabStop = false;
            this.groupBoxControls.Text = " Controls ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(455, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Affects only \"g\"";
            // 
            // labelPlanet
            // 
            this.labelPlanet.AutoSize = true;
            this.labelPlanet.Location = new System.Drawing.Point(392, 58);
            this.labelPlanet.Name = "labelPlanet";
            this.labelPlanet.Size = new System.Drawing.Size(40, 13);
            this.labelPlanet.TabIndex = 14;
            this.labelPlanet.Text = "Planet:";
            // 
            // comboBoxPlanet
            // 
            this.comboBoxPlanet.FormattingEnabled = true;
            this.comboBoxPlanet.Items.AddRange(new object[] {
            "Mercury",
            "Venus",
            "Earth",
            "Mars",
            "Jupiter",
            "Saturn",
            "Uranus",
            "Neptune"});
            this.comboBoxPlanet.Location = new System.Drawing.Point(433, 54);
            this.comboBoxPlanet.Name = "comboBoxPlanet";
            this.comboBoxPlanet.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPlanet.TabIndex = 13;
            this.comboBoxPlanet.Text = "Earth";
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonLaunch.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonLaunch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLaunch.ForeColor = System.Drawing.Color.Transparent;
            this.buttonLaunch.Image = ((System.Drawing.Image)(resources.GetObject("buttonLaunch.Image")));
            this.buttonLaunch.Location = new System.Drawing.Point(794, 23);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(80, 80);
            this.buttonLaunch.TabIndex = 12;
            this.buttonLaunch.UseVisualStyleBackColor = false;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(220, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Step:";
            // 
            // edStep
            // 
            this.edStep.DecimalPlaces = 4;
            this.edStep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edStep.Location = new System.Drawing.Point(265, 80);
            this.edStep.Name = "edStep";
            this.edStep.Size = new System.Drawing.Size(103, 20);
            this.edStep.TabIndex = 10;
            this.edStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelWeight.Location = new System.Drawing.Point(220, 57);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(44, 13);
            this.labelWeight.TabIndex = 9;
            this.labelWeight.Text = "Weight:";
            // 
            // edWeight
            // 
            this.edWeight.DecimalPlaces = 1;
            this.edWeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edWeight.Location = new System.Drawing.Point(265, 54);
            this.edWeight.Name = "edWeight";
            this.edWeight.Size = new System.Drawing.Size(103, 20);
            this.edWeight.TabIndex = 8;
            this.edWeight.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelSize.Location = new System.Drawing.Point(220, 31);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(30, 13);
            this.labelSize.TabIndex = 7;
            this.labelSize.Text = "Size:";
            // 
            // edSize
            // 
            this.edSize.DecimalPlaces = 1;
            this.edSize.Location = new System.Drawing.Point(265, 28);
            this.edSize.Name = "edSize";
            this.edSize.Size = new System.Drawing.Size(103, 20);
            this.edSize.TabIndex = 6;
            this.edSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelSpeed.Location = new System.Drawing.Point(38, 82);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(41, 13);
            this.labelSpeed.TabIndex = 5;
            this.labelSpeed.Text = "Speed:";
            // 
            // edSpeed
            // 
            this.edSpeed.Location = new System.Drawing.Point(83, 79);
            this.edSpeed.Name = "edSpeed";
            this.edSpeed.Size = new System.Drawing.Size(103, 20);
            this.edSpeed.TabIndex = 4;
            this.edSpeed.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // labelAngle
            // 
            this.labelAngle.AutoSize = true;
            this.labelAngle.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelAngle.Location = new System.Drawing.Point(38, 56);
            this.labelAngle.Name = "labelAngle";
            this.labelAngle.Size = new System.Drawing.Size(37, 13);
            this.labelAngle.TabIndex = 3;
            this.labelAngle.Text = "Angle:";
            // 
            // edAngle
            // 
            this.edAngle.Location = new System.Drawing.Point(83, 53);
            this.edAngle.Name = "edAngle";
            this.edAngle.Size = new System.Drawing.Size(103, 20);
            this.edAngle.TabIndex = 2;
            this.edAngle.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelHeight.Location = new System.Drawing.Point(38, 30);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(41, 13);
            this.labelHeight.TabIndex = 1;
            this.labelHeight.Text = "Height:";
            // 
            // edHeight
            // 
            this.edHeight.Location = new System.Drawing.Point(83, 27);
            this.edHeight.Name = "edHeight";
            this.edHeight.Size = new System.Drawing.Size(103, 20);
            this.edHeight.TabIndex = 0;
            // 
            // groupBoxChart
            // 
            this.groupBoxChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxChart.Controls.Add(this.chart1);
            this.groupBoxChart.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBoxChart.Location = new System.Drawing.Point(12, 141);
            this.groupBoxChart.Name = "groupBoxChart";
            this.groupBoxChart.Size = new System.Drawing.Size(682, 349);
            this.groupBoxChart.TabIndex = 1;
            this.groupBoxChart.TabStop = false;
            this.groupBoxChart.Text = "Chart";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.Maximum = 22D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.Interval = 1D;
            chartArea1.AxisY.Maximum = 10D;
            chartArea1.AxisY.Minimum = -8D;
            chartArea1.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.Gray;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(3, 16);
            this.chart1.Name = "chart1";
            series1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            series1.BackSecondaryColor = System.Drawing.Color.Transparent;
            series1.BorderColor = System.Drawing.Color.Transparent;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Series3";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Name = "Series4";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Name = "Series5";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Name = "Series6";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Name = "Series7";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Name = "Series8";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Name = "Series9";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Name = "Series10";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Series.Add(series10);
            this.chart1.Size = new System.Drawing.Size(676, 330);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(15, 31);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(69, 13);
            this.labelDistance.TabIndex = 4;
            this.labelDistance.Text = "Distance (m):";
            // 
            // labelDistanceValue
            // 
            this.labelDistanceValue.AutoSize = true;
            this.labelDistanceValue.Location = new System.Drawing.Point(135, 31);
            this.labelDistanceValue.Name = "labelDistanceValue";
            this.labelDistanceValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelDistanceValue.Size = new System.Drawing.Size(13, 13);
            this.labelDistanceValue.TabIndex = 5;
            this.labelDistanceValue.Text = "0";
            this.labelDistanceValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelLastPointSpeed);
            this.groupBox1.Controls.Add(this.labelLastPointSpeedValue);
            this.groupBox1.Controls.Add(this.labelMaxHeight);
            this.groupBox1.Controls.Add(this.labelMaxHeightValue);
            this.groupBox1.Controls.Add(this.labelDistance);
            this.groupBox1.Controls.Add(this.labelDistanceValue);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBox1.Location = new System.Drawing.Point(702, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 346);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // labelLastPointSpeed
            // 
            this.labelLastPointSpeed.AutoSize = true;
            this.labelLastPointSpeed.Location = new System.Drawing.Point(15, 76);
            this.labelLastPointSpeed.Name = "labelLastPointSpeed";
            this.labelLastPointSpeed.Size = new System.Drawing.Size(91, 13);
            this.labelLastPointSpeed.TabIndex = 8;
            this.labelLastPointSpeed.Text = "Last Speed (m/s):";
            // 
            // labelLastPointSpeedValue
            // 
            this.labelLastPointSpeedValue.AutoSize = true;
            this.labelLastPointSpeedValue.Location = new System.Drawing.Point(135, 76);
            this.labelLastPointSpeedValue.Name = "labelLastPointSpeedValue";
            this.labelLastPointSpeedValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelLastPointSpeedValue.Size = new System.Drawing.Size(13, 13);
            this.labelLastPointSpeedValue.TabIndex = 9;
            this.labelLastPointSpeedValue.Text = "0";
            this.labelLastPointSpeedValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMaxHeight
            // 
            this.labelMaxHeight.AutoSize = true;
            this.labelMaxHeight.Location = new System.Drawing.Point(15, 54);
            this.labelMaxHeight.Name = "labelMaxHeight";
            this.labelMaxHeight.Size = new System.Drawing.Size(79, 13);
            this.labelMaxHeight.TabIndex = 6;
            this.labelMaxHeight.Text = "Max height (m):";
            // 
            // labelMaxHeightValue
            // 
            this.labelMaxHeightValue.AutoSize = true;
            this.labelMaxHeightValue.Location = new System.Drawing.Point(135, 54);
            this.labelMaxHeightValue.Name = "labelMaxHeightValue";
            this.labelMaxHeightValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelMaxHeightValue.Size = new System.Drawing.Size(13, 13);
            this.labelMaxHeightValue.TabIndex = 7;
            this.labelMaxHeightValue.Text = "0";
            this.labelMaxHeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 502);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxChart);
            this.Controls.Add(this.groupBoxControls);
            this.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxControls.ResumeLayout(false);
            this.groupBoxControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edHeight)).EndInit();
            this.groupBoxChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxControls;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.NumericUpDown edHeight;
        private System.Windows.Forms.GroupBox groupBoxChart;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.NumericUpDown edWeight;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.NumericUpDown edSize;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.NumericUpDown edSpeed;
        private System.Windows.Forms.Label labelAngle;
        private System.Windows.Forms.NumericUpDown edAngle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown edStep;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.Label labelDistanceValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelLastPointSpeed;
        private System.Windows.Forms.Label labelLastPointSpeedValue;
        private System.Windows.Forms.Label labelMaxHeight;
        private System.Windows.Forms.Label labelMaxHeightValue;
        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelPlanet;
        private System.Windows.Forms.ComboBox comboBoxPlanet;
        private System.Windows.Forms.Label label2;
    }
}

