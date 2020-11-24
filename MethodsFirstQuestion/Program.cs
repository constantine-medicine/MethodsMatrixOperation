using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsFirstQuestion
{
    class Program
    {
        public static Random rand = new Random();

        private static void Main(string[] args)
        {
            //// Задача №1.1. Программа, уможающая математическую матрицу на число.
            ////              Создать метод, принимающий число и матрицу, и вовзращающий матрицу, умноженную на число.
            
            //var arr = new int[10, 10];

            ////Заполнение массива рандомными числами
            //FillArray(ref arr, rand);

            //Console.WriteLine("Матрица после заполнения случайными числами: ");
            //Print(arr);

            //Console.WriteLine("Введите число на которое необходимо умножить матрицу: ");
            //var factor = int.Parse(Console.ReadLine());

            ////Умножение массива на число
            //int[,] multArray = MultArrayNumber(arr, factor);

            //Console.WriteLine($"Матрица умноженная на {factor}: ");
            //Print(multArray);

            //Console.ReadKey();



            // Задача №1.2. Программа складывающая матрицы.
            //              Создать метод, принимающий две матрицы, вовзращающий их сумму.
            
            // Задает размер матриц, считыванием с клавиатуры
            Console.WriteLine("Введите количество строк матриц: ");
            int row = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество столбцов матриц: ");
            int col = int.Parse(Console.ReadLine());

            var arrFirst = new int[row, col];
            var arrSecond = new int[row, col];

            // Заполение и вывод певрого массива
            Console.WriteLine("Первый массив: ");
            FillArray(ref arrFirst, rand);
            Print(arrFirst);

            // Заполнение и вывод второго массива
            Console.WriteLine("Второй массив: ");
            FillArray(ref arrSecond, rand);
            Print(arrSecond);

            // Проверяет на корректность ввода данных, если верны, производит вычисления.
            if (ConsumpSumArray(arrFirst, arrSecond) == false)
            {
                Console.WriteLine("Такие матрицы складывать нельзя!");
            }
            else
            {
                int[,] arrSum = SumArray(arrFirst, arrSecond);
                Console.WriteLine("Получившийся массив после сложения двух массивов: ");
                Print(arrSum);
            }

            Console.ReadKey();



            //// Задача №1.3. Программа умножающая матрицы между собой.
            ////            Создать метод, принимающий две матрицы, вовзращающий их произведение.
            //// Задает размер матриц, считыванием с клавиатуры
            //Console.WriteLine("Введите количество строк матриц: ");
            //int row = int.Parse(Console.ReadLine());

            //Console.WriteLine("Введите количество столбцов матриц: ");
            //int col = int.Parse(Console.ReadLine());

            //var arrFirst = new int[row, col];
            //var arrSecond = new int[row, col];

            //// Заполняет и выводит первую матрицу на консоль.
            //Console.WriteLine("Первая матрица: ");
            //FillArray(ref arrFirst, rand);
            //Print(arrFirst);

            //// Заполняет и выводит вторую матрицу на консоль.
            //Console.WriteLine("Вторая матрица: ");
            //FillArray(ref arrSecond, rand);
            //Print(arrSecond);

            //// Если введенные данные корректны, производит умножение матриц.
            //if (ConsumpMultArray(arrFirst, arrSecond) == false)
            //{
            //    Console.WriteLine("Такие матрицы умножать нельзя!");
            //}
            //else
            //{
            //    int[,] arrMult = MultArray(arrFirst, arrSecond);
            //    Console.WriteLine("Результат умножения матриц: ");
            //    Print(arrMult);
            //}

            //Console.ReadKey();
        }       

        #region Математические действия с матрицами

        /// <summary>
        /// Метод, уможающий массив на число.
        /// Возвращает получившийся массив.
        /// </summary>
        /// <param name="arr">Массив в качестве параметра</param>
        /// <param name="factor">Множитель в качестве параметра</param>
        /// <returns></returns>
        private static int[,] MultArrayNumber(int[,] arr, int factor)
        {
            int row = arr.GetLength(0);
            int col = arr.GetLength(1);

            int[,] mult = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    mult[i, j] = arr[i, j] * factor;
                }
            }

            return mult;
        }


        /// <summary>
        /// Метод, складывающий два массива. Возвращают результат в новый массив.
        /// </summary>
        /// <param name="arrFirst">Первый массив как слагаемое</param>
        /// <param name="arrSecond">Второй массив как слагаемое</param>
        /// <returns></returns>
        private static int[,] SumArray(int[,] arrFirst, int[,] arrSecond)
        {
            int row = arrFirst.GetLength(0);
            int col = arrFirst.GetLength(1);

            int[,] result = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = arrFirst[i, j] + arrSecond[i, j];
                }
            }

            return result;
        } 


        /// <summary>
        /// Метод, перемножающий матрицы между собой. Возвращает результат в новый массив.
        /// </summary>
        /// <param name="arrFirst"></param>
        /// <param name="arrSecond"></param>
        /// <returns></returns>
        private static int[,] MultArray(int[,] arrFirst, int[,] arrSecond)
        {
            
            int[,] result = new int[arrFirst.GetLength(0), arrSecond.GetLength(1)];

            for (var i = 0; i < arrFirst.GetLength(0); i++)
            {
                for (var j = 0; j < arrSecond.GetLength(1); j++)
                {
                    result[i, j] = 0;

                    for (var k = 0; k < arrFirst.GetLength(1); k++)
                    {
                        result[i, j] += arrFirst[i, k] * arrSecond[k, j];
                    }
                }
            }
            return result;
        }

        #endregion

        #region Логические действия(проверки на возможность математических операций)

        /// <summary>
        /// Метод, проверяющий размер двух матриц перед сложением.
        /// Возращает либо true, либо false.
        /// </summary>
        /// <param name="arrFirst"></param>
        /// <param name="arrSecond"></param>
        /// <returns></returns>
        private static bool ConsumpSumArray(int[,] arrFirst, int[,] arrSecond)
        {
            return (arrFirst.GetLength(0) == arrSecond.GetLength(0) && arrFirst.GetLength(1) == arrSecond.GetLength(1));
        }


        /// <summary>
        /// Метод, сравнивающий две матрицы перед умножением.
        /// Возвращает значение true либо false.
        /// </summary>
        /// <param name="arrFirst"></param>
        /// <param name="arrSecond"></param>
        /// <returns></returns>
        private static bool ConsumpMultArray(int[,] arrFirst, int[,] arrSecond)
        {
            return (arrFirst.GetLength(0) == arrSecond.GetLength(1));
        } 

        #endregion

        #region Печать и заполнение двумерного массива.
        /// <summary>
        /// Метод, заполняеющий массив(матрицу) случайными числами.
        /// </summary>
        /// <param name="arr">Массив, который необходимо заполнить.</param>
        /// <param name="rand">Переменная, которая заполняет массив.</param>
        private static void FillArray(ref int[,] arr, Random rand)
        {
            int row = arr.GetLength(0);
            int col = arr.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    arr[i, j] = rand.Next(10);
                }
            }
        }

        /// <summary>
        /// Метод печати массива(матрицы) на консоль.
        /// </summary>
        /// <param name="arr">Массив для печати как параметр метода.</param>
        private static void Print(int[,] arr)
        {

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j],5}"); ;
                }
                Console.WriteLine();
            }
        } 
        #endregion
    }
}
