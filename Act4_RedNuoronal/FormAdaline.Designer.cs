namespace Act4_RedNuoronal
{
    partial class FormAdaline
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarArchivoDeEntradaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarArchivoDeSalidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.iniciarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(931, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarArchivoDeEntradaToolStripMenuItem,
            this.cargarArchivoDeSalidaToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // cargarArchivoDeEntradaToolStripMenuItem
            // 
            this.cargarArchivoDeEntradaToolStripMenuItem.Name = "cargarArchivoDeEntradaToolStripMenuItem";
            this.cargarArchivoDeEntradaToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.cargarArchivoDeEntradaToolStripMenuItem.Text = "Cargar Archivo de entrada";
            this.cargarArchivoDeEntradaToolStripMenuItem.Click += new System.EventHandler(this.cargarArchivoDeEntradaToolStripMenuItem_Click);
            // 
            // cargarArchivoDeSalidaToolStripMenuItem
            // 
            this.cargarArchivoDeSalidaToolStripMenuItem.Name = "cargarArchivoDeSalidaToolStripMenuItem";
            this.cargarArchivoDeSalidaToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.cargarArchivoDeSalidaToolStripMenuItem.Text = "Cargar Archivo de salida";
            this.cargarArchivoDeSalidaToolStripMenuItem.Click += new System.EventHandler(this.cargarArchivoDeSalidaToolStripMenuItem_Click);
            // 
            // iniciarToolStripMenuItem
            // 
            this.iniciarToolStripMenuItem.Name = "iniciarToolStripMenuItem";
            this.iniciarToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.iniciarToolStripMenuItem.Text = "Iniciar";
            this.iniciarToolStripMenuItem.Click += new System.EventHandler(this.iniciarToolStripMenuItem_Click_1);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 27);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(768, 251);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(774, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(153, 251);
            this.listBox1.TabIndex = 8;
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(0, 284);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Legend = "Legend1";
            series2.MarkerBorderWidth = 3;
            series2.MarkerSize = 1;
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(768, 251);
            this.chart2.TabIndex = 7;
            this.chart2.Text = "chart2";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(774, 284);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(153, 251);
            this.listBox2.TabIndex = 9;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // FormAdaline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 530);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormAdaline";
            this.Text = "FormAdaline";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarArchivoDeEntradaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarArchivoDeSalidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Timer timer1;
    }
}