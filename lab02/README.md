## Метод конечных разностей для уравнения теплопроводности

### 1. Назначение
Программа решает одномерное нестационарное уравнение теплопроводности в пластине с заданными граничными условиями первого рода. Пользователь задаёт геометрические и физические параметры, шаги по времени и пространству, конечное время. Результат — график распределения температуры по толщине пластины в конечный момент времени, температура в центре и затраченное машинное время.

### 2. Физическая постановка
Рассматривается пластина толщиной $L$. В начальный момент времени ($t = 0$) температура во всех точках постоянна и равна $T_0$. На левой границе ($x = 0$) поддерживается температура $T_{\text{left}}$, на правой ($x = L$) – $T_{\text{right}}$. Процесс описывается уравнением теплопроводности:

$$
\frac{\partial T}{\partial t} = \alpha \frac{\partial^2 T}{\partial x^2},
$$

где $\alpha = \frac{\lambda}{\rho c}$ – коэффициент температуропроводности (вводится пользователем). Требуется найти распределение температуры по толщине в момент $t = t_{\text{end}}$.

### 3. Численный метод

#### 3.1 Дискретизация
- Пространственная сетка: $x_i = i \cdot h$, $i = 0, 1, \dots, N-1$, шаг $h = L/(N-1)$.
- Временная сетка: $t^n = n \cdot \tau$, шаг $\tau = \Delta t$ (вводится пользователем).
- Обозначение: $T_i^n$ – температура в узле $i$ на слое $n$.

#### 3.2 Неявная разностная схема
Производные аппроксимируются неявным образом:

$$
\frac{\partial T}{\partial t} \approx \frac{T_i^{n+1} - T_i^n}{\tau}, \quad
\frac{\partial^2 T}{\partial x^2} \approx \frac{T_{i+1}^{n+1} - 2T_i^{n+1} + T_{i-1}^{n+1}}{h^2}.
$$

Подстановка в уравнение даёт для внутренних узлов ($i = 1, \dots, N-2$):

$$
\frac{T_i^{n+1} - T_i^n}{\tau} = \alpha \frac{T_{i+1}^{n+1} - 2T_i^{n+1} + T_{i-1}^{n+1}}{h^2}.
$$

Введя параметр $r = \alpha \tau / h^2$, получаем систему линейных уравнений:

$$
- r\, T_{i-1}^{n+1} + (1 + 2r)\, T_i^{n+1} - r\, T_{i+1}^{n+1} = T_i^n.
$$

Для крайних внутренних узлов ($i=1$ и $i=N-2$) правая часть дополняется вкладом граничных условий:

- при $i = 1$: $-r T_0^{n+1}$ заменяется на $-r T_{\text{left}}$, поэтому переносится в правую часть: $T_1^n + r T_{\text{left}}$;
- при $i = N-2$: $-r T_{N-1}^{n+1}$ заменяется на $-r T_{\text{right}}$, правая часть: $T_{N-2}^n + r T_{\text{right}}$.

#### 3.3 Метод прогонки (алгоритм Томаса)
Полученная трёхдиагональная система решается методом прогонки. Вводятся прогоночные коэффициенты $\alpha_i$ и $\beta_i$:

**Прямой ход** (для внутренних узлов $i = 1, \dots, N-2$):
$$
\alpha_1 = \frac{r}{1+2r},\quad \beta_1 = \frac{T_1^n + r T_{\text{left}}}{1+2r},
$$
$$
\alpha_i = \frac{r}{1+2r - r \alpha_{i-1}},\quad \beta_i = \frac{T_i^n + r \beta_{i-1}}{1+2r - r \alpha_{i-1}},\quad i = 2, \dots, N-2.
$$

**Обратный ход**:
$$
T_{N-2}^{n+1} = \beta_{N-2},
$$
$$
T_i^{n+1} = \alpha_i T_{i+1}^{n+1} + \beta_i,\quad i = N-3, \dots, 1.
$$

Граничные узлы фиксируются: $T_0^{n+1} = T_{\text{left}}$, $T_{N-1}^{n+1} = T_{\text{right}}$.

В программной реализации индексация массивов начинается с 0, поэтому формулы адаптируются: внутренние узлы имеют индексы от 1 до $N-2$, прогоночные массивы размера $N-2$ и индекс 0 соответствует узлу 1.

