using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дослідження_операцій_ЛР__1
{
    internal class Program
    {
        public static int Fibonachi(int number_Of_Fibonachi, int previoslyNumber =0, int currentNumber = 1, int i = 0)
        {
            if (number_Of_Fibonachi == 0)
            {
                return 0;
            }
            else if(number_Of_Fibonachi == 1)
            {
                return 1;
            }
            else
            {
                return Fibonachi(number_Of_Fibonachi - 1) + Fibonachi(number_Of_Fibonachi - 2);
            }
        }

        public static Interval ReadInterval()
        {
            Interval choosenNumbers = new Interval();
            Console.WriteLine("Введiть початок iнтералу: ");
            choosenNumbers.Begining_of_the_interval = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введiть кiнець iнтервалу: ");
            choosenNumbers.End_of_the_interval = Convert.ToDouble(Console.ReadLine());
            return choosenNumbers;
        }

        static void Main(string[] args)
        {
            int intervalReply;
            X x1 = new X(2, 2, null);
            X x2 = new X(-12, 1, null);
            X x3 = new X(18, 0, null);
            X PowerOfX4 = new X(0.5, 2, null);
            X x4 = new X(2.71828183, 0, PowerOfX4);
            X [] AllXInFunction = {x1, x2, x3, x4};
            Function function = new Function(AllXInFunction);
            function.printFunction();
            Interval choosenInterval = new Interval();
            do
            {
                Console.WriteLine("Спосiб задання iнтервалу: ");
                Console.WriteLine("1 - заданий за завданням");
                Console.WriteLine("2 - ручне задання");
                intervalReply = Convert.ToInt32(Console.ReadLine());
                if (intervalReply == 1)
                {
                    choosenInterval.Begining_of_the_interval = 0;
                    choosenInterval.End_of_the_interval = 100;
                }
                else if(intervalReply == 2)
                {
                    choosenInterval = ReadInterval();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\tПомилка: вказано неiснуючий спосiб задання iнтервалу!");
                    Console.ResetColor();
                }
            } while (intervalReply != 1 && intervalReply != 2);
            Console.WriteLine($"Обраний iнтервал: [{choosenInterval.Begining_of_the_interval}, {choosenInterval.End_of_the_interval}]");
            Interval firstInterval = new Interval();
            Interval secondInterval = new Interval();
            for (int numberOfFibonachi = 3, i = 0; numberOfFibonachi < 40; numberOfFibonachi++, i++)
            {
                if (choosenInterval.Length_of_the_inerval() < 0.1)
                {
                    break;
                }
                Console.WriteLine($"Iтерація номер {i+1}:");
                double a = Fibonachi(numberOfFibonachi);
                double b = Fibonachi(numberOfFibonachi - 1);
                double relationOfFibonachi = a / b;
                double separatingCoordinate = choosenInterval.Length_of_the_inerval() / relationOfFibonachi;
                firstInterval.SetCoordinates(choosenInterval.Begining_of_the_interval, choosenInterval.Begining_of_the_interval + separatingCoordinate);
                secondInterval.SetCoordinates(choosenInterval.Begining_of_the_interval + separatingCoordinate, choosenInterval.End_of_the_interval);

                double Y_in_begining_of_the_interval = function.Function_in_x(firstInterval.Begining_of_the_interval);
                Console.WriteLine($"Y({firstInterval.Begining_of_the_interval}) = {Y_in_begining_of_the_interval}");

                double Y_in_the_end_of_the_interval = function.Function_in_x(secondInterval.End_of_the_interval);
                Console.WriteLine($"Y({secondInterval.End_of_the_interval}) = {Y_in_the_end_of_the_interval}");

                if (Y_in_begining_of_the_interval < Y_in_the_end_of_the_interval)
                {
                    choosenInterval.Begining_of_the_interval = firstInterval.Begining_of_the_interval;
                    choosenInterval.End_of_the_interval = firstInterval.End_of_the_interval;
                }
                else
                {
                    choosenInterval.Begining_of_the_interval = secondInterval.Begining_of_the_interval;
                    choosenInterval.End_of_the_interval = secondInterval.End_of_the_interval;
                }
            }
            Console.ReadKey();
        }
    }
}
