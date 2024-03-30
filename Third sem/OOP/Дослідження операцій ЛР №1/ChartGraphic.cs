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
        public void DrawGraphic(Дослідження_операцій_ЛР__1.Table_of_iteration Table1, Function function, double sizeOfTheIncrement = 0.1)
        {
            this.Table1 = Table1;
            graphic1.Series[0].LegendText = function.printFunction();
            graphic1.Series[0].Font = new Font("Arial", 14);
            this.graphic1.Series[0].Points.Clear();
            double x = 0;
            while (x <= 3)
            {
                double y = function.Function_in_x(x);
                this.graphic1.Series[0].Points.AddXY(x, y);
                x += sizeOfTheIncrement;
            }
            double theSmallestY = Convert.ToDouble(TableFieldsStorage.Rows[TableFieldsStorage.RowCount - 2].Cells[2].Value);
            theSmallestY = Program.LimitAccuracy(theSmallestY);
            int indexOfPoint = -1;
            for (int i = 0; i < graphic1.Series[0].Points.Count - 1; i++)
            {
                if (theSmallestY == Program.LimitAccuracy(graphic1.Series[0].Points[i].YValues[0]))
                {
                    indexOfPoint = i;
                    break;
                }
            }
            if (indexOfPoint != -1)
            {
                graphic1.Series[0].Points[indexOfPoint].MarkerStyle = MarkerStyle.Circle;
                graphic1.Series[0].Points[indexOfPoint].MarkerSize = 6;
                graphic1.Series[0].Points[indexOfPoint].MarkerColor = Color.Red;
                double xIntheSmallestY = graphic1.Series[0].Points[indexOfPoint].XValue;
                xIntheSmallestY = Program.LimitAccuracy(xIntheSmallestY);
                graphic1.Series[0].Points[indexOfPoint].Label = $"({xIntheSmallestY}, " + theSmallestY +")";
            }
        }
    }
}
