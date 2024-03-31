namespace Дослідження_операцій_ЛР__1
{
    partial class Table_of_iteration
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
            this.Table1 = new System.Windows.Forms.DataGridView();
            this.buttonCreateGraphic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Table1)).BeginInit();
            this.SuspendLayout();
            // 
            // Table1
            // 
            this.Table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table1.Location = new System.Drawing.Point(173, 16);
            this.Table1.Name = "Table1";
            this.Table1.RowHeadersWidth = 51;
            this.Table1.RowTemplate.Height = 24;
            this.Table1.Size = new System.Drawing.Size(1059, 403);
            this.Table1.TabIndex = 0;
            this.Table1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table1_CellClick);
            // 
            // buttonCreateGraphic
            // 
            this.buttonCreateGraphic.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonCreateGraphic.Location = new System.Drawing.Point(649, 446);
            this.buttonCreateGraphic.Name = "buttonCreateGraphic";
            this.buttonCreateGraphic.Size = new System.Drawing.Size(158, 40);
            this.buttonCreateGraphic.TabIndex = 1;
            this.buttonCreateGraphic.Text = "Створити Графік";
            this.buttonCreateGraphic.UseVisualStyleBackColor = false;
            this.buttonCreateGraphic.Click += new System.EventHandler(this.button1_Click);
            // 
            // Table_of_iteration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 507);
            this.Controls.Add(this.buttonCreateGraphic);
            this.Controls.Add(this.Table1);
            this.Name = "Table_of_iteration";
            this.Text = "Table_of_iteration";
            this.Load += new System.EventHandler(this.Table_of_iteration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Table1;
        private System.Windows.Forms.Button buttonCreateGraphic;
    }
}