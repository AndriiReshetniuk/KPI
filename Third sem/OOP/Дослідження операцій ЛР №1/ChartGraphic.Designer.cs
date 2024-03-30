namespace Дослідження_операцій_ЛР__1
{
    partial class ChartGrapic1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.graphic1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.graphic1)).BeginInit();
            this.SuspendLayout();
            // 
            // graphic1
            // 
            chartArea1.Name = "ChartArea1";
            this.graphic1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Title = "Графік Функції";
            this.graphic1.Legends.Add(legend1);
            this.graphic1.Location = new System.Drawing.Point(101, 3);
            this.graphic1.Name = "graphic1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Lime;
            series1.LabelForeColor = System.Drawing.Color.Tomato;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.graphic1.Series.Add(series1);
            this.graphic1.Size = new System.Drawing.Size(1138, 521);
            this.graphic1.TabIndex = 2;
            this.graphic1.Text = "chart1";
            title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title1.Name = "X";
            title1.Text = "X";
            this.graphic1.Titles.Add(title1);
            // 
            // ChartGrapic1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 511);
            this.Controls.Add(this.graphic1);
            this.Name = "ChartGrapic1";
            this.Text = "ChartGraphic";
            ((System.ComponentModel.ISupportInitialize)(this.graphic1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graphic1;
    }
}