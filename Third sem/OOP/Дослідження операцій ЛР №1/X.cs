using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Дослідження_операцій_ЛР__1
{
    public class X
    {
        public double coeficient_Of_X;
        public double power_of_x;
        public X coefficient_power;
        public X(double coeficient_Of_X, double power_of_x, X coefficient_power)
        {
            this.coeficient_Of_X = coeficient_Of_X;
            this.power_of_x = power_of_x;
            this.coefficient_power = coefficient_power;
        }
        public double raiseCoefficientToXPower(double valueToRaise, double value_Of_X)
        {
            double calculatedPower = Math.Pow(value_Of_X, power_of_x) * coeficient_Of_X;
            return Math.Pow(valueToRaise, calculatedPower);
        }
        public void printXwithoutSign()
        {
            if (coeficient_Of_X != 0)
            {
                double coeficient_of_x_without_sign = Math.Abs(coeficient_Of_X);
                if (coeficient_Of_X != 1)
                {
                    Console.Write(coeficient_of_x_without_sign);
                    if (coefficient_power != null)
                    {
                        Console.Write($"^(");
                        if(coefficient_power.coeficient_Of_X < 0)
                        {
                            Console.Write("-");
                        }
                        coefficient_power.printXwithoutSign();
                        Console.Write(") ");
                    }
                }
                if (power_of_x != 0)
                {
                    Console.Write("x");
                    if (power_of_x != 1)
                    {
                        Console.Write($"^{power_of_x}");
                    }
                }
            }
        }
    }
}
