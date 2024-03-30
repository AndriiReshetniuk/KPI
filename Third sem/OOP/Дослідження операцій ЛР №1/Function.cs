using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дослідження_операцій_ЛР__1
{
    public class Function
    {
        public X [] x_in_function;
        public Function (X[] x_in_function)
        {
            this.x_in_function = x_in_function;
        }
        public double Function_in_x(double x)
        {
            double y = 0;
            for (int i = 0; i < x_in_function.Length; i++)
            {
                double coefficient_of_x_after_rise_to_power = x_in_function[i].coeficient_Of_X;
                if (x_in_function[i].coefficient_power != null)
                {
                    coefficient_of_x_after_rise_to_power = x_in_function[i].coefficient_power.raiseCoefficientToXPower(x_in_function[i].coeficient_Of_X, x);
                }
                y += Math.Pow(x, x_in_function[i].power_of_x) * coefficient_of_x_after_rise_to_power;
            }
            return y;
        }
        public string printFunction()
        {
            string view_Of_Function = "";
            for(int i = 0; i<x_in_function.Length; i++)
            {
                    if (i != 0)
                    {
                        if (x_in_function[i].coeficient_Of_X > 0)
                        {
                            view_Of_Function += " + ";
                        }
                        else if (x_in_function[i].coeficient_Of_X < 0)
                        {
                            view_Of_Function += " - ";
                        }
                    }
                    else if(i == 0 && x_in_function[i].coeficient_Of_X < 0)
                    {
                        view_Of_Function+= "-";
                    }
                view_Of_Function += x_in_function[i].printXwithoutSign();
            }
            return view_Of_Function;
        }
    }
}
