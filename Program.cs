using System;
using System.Collections.Generic;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Task1();
                //Task2();
                //Task3();
                //Task4();
                //Task5();
                //Task6();
                //Task9();
                //IndividualTask1();
                //IndividualTask2();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }

        static void Task1()
        {
            int d;
            Console.WriteLine("Write x (Example:27.3198):");
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '.' && i + 1 < input.Length)
                {
                    d = Convert.ToInt32(input[i + 1]);
                    Console.WriteLine($"d = {d}");
                    break;
                }
            }
        }

        static void Task2()
        {
            int hours, minuts, seconds;
            int inputSeconds;
            Console.WriteLine("Write input seconds:");
            inputSeconds = Convert.ToInt32(Console.ReadLine());

            hours = inputSeconds / 3600;
            minuts = inputSeconds % 3600;
            seconds = minuts % 60;
            minuts = minuts / 60;

            Console.WriteLine($"h ={hours} m={minuts} s={seconds}");

        }

        static void Task3()
        {
            double alpha;
            int h, m, s;


            Console.WriteLine("Write hours:");
            if (int.TryParse(Console.ReadLine(), out h))
            {
                if (h < 0 && h > 11)
                {
                    throw new ArgumentException($"Incorrect value {h} < 0 or > 11");
                }
            }
            else
            {
                throw new ArgumentException("Incorrect value");
            }

            Console.WriteLine("Write minutes:");
            if (int.TryParse(Console.ReadLine(), out m))
            {
                if (m < 0 && m > 59)
                {
                    throw new ArgumentException($"Incorrect value m = {m} < 0 or > 59");
                }
            }
            else
            {
                throw new ArgumentException("Incorrect value");
            }

            Console.WriteLine("Write seconds:");
            if (int.TryParse(Console.ReadLine(), out s))
            {
                if (s < 0 && s > 59)
                {
                    throw new ArgumentException($"Incorrect value s = {s} < 0 or > 59");
                }
            }
            else
            {
                throw new ArgumentException("Incorrect value");
            }

            alpha = ((h / 12) * 3600 + m * 60 + s) / 12 / 3600 * 360;
            Console.WriteLine($"Alpha: {alpha}");
        }

        static void Task4()
        {
            int a, b;

            Console.WriteLine("Write a:");
            if (!int.TryParse(Console.ReadLine(), out a))
            {
                throw new ArgumentException("Incorrect value");
            }

            Console.WriteLine("Write b:");
            if (!int.TryParse(Console.ReadLine(), out b))
            {
                throw new ArgumentException("Incorrect value");
            }

            a = a + b; // 10
            b = b - a; // 7 - 10 = -3
            b = -b; // 3
            a = a - b; // 10 - 3 = 7

            Console.WriteLine($"a = {a} b = {b}");
        }

        static void Task5()
        {
            double a, b;

            Console.WriteLine("Write katet a:");
            if (!double.TryParse(Console.ReadLine(), out a))
            {
                throw new ArgumentException("Incorrect value");
            }

            Console.WriteLine("Write katet b:");
            if (!double.TryParse(Console.ReadLine(), out b))
            {
                throw new ArgumentException("Incorrect value");
            }

            Console.WriteLine($"S = {(1 / 2) * (a * b)}");
        }

        static void Task6()
        {
            int fourDigitNumber;
            int result = 1;

            Console.WriteLine("Write four-digit number: ");

            if (!int.TryParse(Console.ReadLine(), out fourDigitNumber))
            {
                throw new ArgumentException("Incorrect value");
            }

            do result *= fourDigitNumber % 10;
            while ((fourDigitNumber /= 10) > 0);

            Console.WriteLine($"Result :{result}");

        }

        static void Task7()
        {
            int numb;

            Console.WriteLine("Write numbers:");

            if (!int.TryParse(Console.ReadLine(), out numb))
            {
                throw new ArgumentException("Incorrect value its not a numeric value");
            }

            string number = numb.ToString();
            string reversed = "";
            for (int i = number.Length - 1; i >= 0; i--)
            {
                reversed += number[i];
            }
            Console.WriteLine($"Reversed = {reversed}");
        }

        static void Task8()
        {
            int x;

            Console.WriteLine("Write numbers:");

            if (!int.TryParse(Console.ReadLine(), out x))
            {
                throw new ArgumentException("Incorrect value");
            }

            Console.WriteLine($"{3 * Power(x, 4) - 5 * Power(x, 3) + 2 * Power(x, 2) - x + 7}");
        }

        static int Power(int number, int power)
        {
            int numb = number;

            for (int i = power; i > 0; i--)
            {
                number = numb * number;
            }
            return number;
        }

        static void Task9()
        {
            int n = 3; /* количество уравнений */
            double[,] A = new double[3, 3]; /* матрица системы */
            double[] b = new double[3]; /* вектор правых частей */
            double[] x = new double[3]; /* вектор решения */

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(i == 0)
                    {
                        Console.Write("a{0} -> ", j);
                    }
                    if (i == 1)
                    {
                        Console.Write("b{0} -> ", j);
                    }
                    if (i == 2)
                    {
                        Console.Write("c{0} -> ", j);
                    }

                    A[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write("d{0} -> ", i);
                b[i] = Convert.ToDouble(Console.ReadLine());
            }

            if (SLAU_kramer(n, A, b, x) == 1)
            {
                Console.WriteLine("Система не имеет решение");
                Convert.ToInt32(Console.ReadLine());
                return;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("x" + i + " = " + x[i]);
                }
            }
               
            Console.ReadLine();
        }

        static double det(int n, double[,] B)
        {
            if (n == 2)
                return B[0, 0] * B[1, 1] - B[0, 1] * B[1, 0];
            return B[0, 0] * (B[1, 1] * B[2, 2] - B[1, 2] * B[2, 1]) - B[0, 1] * (B[1, 0] * B[2, 2] - B[1, 2] * B[2, 0]) +
            B[0, 2] * (B[1, 0] * B[2, 1] - B[1, 1] * B[2, 0]);
        }

        static void equal(int n, double[,] A, double[,] B)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    A[i, j] = B[i, j];
        }

        static void change(int n, int N, double[,] A, double[] b)
        {
            for (int i = 0; i < n; i++)
                A[i, N] = b[i];
        }

        static int SLAU_kramer(int n, double[,] A, double[] b, double[] x)
        {
            double[,] An = new double[3, 3];
            double det1 = det(n, A);
            if (det1 == 0) return 1;
            for (int i = 0; i < n; i++)
            {
                equal(n, An, A);
                change(n, i, An, b);
                x[i] = det(n, An) / det1;
            }
            return 0;
        }

        public struct TableLine
        {
            public string FilmName { get; set; }
            public string Producer { get; set; }
            public int PublicationDate { get; set; }
            public char Type { get; set; }

            public TableLine(string filmName, string producer, int publicationDate, char type)
            {
                FilmName = filmName;
                Producer = producer;
                PublicationDate = publicationDate;
                Type = type;
            }
        }

        static void PrintTable(List<TableLine> table)
        {
            Console.WriteLine("Кинопродукция");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine($"|\t{"Режисер",20} |{"Режисер",20}   |{"Дата выпуска",15}       |{"Тип",4}    |");
            Console.WriteLine("--------------------------------------------------------------------------------------");

            foreach (var item in table)
            {
                Console.WriteLine($"|\t{item.FilmName,20} |{item.Producer,20}   |{item.PublicationDate,15}       |{item.Type,4}    |");
                Console.WriteLine("--------------------------------------------------------------------------------------");
            }

            Console.WriteLine($"|Перечисляемый тип: Д - драма, К – комедия, М – мелодрама, Б – боевик, А – мультфильм|");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            //
        }

        static void IndividualTask1()
        {
            List<TableLine> table = new List<TableLine>()
            {
                new TableLine("Большой Лебовски", "Коэн И., Коэн Дж", 1998, 'К'),
                new TableLine("Геркулес", "Маскер Дж.", 1997, 'А'),
                new TableLine("Ноттинг-хилл", "Мишелл Р.", 1999, 'М'),
                new TableLine("Большой Лебовски", "Коэн И., Коэн Дж", 1998, 'К')
            };
            PrintTable(table);

            bool flag = true;

            do
            {
                Console.Clear();
                PrintTable(table);
                Console.WriteLine("Добавить запись? Y(y) - Да; N(n) - Нет");
                char key = Console.ReadKey().KeyChar;
                if(key == 'n' || key == 'N')
                {
                    flag = false;
                    break;
                }


                TableLine tableLine = new TableLine();
                Console.WriteLine("\nДобавление фильма:");
                Console.WriteLine("Введите название фильма:");
                tableLine.FilmName = Console.ReadLine();
                Console.WriteLine("Введите название режисера:");
                tableLine.Producer = Console.ReadLine();
                Console.WriteLine("Введите год выпуска:");
                tableLine.PublicationDate = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите тип:");
                tableLine.Type = Console.ReadKey().KeyChar;

                table.Add(tableLine);

            } while (flag);

        }

        static void IndividualTask2()
        {
            double x, m;
            Console.WriteLine("Write x:");

            if (!double.TryParse(Console.ReadLine(), out x))
            {
                throw new ArgumentException("Incorrect value its not a numeric value");
            }

            Console.WriteLine("Write m:");
            if (!double.TryParse(Console.ReadLine(), out m))
            {
                throw new ArgumentException("Incorrect value its not a numeric value");
            }

            Console.WriteLine($"z = {(Math.Sin(x) / Math.Sqrt(Math.Pow(m, 2) + Math.Pow(Math.Sin(x), 2))) - m * Math.Log(m, x)}");
            Console.WriteLine($"s = {Math.Pow(Math.Cos(Math.Pow(x, 3)), 2) - x / Math.Sqrt(Math.Pow(x, 2) + Math.Pow(m, 2))}");
        }
    }

}
