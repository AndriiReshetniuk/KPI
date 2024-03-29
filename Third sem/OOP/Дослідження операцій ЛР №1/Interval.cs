using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дослідження_операцій_ЛР__1
{
    public class Interval
    {
        public double Begining_of_the_interval;
        public double End_of_the_interval;
        
        public double Length_of_the_inerval()
        {
            return End_of_the_interval - Begining_of_the_interval; 
        }
        public void SetCoordinates(double firstCordinate, double secondCordinate)
        {
            if(firstCordinate < secondCordinate)
            {
                this.Begining_of_the_interval = firstCordinate;
                this.End_of_the_interval = secondCordinate;
            }
            else
            {
                this.Begining_of_the_interval = secondCordinate;
                this.End_of_the_interval = firstCordinate;
            }
        }
    }
}
