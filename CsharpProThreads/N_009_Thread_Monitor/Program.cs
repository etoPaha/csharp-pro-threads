﻿using System;
using System.Threading;

// Пример аналогичный спин блокировке
// Только используется Monitor
// Куча потоков 
namespace N_009_Thread_Monitor
{
    class Program
    {
        /// <summary>
        /// Объект блокировки
        /// </summary>
        private static object block = new object();

        /// <summary>
        /// Счетчик потоков
        /// </summary>
        private static int counter;

        /// <summary>
        /// Для случайной имитации работы
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// Выполняется в отдельном потоке
        /// </summary>
        private static void Function()
        {
            try
            {
                Monitor.Enter(block);
                counter++;
            }
            finally
            {
                Monitor.Exit(block);
            }

            // Имитация работы
            int wait = random.Next(1000, 12000);
            Thread.Sleep(wait);

            try
            {
                Monitor.Enter(block);
                counter--;
            }
            finally
            {
                Monitor.Exit(block);
            }
        }

        /// <summary>
        /// Мониторинг количества запущенных потоков
        /// </summary>
        private static void Report()
        {
            while (true)
            {
                int count;

                try
                {
                    Monitor.Enter(block);
                    count = counter;
                }
                finally
                {
                    Monitor.Exit(block);
                }
                
                Console.WriteLine("{0} потоков активно", count);
                Thread.Sleep(100);
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Main - Start");

            var reporterThread = new Thread(Report)
            {
                IsBackground = true
            };
            reporterThread.Start();

            Thread[] threads = new Thread[150];
            
            for (int i = 0; i < 150; i++)
            {
                threads[i] = new Thread(Function);
                threads[i].Start();
            }
            
            Thread.Sleep(15000);
            
            Console.WriteLine("Main - End");
        }
    }
}

// Результат:

// Main - Start
// 0 потоков активно
// 150 потоков активно
// 150 потоков активно
// 150 потоков активно
// 150 потоков активно
// 150 потоков активно
// 150 потоков активно
// 150 потоков активно
// 150 потоков активно
// 150 потоков активно
// 149 потоков активно
// 147 потоков активно
// 143 потоков активно
// 140 потоков активно
// 138 потоков активно
// 138 потоков активно
// 138 потоков активно
// 136 потоков активно
// 135 потоков активно
// 134 потоков активно
// 133 потоков активно
// 133 потоков активно
// 133 потоков активно
// 132 потоков активно
// 127 потоков активно
// 127 потоков активно
// 126 потоков активно
// 124 потоков активно
// 123 потоков активно
// 121 потоков активно
// 121 потоков активно
// 118 потоков активно
// 117 потоков активно
// 116 потоков активно
// 115 потоков активно
// 110 потоков активно
// 108 потоков активно
// 108 потоков активно
// 106 потоков активно
// 106 потоков активно
// 105 потоков активно
// 103 потоков активно
// 101 потоков активно
// 99 потоков активно
// 98 потоков активно
// 97 потоков активно
// 96 потоков активно
// 93 потоков активно
// 92 потоков активно
// 86 потоков активно
// 85 потоков активно
// 84 потоков активно
// 83 потоков активно
// 78 потоков активно
// 78 потоков активно
// 77 потоков активно
// 75 потоков активно
// 73 потоков активно
// 72 потоков активно
// 70 потоков активно
// 68 потоков активно
// 65 потоков активно
// 64 потоков активно
// 64 потоков активно
// 64 потоков активно
// 63 потоков активно
// 61 потоков активно
// 60 потоков активно
// 58 потоков активно
// 57 потоков активно
// 55 потоков активно
// 54 потоков активно
// 53 потоков активно
// 52 потоков активно
// 51 потоков активно
// 51 потоков активно
// 49 потоков активно
// 46 потоков активно
// 44 потоков активно
// 42 потоков активно
// 38 потоков активно
// 37 потоков активно
// 36 потоков активно
// 34 потоков активно
// 33 потоков активно
// 33 потоков активно
// 31 потоков активно
// 31 потоков активно
// 31 потоков активно
// 30 потоков активно
// 29 потоков активно
// 27 потоков активно
// 26 потоков активно
// 25 потоков активно
// 21 потоков активно
// 20 потоков активно
// 19 потоков активно
// 19 потоков активно
// 18 потоков активно
// 16 потоков активно
// 15 потоков активно
// 12 потоков активно
// 10 потоков активно
// 9 потоков активно
// 8 потоков активно
// 7 потоков активно
// 7 потоков активно
// 6 потоков активно
// 4 потоков активно
// 1 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// 0 потоков активно
// Main - End
