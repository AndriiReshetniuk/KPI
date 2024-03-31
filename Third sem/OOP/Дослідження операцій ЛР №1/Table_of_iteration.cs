using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Дослідження_операцій_ЛР__1
{
    public partial class Table_of_iteration : Form
    {
        private ChartGrapic1 graphic = new ChartGrapic1();
        private Function function;
        private double sizeOfTheIncrement;
        double x;
        public Table_of_iteration(Function function, double sizeOfTheIncrement = 0.01)
        {
            InitializeComponent();
            CreateTable();
            this.function = function;
            this.sizeOfTheIncrement = sizeOfTheIncrement;
        }
        public void CreateTable()
        {
            DataGridViewTextBoxColumn column0 = new DataGridViewTextBoxColumn();
            column0.Name = "Номер ітерації";
            column0.HeaderText = "Номер ітерації";
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.Name = "x1";
            column1.HeaderText = "x1";
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.Name = "Y(x1)";
            column2.HeaderText = "Y(x1)";
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.Name = "x2";
            column3.HeaderText = "x2";
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.Name = "Y(x2)";
            column4.HeaderText = "Y(x2)";
            Table1.Columns.AddRange(column0, column1, column2, column3, column4);
            SetSizeOfColumns(new int [] {0,1,2, 3, 4}, new int [] {50, 160, 160, 160, 160});
        }
        public void SetSizeOfColumns(int[] indexesOfColumns, int [] sizes)
        {
            for (int i = 0; i < indexesOfColumns.Length; i++)
            {
                if (indexesOfColumns[i] <= Table1.Columns.Count - 1)
                {
                    Table1.Columns[indexesOfColumns[i]].Width = sizes[i];
                }
            }
        }
        public void AddRow(int Number_Of_the_Iteration, double x1, double Y_in_the_first_interval, double x2 ,double Y_in_the_second_interval)
        {
            DataGridViewCell iterationCell = new DataGridViewTextBoxCell();
            DataGridViewCell x1Cell = new DataGridViewTextBoxCell();
            DataGridViewCell y1Cell = new DataGridViewTextBoxCell();
            DataGridViewCell x2Cell = new DataGridViewTextBoxCell();
            DataGridViewCell y2Cell = new DataGridViewTextBoxCell();
            iterationCell.Value = Number_Of_the_Iteration;
            x1Cell.Value = x1;
            y1Cell.Value = Y_in_the_first_interval;
            x2Cell.Value = x2;
            y2Cell.Value = Y_in_the_second_interval;
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.Cells.AddRange(iterationCell, x1Cell, y1Cell, x2Cell, y2Cell);
            Table1.Rows.Add(newRow);
        }
        private void Table_of_iteration_Load(object sender, EventArgs e)
        {
            x = Convert.ToDouble(Table1.Rows[Table1.RowCount - 2].Cells[3].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableFieldsStorage.Rows = Table1.Rows;
            TableFieldsStorage.RowCount = Table1.RowCount;
            graphic.DrawGraphic(this, function, x, sizeOfTheIncrement);
            graphic.WindowState = FormWindowState.Normal;
            graphic.Show();
        }

        private void Table1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cellIndex = e.ColumnIndex;
            if (cellIndex == 1 || cellIndex == 3)
            {
                int RowIndex = e.RowIndex;
                DataGridViewRow selectedRow = Table1.Rows[RowIndex];
                x = Convert.ToDouble(selectedRow.Cells[cellIndex].Value);
                if (x == Math.Floor(x))
                {
                    sizeOfTheIncrement = 0.1;
                }
                else
                {
                    sizeOfTheIncrement = 0.001;
                }
            }
        }
    }
}
