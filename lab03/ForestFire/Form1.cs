using System;
using System.Drawing;
using System.Windows.Forms;

namespace ForestFire
{
    public partial class Form1 : Form
    {
        private ForestFireModel _model;
        private System.Windows.Forms.Timer _timer;
        private int _generation;
        private int _cellSize = 10;
        private PictureBox pictureBox;
        private Bitmap gridBitmap;

        // Элементы управления
        private TrackBar tbWidth, tbHeight, tbProbTree, tbLightning, tbRegrowth;
        private CheckBox chkWind, chkHumidity, chkTemperature;
        private TrackBar tbWindStrength, tbHumidity, tbTemperature;
        private NumericUpDown nudWindDir;
        private RadioButton rbTree, rbFire, rbEmpty;
        private Label lblGen;
        private TrackBar tbSpeed;
        private Panel controlPanel;

        public Form1()
        {
            InitializeComponent();
            
            _model = new ForestFireModel(50, 50);
            _model.Randomize();

            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = 100;

            SetupUI();
            CreateBitmap();
        }

        private void SetupUI()
        {
            this.Text = "Forest Fire Cellular Automaton";
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;

            // PictureBox для отображения сетки
            pictureBox = new PictureBox
            {
                Location = new Point(10, 10),
                Size = new Size(800, 700),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                SizeMode = PictureBoxSizeMode.Normal
            };
            pictureBox.MouseClick += PictureBox_MouseClick;
            pictureBox.MouseMove += PictureBox_MouseMove;
            this.Controls.Add(pictureBox);

            // Панель управления с прокруткой
            controlPanel = new Panel
            {
                Location = new Point(820, 10),
                Size = new Size(350, 700),
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true
            };
            this.Controls.Add(controlPanel);

            // Внутренняя таблица для автоматической компоновки
            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Top,          // Прикрепим к верху, но ширина будет автоматической
                AutoSize = true,                // Высота подстраивается под содержимое
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 1,
                Padding = new Padding(5),
                BackColor = Color.Transparent
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            int row = 0;

            // Функция для добавления строки с одним элементом
            void AddRow(Control ctrl)
            {
                table.RowCount = row + 1;
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                table.Controls.Add(ctrl, 0, row);
                row++;
            }

            // Функция для добавления строки с меткой и контролом (например, ползунком)
            void AddLabeledControl(string labelText, Control ctrl)
            {
                var panel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    AutoSize = true,
                    WrapContents = false,
                    Margin = new Padding(0, 5, 0, 5)
                };
                panel.Controls.Add(new Label { Text = labelText, AutoSize = true });
                panel.Controls.Add(ctrl);
                AddRow(panel);
            }

            // --- Размер сетки ---
            var sizePanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.LeftToRight };
            sizePanel.Controls.Add(new Label { Text = "Width:", AutoSize = true, TextAlign = ContentAlignment.MiddleRight });
            tbWidth = new TrackBar { Minimum = 10, Maximum = 200, Value = 50, Width = 150 };
            sizePanel.Controls.Add(tbWidth);
            sizePanel.Controls.Add(new Label { Text = "Height:", AutoSize = true, TextAlign = ContentAlignment.MiddleRight });
            tbHeight = new TrackBar { Minimum = 10, Maximum = 200, Value = 50, Width = 150 };
            sizePanel.Controls.Add(tbHeight);
            var btnResize = new Button { Text = "Resize", AutoSize = true };
            btnResize.Click += BtnResize_Click;
            sizePanel.Controls.Add(btnResize);
            AddRow(sizePanel);

            // --- Основные параметры ---
            AddLabeledControl("Start trees:", tbProbTree = new TrackBar { Minimum = 0, Maximum = 100, Value = 50, Width = 200 });
            AddLabeledControl("Lightning (f):", tbLightning = new TrackBar { Minimum = 0, Maximum = 100, Value = 1, Width = 200 });
            AddLabeledControl("Regrowth (p):", tbRegrowth = new TrackBar { Minimum = 0, Maximum = 100, Value = 10, Width = 200 });

            // --- Дополнительные правила ---
            AddRow(new Label { Text = "Additional Rules:", Font = new Font(this.Font, FontStyle.Bold), AutoSize = true });

