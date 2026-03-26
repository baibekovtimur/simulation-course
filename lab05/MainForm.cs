using System;
using System.Linq;
using System.Windows.Forms;

namespace RandomGames
{
    public partial class MainForm : Form
    {
        private LcgRandom _rng;
        private readonly string[] _magicAnswers = {
            "Бесспорно", "Предрешено", "Никаких сомнений", "Определённо да",
            "Можешь быть уверен", "Вероятнее всего", "Хорошие перспективы", "Знаки говорят — да",
            "Да", "Пока не ясно, попробуй снова", "Спроси позже", "Лучше не рассказывать",
            "Сейчас нельзя предсказать", "Сконцентрируйся и спроси опять", "Не рассчитывай",
            "Мой ответ — нет", "Весьма сомнительно", "Нет", "Даже не думай"
        };

        public MainForm()
        {
            InitializeComponent();

            // Инициализация генератора
            long seed = DateTime.Now.Ticks;
            _rng = new LcgRandom(seed);
            txtSeed.Text = seed.ToString();

            // Заполнение NumericUpDown для Magic 8-Ball
            InitializeMagicControls();
        }

        private void InitializeMagicControls()
        {
            // Очищаем TableLayoutPanel
            magicTableLayout.Controls.Clear();
            magicTableLayout.RowCount = 5;
            magicTableLayout.ColumnCount = 4;

            // Заполняем таблицу ответами и NumericUpDown
            double defaultProb = 1.0 / _magicAnswers.Length; // 0.05
            for (int i = 0; i < _magicAnswers.Length; i++)
            {
                int row = i / 4;
                int col = i % 4;

                // Создаём панель для одной пары (Label + NumericUpDown)
                Panel panel = new Panel
                {
                    Dock = DockStyle.Fill,
                    Padding = new Padding(5),
                    Height = 60
                };

                Label lbl = new Label
                {
                    Text = _magicAnswers[i],
                    AutoSize = false,
                    Dock = DockStyle.Top,
                    Height = 30,
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                };

                NumericUpDown nud = new NumericUpDown
                {
                    DecimalPlaces = 4,
                    Increment = 0.01m,
                    Minimum = 0,
                    Maximum = 1,
                    Value = (decimal)defaultProb,
                    Dock = DockStyle.Top,
                    Width = 100
                };

                panel.Controls.Add(nud);
                panel.Controls.Add(lbl);
                magicTableLayout.Controls.Add(panel, col, row);
            }
        }

        // Нормализация вероятностей
        private void NormalizeMagicProbabilities()
        {
            // Собираем все NumericUpDown из TableLayoutPanel
            var nuds = magicTableLayout.Controls.OfType<Panel>()
                .SelectMany(p => p.Controls.OfType<NumericUpDown>())
                .ToList();

            double sum = nuds.Sum(n => (double)n.Value);
            if (sum == 0) return;

            foreach (var nud in nuds)
            {
                nud.Value = (decimal)((double)nud.Value / sum);
            }
        }

        // Игра "Да/Нет"
        private void BtnYesNo_Click(object? sender, EventArgs e)
        {
            double yesProb = (double)nudYesProbability.Value;
            bool isYes = _rng.NextDouble() < yesProb;
            lblYesNoAnswer.Text = isYes ? "Да" : "Нет";
        }

        // Игра "Шар предсказаний"
        private void BtnMagic_Click(object? sender, EventArgs e)
        {
            // Нормализуем вероятности перед выбором
            NormalizeMagicProbabilities();

            // Собираем все NumericUpDown и соответствующие ответы
            var panels = magicTableLayout.Controls.OfType<Panel>().ToList();
            var probabilities = new double[_magicAnswers.Length];
            for (int i = 0; i < panels.Count; i++)
            {
                var nud = panels[i].Controls.OfType<NumericUpDown>().FirstOrDefault();
                probabilities[i] = nud != null ? (double)nud.Value : 0;
            }

            // Кумулятивная сумма
            double r = _rng.NextDouble();
            double cumulative = 0;
            int selectedIndex = -1;
            for (int i = 0; i < probabilities.Length; i++)
            {
                cumulative += probabilities[i];
                if (r < cumulative)
                {
                    selectedIndex = i;
                    break;
                }
            }
            if (selectedIndex == -1) selectedIndex = probabilities.Length - 1;

            lblMagicAnswer.Text = _magicAnswers[selectedIndex];
        }

        // Кнопка нормализации (видимая)
        private void BtnNormalize_Click(object? sender, EventArgs e)
        {
            NormalizeMagicProbabilities();
            MessageBox.Show("Вероятности нормализованы (сумма = 1).", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Смена seed
        private void BtnResetSeed_Click(object? sender, EventArgs e)
        {
            if (long.TryParse(txtSeed.Text, out long newSeed))
            {
                _rng = new LcgRandom(newSeed);
                MessageBox.Show($"Seed изменён на {newSeed}.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Очистка ответов
                lblYesNoAnswer.Text = "?";
                lblMagicAnswer.Text = "?";
            }
            else
            {
                MessageBox.Show("Введите корректное целое число для seed.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}