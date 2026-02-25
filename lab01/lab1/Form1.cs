using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab1
{
    public partial class Form1 : Form
    {
        const decimal C = 0.15M;
        const decimal rho = 1.29M;
        decimal g, t, dt, x, y, v0, cosA, sinA, S, m, k, vX, vY, maxHeight;
        int graph = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            t += dt;
            decimal v = (decimal)Math.Sqrt((double)(vX * vX + vY * vY));
            vX = vX - k * vX * v * dt;
            vY = vY - (g + k * vY * v) * dt;
            x = x + vX * dt;
            y = y + vY * dt;
            if (y > maxHeight) maxHeight = y;
            labelDistanceValue.Text = "" + Math.Round(x, 4);
            labelMaxHeightValue.Text = "" + Math.Round(maxHeight, 4);
            labelLastPointSpeedValue.Text = "" + Math.Round(v, 4);
            chart1.Series[graph].Points.AddXY(x, y);
            if (y <= 0) { timer1.Stop(); graph += 1; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                //chart1.Series[0].Points.Clear();
                t = 0;
                x = 0;
                y = edHeight.Value;
                maxHeight = y;
                v0 = edSpeed.Value;
                double a = (double)edAngle.Value * Math.PI / 180;
                cosA = (decimal)Math.Cos(a);
                sinA = (decimal)Math.Sin(a);
                S = edSize.Value;
                m = edWeight.Value;
                dt = edStep.Value;
                k = 0.5M * C * rho * S / m;
                vX = v0 * cosA;
                vY = v0 * sinA;

                switch (comboBoxPlanet.Text)
                {
                    case "Mercury":
                        g = 3.70M;
                        break;
                    case "Venus":
                        g = 8.87M;
                        break;
                    case "Earth":
                        g = 9.81M;
                        break;
                    case "Mars":
                        g = 3.71M;
                        break;
                    case "Jupiter":
                        g = 24.79M;
                        break;
                    case "Saturn":
                        g = 10.44M;
                        break;
                    case "Uran":
                        g = 8.87M;
                        break;
                    case "Neptun":
                        g = 11.15M;
                        break;
                }
                chart1.Series[graph].Points.AddXY(x, y);
                timer1.Start();
            }    
        }
    }
}