            // Ветер
            chkWind = new CheckBox { Text = "Wind", AutoSize = true };
            chkWind.CheckedChanged += (s, e) => UpdateModelFromUI();
            var windPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
            windPanel.Controls.Add(chkWind);
            var windDirPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.LeftToRight };
            windDirPanel.Controls.Add(new Label { Text = "Direction (0-7):", AutoSize = true });
            nudWindDir = new NumericUpDown { Minimum = 0, Maximum = 7, Value = 2, Width = 60 };
            nudWindDir.ValueChanged += (s, e) => UpdateModelFromUI();
            windDirPanel.Controls.Add(nudWindDir);
            windPanel.Controls.Add(windDirPanel);
            var windStrengthPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.LeftToRight };
            windStrengthPanel.Controls.Add(new Label { Text = "Strength:", AutoSize = true });
            tbWindStrength = new TrackBar { Minimum = 0, Maximum = 100, Value = 50, Width = 150 };
            tbWindStrength.ValueChanged += (s, e) => UpdateModelFromUI();
            windStrengthPanel.Controls.Add(tbWindStrength);
            windPanel.Controls.Add(windStrengthPanel);
            AddRow(windPanel);

            // Влажность
            chkHumidity = new CheckBox { Text = "Humidity", AutoSize = true };
            chkHumidity.CheckedChanged += (s, e) => UpdateModelFromUI();
            var humidityPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
            humidityPanel.Controls.Add(chkHumidity);
            var humidityLevelPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.LeftToRight };
            humidityLevelPanel.Controls.Add(new Label { Text = "Level:", AutoSize = true });
            tbHumidity = new TrackBar { Minimum = 0, Maximum = 100, Value = 50, Width = 150 };
            tbHumidity.ValueChanged += (s, e) => UpdateModelFromUI();
            humidityLevelPanel.Controls.Add(tbHumidity);
            humidityPanel.Controls.Add(humidityLevelPanel);
            AddRow(humidityPanel);

            // Температура
            chkTemperature = new CheckBox { Text = "Temperature", AutoSize = true };
            chkTemperature.CheckedChanged += (s, e) => UpdateModelFromUI();
            var tempPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
            tempPanel.Controls.Add(chkTemperature);
            var tempFactorPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.LeftToRight };
            tempFactorPanel.Controls.Add(new Label { Text = "Factor:", AutoSize = true });
            tbTemperature = new TrackBar { Minimum = 0, Maximum = 100, Value = 50, Width = 150 };
            tbTemperature.ValueChanged += (s, e) => UpdateModelFromUI();
            tempFactorPanel.Controls.Add(tbTemperature);
            tempPanel.Controls.Add(tempFactorPanel);
            AddRow(tempPanel);

            // --- Режим рисования ---
            var modePanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
            modePanel.Controls.Add(new Label { Text = "Mouse Mode:", AutoSize = true });
            var radioPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.LeftToRight };
            rbTree = new RadioButton { Text = "Tree", AutoSize = true, Checked = true };
            rbFire = new RadioButton { Text = "Fire", AutoSize = true };
            rbEmpty = new RadioButton { Text = "Empty", AutoSize = true };
            radioPanel.Controls.AddRange(new Control[] { rbTree, rbFire, rbEmpty });
            modePanel.Controls.Add(radioPanel);
            AddRow(modePanel);

            // --- Кнопки управления ---
            var btnPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.LeftToRight };
            var btnStart = new Button { Text = "Start", AutoSize = true };
            btnStart.Click += (s, e) => _timer.Start();
            var btnStop = new Button { Text = "Stop", AutoSize = true };
            btnStop.Click += (s, e) => _timer.Stop();
            var btnStep = new Button { Text = "Step", AutoSize = true };
            btnStep.Click += (s, e) => Step();
            var btnRandom = new Button { Text = "Random", AutoSize = true };
            btnRandom.Click += (s, e) => { _model.Randomize(); _generation = 0; UpdateBitmap(); };
            var btnClear = new Button { Text = "Clear", AutoSize = true };
            btnClear.Click += (s, e) => { _model.Clear(); _generation = 0; UpdateBitmap(); };
            btnPanel.Controls.AddRange(new Control[] { btnStart, btnStop, btnStep, btnRandom, btnClear });
            AddRow(btnPanel);

            // --- Скорость ---
            AddLabeledControl("Speed (ms):", tbSpeed = new TrackBar { Minimum = 10, Maximum = 500, Value = 100, Width = 200 });
            tbSpeed.ValueChanged += (s, e) => _timer.Interval = tbSpeed.Value;

            // --- Счётчик поколений ---
            lblGen = new Label { Text = "Generation: 0", AutoSize = true };
            AddRow(lblGen);

            // Добавляем таблицу на панель управления
            controlPanel.Controls.Add(table);

            // Метод обновления модели из UI (вызывается из обработчиков)
            void UpdateModelFromUI()
            {
                _model.ProbTreeStart = tbProbTree.Value / 100.0;
                _model.LightningProb = tbLightning.Value / 10000.0;
                _model.RegrowthProb = tbRegrowth.Value / 10000.0;

                _model.WindEnabled = chkWind.Checked;
                _model.WindDirection = (int)nudWindDir.Value;
                _model.WindStrength = tbWindStrength.Value / 100.0;

                _model.HumidityEnabled = chkHumidity.Checked;
                _model.HumidityLevel = tbHumidity.Value / 100.0;

                _model.TemperatureEnabled = chkTemperature.Checked;
                _model.TemperatureFactor = tbTemperature.Value / 100.0;
            }

            // Инициализация (первый вызов)
            UpdateModelFromUI();
        }

        private void BtnResize_Click(object sender, EventArgs e)
        {
            _model.Resize(tbWidth.Value, tbHeight.Value);
            _model.Randomize();
            _generation = 0;
            lblGen.Text = "Generation: 0";
            CreateBitmap();
        }

        private void Step()
        {
            _model.Step();
            _generation++;
            lblGen.Text = $"Generation: {_generation}";
            UpdateBitmap();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Step();
        }

        // Работа с Bitmap
        private void CreateBitmap()
        {
            gridBitmap = new Bitmap(_model.Width * _cellSize, _model.Height * _cellSize);
            UpdateBitmap();
        }

        private void UpdateBitmap()
        {
            using (var g = Graphics.FromImage(gridBitmap))
            {
                for (int y = 0; y < _model.Height; y++)
                {
                    for (int x = 0; x < _model.Width; x++)
                    {
                        var state = _model.GetCell(x, y);
                        Color color = state switch
                        {
                            CellState.Empty => Color.SaddleBrown,
                            CellState.Tree => Color.ForestGreen,
                            CellState.Fire => Color.Red,
                            _ => Color.White
                        };
                        using (var brush = new SolidBrush(color))
                        {
                            g.FillRectangle(brush, x * _cellSize, y * _cellSize, _cellSize - 1, _cellSize - 1);
                        }
                    }
                }
            }
            pictureBox.Image = gridBitmap;
        }

        private void UpdateCellOnBitmap(int x, int y, CellState state)
        {
            Color color = state switch
            {
                CellState.Empty => Color.SaddleBrown,
                CellState.Tree => Color.ForestGreen,
                CellState.Fire => Color.Red,
                _ => Color.White
            };
            using (var g = Graphics.FromImage(gridBitmap))
            using (var brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, x * _cellSize, y * _cellSize, _cellSize - 1, _cellSize - 1);
            }
            pictureBox.Invalidate(new Rectangle(x * _cellSize, y * _cellSize, _cellSize, _cellSize));
        }

        // Обработка мыши
        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            HandleMouseDraw(e.X, e.Y);
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                HandleMouseDraw(e.X, e.Y);
        }

        private void HandleMouseDraw(int mx, int my)
        {
            int x = mx / _cellSize;
            int y = my / _cellSize;
            if (x >= 0 && x < _model.Width && y >= 0 && y < _model.Height)
            {
                CellState state;
                if (rbTree.Checked) state = CellState.Tree;
                else if (rbFire.Checked) state = CellState.Fire;
                else state = CellState.Empty;

                _model.SetCell(x, y, state);
                UpdateCellOnBitmap(x, y, state);
            }
        }
    }
}