### 4. Структура программы

#### 4.1 Элементы интерфейса
- **NumericUpDown** для ввода: толщина, количество узлов, шаг по времени, температуры слева и справа, начальная температура, коэффициент температуропроводности, конечное время.
- **Кнопка** «Запуск».
- **Chart** для отображения графика.
- **Label** для вывода температуры в центре и времени расчёта.

#### 4.2 Алгоритм работы
1. **Считывание данных** из NumericUpDown.
2. **Инициализация** массивов температур, задание начальных условий.
3. **Запуск секундомера** (`Stopwatch`).
4. **Цикл по времени** пока текущее время меньше конечного:
   - Вычисление шага по времени (с учётом последнего шага).
   - Вычисление коэффициента $r = \alpha \cdot \tau / h^2$.
   - Формирование массивов для прогонки: $A, B, C, D$ (левый, центральный, правый коэффициенты и правая часть).
   - Прямая прогонка: вычисление $\alpha_i$ и $\beta_i$.
   - Обратная прогонка: вычисление нового слоя $T^{n+1}$.
   - Применение граничных условий (принудительная установка крайних узлов).
   - Копирование нового слоя в старый, увеличение текущего времени.
5. **Остановка секундомера**, запись времени.
6. **Вычисление температуры в центре**:
   - Если число узлов чётное – среднее арифметическое двух центральных значений.
   - Если нечётное – значение центрального узла.
7. **Построение графика**: очистка предыдущей серии, добавление точек $(x_i, T_i)$.
8. **Обновление меток** с результатами.

### 5. Код программы

#### 5.1 Инициализация параметров

```cs
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

        // [ Несколько проверок ] ...

        RunSimulation(thickness, nodes, dt, tempLeft, tempRight, tempInit, alpha, endTime);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Ошибка ввода: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

#### 5.2 Функция симуляции

```cs
private void RunSimulation(double thickness, int nodes, double dt,
    double tempLeft, double tempRight, double tempInit, double alpha, double endTime)
{
    double[] temps = SolveHeatEquation(thickness, nodes, dt, tempLeft, tempRight, tempInit, alpha, endTime,
        out double centerTemp, out double elapsedMs);

    UpdateChart(temps, thickness, nodes);
    lblCenterTemp.Text = $"Температура в центре: {centerTemp:F3} °C";
    lblSimTime.Text = $"Время симуляции: {elapsedMs:F2} мс";
}
```

#### 5.3 Расчёт температуры

```cs
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
            if (i == 0) T[i] = tempLeft;
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
                int idx = i + 1;
                B[i] = 1 + 2 * r;
                if (i > 0) 
	                A[i] = r;
                if (i < n - 1) 
	                C[i] = r;
                else 
	                C[i] = 0;
	                
                D[i] = T[idx];
                if (i == 0) 
	                D[i] += r * tempLeft;
                if (i == n - 1) 
	                D[i] += r * tempRight;
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
```


**Задание:**  
Реализовать моделирование изменения температуры в пластине на основе одномерного уравнения теплопроводности с использованием метода конечных разностей.

Выполнить моделирование с различными шагами по времени и по пространству.  
Заполнить таблицу значений температуры в центральной точке пластины после 2 секунд модельного времени.

Параметры:
- Температура снаружи = $-30\degree C$
- Температура внутри = $25\degree C$
- Начальная температура = $-5\degree C$
- Альфа = $-0.01\ м^2 /c$
- Модельное время = $2\ с$

| Шаг по времени, с \ Шаг по пространству, м | 0.1    | 0.01   | 0.001  | 0.0001 |
| ------------------------------------------ | ------ | ------ | ------ | ------ |
| 0.1                                        | -4.888 | -4.929 | -4.930 | -4.930 |
| 0.01                                       | -4.893 | -4.937 | -4.937 | -4.937 |
| 0.001                                      | -4.894 | -4.937 | -4.938 | -4.938 |
| 0.0001                                     | -4.894 | -4.938 | -4.938 | -4.938 |

### Вывод.
Программа демонстрирует применение неявной конечно-разностной схемы для решения уравнения теплопроводности. Корректная реализация метода прогонки обеспечивает устойчивость и физичность результатов. Интерфейс позволяет легко менять параметры и наблюдать их влияние на распределение температуры и вычислительные затраты.
