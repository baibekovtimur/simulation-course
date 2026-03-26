using System;
using RandomSensor.Core;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            const double theoreticalMean = 0.5;
            const double theoreticalVariance = 1.0 / 12.0;

            // Ввод seed
            Console.Write("Введите начальное значение seed: ");
            string? seedInput = Console.ReadLine();
            if (!long.TryParse(seedInput, out long seed))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: необходимо ввести целое число для seed.");
                Console.ResetColor();
                return;
            }

            // Ввод размера выборки
            Console.Write("Введите размер выборки [1000000]: ");
            string? sampleSizeInput = Console.ReadLine();
            int sampleSize;
            if (string.IsNullOrWhiteSpace(sampleSizeInput))
            {
                sampleSize = 1000000;
            }
            else if (!int.TryParse(sampleSizeInput, out sampleSize) || sampleSize <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: размер выборки должен быть положительным целым числом.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine($"\nСравнение выборочного среднего и дисперсии для {sampleSize} значений");
            Console.WriteLine($"Теоретические значения: среднее = {theoreticalMean}, дисперсия = {theoreticalVariance:F8}\n");

            // 1. Собственный LCG-датчик
            var myRng = new LcgRandom(seed);
            var myStats = new SampleStatistics();
            
            // 2. Встроенный Random с тем же seed
            int intSeed = (int)(seed % int.MaxValue); // корректировка для больших seed
            var builtInRng = new Random(intSeed);
            var builtInStats = new SampleStatistics();

            for (int i = 0; i < sampleSize; i++)
            {
                myStats.Add(myRng.NextDouble());
                builtInStats.Add(builtInRng.NextDouble());
            }

            Console.WriteLine("Собственный LCG-датчик:");
            Console.WriteLine($"  Среднее: {myStats.Mean:F8} (отклонение: {myStats.Mean - theoreticalMean:F8})");
            Console.WriteLine($"  Дисперсия: {myStats.Variance:F8} (отклонение: {myStats.Variance - theoreticalVariance:F8})");

            Console.WriteLine("\nВстроенный Random (с тем же seed):");
            Console.WriteLine($"  Среднее: {builtInStats.Mean:F8} (отклонение: {builtInStats.Mean - theoreticalMean:F8})");
            Console.WriteLine($"  Дисперсия: {builtInStats.Variance:F8} (отклонение: {builtInStats.Variance - theoreticalVariance:F8})");

            Console.ReadKey();
        }
    }
}