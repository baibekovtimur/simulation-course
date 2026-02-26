using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        // Последние результаты расчёта
        private double[] lastTemperatures;
        private double lastCenterTemp;
        private double lastSimTimeMs;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btmStart_Click(object sender, EventArgs e)
        {
            chart1.Series["Temperature"].Points.Clear();
            try
            {
                double thickness = (double)edThickness.Value;
                int nodes = (int)edNodes.Value;
                double dt = (double)edTimeStep.Value;
                double tempLeft = (double)edTempLeft.Value;
                double tempRight = (double)edTempRight.Value;
                double tempInit = (double)edTemp.Value;
                double alpha = (double)edAlpha.Value;
                double endTime = (double)edEndTime.Value;

                if (thickness <= 0) throw new Exception("Толщина должна быть положительной.");
                if (nodes < 2) throw new Exception("Количество узлов должно быть не меньше 2.");
                if (dt <= 0) throw new Exception("Шаг по времени должен быть положительным.");
                if (alpha <= 0) throw new Exception("Коэффициент температуропроводности должен быть положительным.");
                if (endTime <= 0) throw new Exception("Конечное время должно быть положительным.");

                RunSimulation(thickness, nodes, dt, tempLeft, tempRight, tempInit, alpha, endTime);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RunSimulation(double thickness, int nodes, double dt,
            double tempLeft, double tempRight, double tempInit, double alpha, double endTime)
        {
            double[] temps = SolveHeatEquation(thickness, nodes, dt, tempLeft, tempRight, tempInit, alpha, endTime,
                out double centerTemp, out double elapsedMs);

            UpdateChart(temps, thickness, nodes);
            lblCenterTemp.Text = $"Температура в центре: {centerTemp:F3} °C";
            lblSimTime.Text = $"Время симуляции: {elapsedMs:F2} мс";
        }
        private double[] SolveHeatEquation(double thickness, int nodes, double dt,
    double tempLeft, double tempRight, double tempInit, double alpha, double endTime,
    out double centerTemp, out double elapsedMs)
        {
            double dx = thickness / (nodes - 1);
            double[] T = new double[nodes];
            double[] Tnew = new double[nodes];

            // Начальные условия
            for (int i = 0; i < nodes; i++)
            {
                if (i == 0)
                    T[i] = tempLeft;
                else if (i == nodes - 1)
                    T[i] = tempRight;
                else
                    T[i] = tempInit;
            }

            double currentTime = 0.0;
            Stopwatch sw = Stopwatch.StartNew();

            while (currentTime < endTime - 1e-12)
            {
                double dtStep = Math.Min(dt, endTime - currentTime);
                double r = alpha * dtStep / (dx * dx);

                int n = nodes - 2; // число внутренних узлов
                double[] A = new double[n];
                double[] B = new double[n];
                double[] C = new double[n];
                double[] D = new double[n];

                for (int i = 0; i < n; i++)
                {
                    int idx = i + 1; // индекс в массиве T
                    B[i] = 1 + 2 * r;
                    if (i > 0)
                        A[i] = r;       // связь с предыдущим внутренним узлом
                                         // A[0] остаётся 0, так как нет левого соседа (граница учтена в D)
                    if (i < n - 1)
                        C[i] = r;       // связь со следующим внутренним узлом
                    else
                        C[i] = 0;         // для последнего внутреннего узла нет правого соседа (граница учтена в D)
                    D[i] = T[idx];        // значение на предыдущем слое

                    if (i == 0)
                        D[i] += r * tempLeft;   // вклад левой границы
                    if (i == n - 1)
                        D[i] += r * tempRight;  // вклад правой границы
                }

                // Прямая прогонка
                double[] alphaCoef = new double[n];
                double[] betaCoef = new double[n];

                // Для первого внутреннего узла (i=0)
                alphaCoef[0] = C[0] / B[0];
                betaCoef[0] = D[0] / B[0];

                for (int i = 1; i < n; i++)
                {
                    double denom = B[i] - A[i] * alphaCoef[i - 1];
                    alphaCoef[i] = C[i] / denom;
                    betaCoef[i] = (D[i] + A[i] * betaCoef[i - 1]) / denom;
                }

                // Обратная прогонка
                Tnew[nodes - 2] = betaCoef[n - 1];
                for (int i = n - 2; i >= 0; i--)
                {
                    Tnew[i + 1] = alphaCoef[i] * Tnew[i + 2] + betaCoef[i];
                }

                // Граничные узлы
                Tnew[0] = tempLeft;
                Tnew[nodes - 1] = tempRight;

                Array.Copy(Tnew, T, nodes);
                currentTime += dtStep;
            }

            sw.Stop();
            elapsedMs = sw.Elapsed.TotalMilliseconds;

            // Температура в центре
            int centerIndex = (nodes - 1) / 2;
            if (nodes % 2 == 0)
                centerTemp = (T[centerIndex] + T[centerIndex + 1]) / 2.0;
            else
                centerTemp = T[centerIndex];

            return T;
        }
        private void UpdateChart(double[] temperatures, double thickness, int nodes)
        {
            double dx = thickness / (nodes - 1);
            var series = chart1.Series["Temperature"];
            series.Points.Clear();
            for (int i = 0; i < nodes; i++)
            {
                double x = i * dx;
                series.Points.AddXY(x, temperatures[i]);
            }
            chart1.ChartAreas[0].AxisX.Title = "x, м";
            chart1.ChartAreas[0].AxisY.Title = "Температура, °C";
            chart1.Invalidate();
        }
    }
}
