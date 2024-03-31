using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Дослідження_операцій_ЛР__1
{
    public partial class ChartGrapic1 : Form
    {
        private Дослідження_операцій_ЛР__1.Table_of_iteration Table1;
        public ChartGrapic1()
        {
            InitializeComponent();
        }
        public void DrawGraphic(Дослідження_операцій_ЛР__1.Table_of_iteration Table1, Function function, double xValue, double sizeOfTheIncrement = 0.01)
        {
            this.Table1 = Table1;
            graphic1.Series[0].LegendText = function.printFunction();
            graphic1.Series[0].Font = new Font("Arial", 14);
            this.graphic1.Series[0].Points.Clear();
            double LimitedXValue = Program.LimitAccuracy(xValue);
            double BeginingOfTheInterval = LimitedXValue - 1;
            while (BeginingOfTheInterval <= LimitedXValue+2)
            {
                double y = function.Function_in_x(BeginingOfTheInterval);
                this.graphic1.Series[0].Points.AddXY(BeginingOfTheInterval, y);
                BeginingOfTheInterval += sizeOfTheIncrement;
            }
            double theSmallestY = function.Function_in_x(xValue);
            theSmallestY = Program.LimitAccuracy(theSmallestY);
            int indexOfPoint = -1;
            for (int i = 0; i < graphic1.Series[0].Points.Count - 1; i++)
            {
                if (LimitedXValue == Program.LimitAccuracy(graphic1.Series[0].Points[i].XValue) && theSmallestY == Program.LimitAccuracy(graphic1.Series[0].Points[i].YValues[0]))
                {
                    indexOfPoint = i;
                    break;
                }
            }
            if (indexOfPoint != -1)
            {
                graphic1.Series[0].Points[indexOfPoint].MarkerStyle = MarkerStyle.Circle;
                graphic1.Series[0].Points[indexOfPoint].MarkerSize = 8;
                graphic1.Series[0].Points[indexOfPoint].MarkerColor = Color.Red;
                graphic1.Series[0].Points[indexOfPoint].Label = $"({LimitedXValue}; " + Program.LimitAccuracy(graphic1.Series[0].Points[indexOfPoint].YValues[0]) + ")";
            }
        }
    }
}
