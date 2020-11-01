using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Act4_RedNuoronal
{
    public partial class Form1 : Form
    {
        public double error, epoca;
        public bool termiando = false;
        public double[,] Entradas, SalidaEsperada;
        private Lectura leer;
        List<Perceptron> RedN;
        public Form1()
        {
            InitializeComponent();
            leer = new Lectura();
            RedN = new List<Perceptron>();
        }

        private void salidaEsperadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leer.Cargar_archivo();
            leer.leer_salida();
        }

        private void entradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leer.Cargar_archivo();
            leer.leer_entrada();
        }

        private void InicalizarPerceptron()
        {
            int columnas = leer.SalidasEsperadas.GetLength(1);
            List<double[]> salidas = new List<double[]>();
            for (int i = 0; i < columnas; i++)
            {
                Perceptron auxp;
                double[] aux = new double[leer.SalidasEsperadas.GetLength(0)];
                for (int j = 0; j < leer.SalidasEsperadas.GetLength(0); j++)
                {
                    aux[j] = leer.SalidasEsperadas[j, i];
                }
                salidas.Add(aux);
                auxp = new Perceptron(leer.Entradas.GetLength(1), salidas[i], leer.Entradas);
                RedN.Add(auxp);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(error);
            if (error != 0)
            {
                IniciarAnalisis();
                graficarLineas();
                graficar_error();
            }
                
            else{
                timer1.Stop();
                leer.archivoN(RedN);
            }

        }

        private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            error = 1;
            RedN.Clear();
            chart1.Series[0].Points.Clear();
            InicalizarPerceptron();
            epoca = 0;
            graficarPuntos();
            clasificación();
            timer1.Start();
        }

        private void IniciarAnalisis()
        {
            error = 0;
            foreach (Perceptron p in RedN)
            {
                p.paso02();
                error += p.error[1];
            }
        }

        private void graficar_error()
        {
            epoca++;
            double error = 0, total = 0, promedio = 0;
            foreach (Perceptron p in RedN)
            {
                error += p.error[1];
                total += 1 * p.salida.Count();
            }
            promedio = error / total;
            chart1.Series[0].Points.AddXY(epoca, promedio);
            listBox1.Items.Add("Error Promedio: "+promedio);
        }

        private  void graficarPuntos (){
            string aux;
            int i = 0;
            chart2.Series.Clear();
            foreach (ClasificarPuntos p in leer.diferentes)
            {
                aux = "";
                aux = "Clasificación:" + i;
                Series n = new Series();
                n.ChartArea = "ChartArea1";
                n.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                n.Legend = "Legend1";
                n.Name = "Clase puntos" + i;
                chart2.Series.Add(n);
                foreach (double np in p.posiciones)
                {
                    int aux2 = Convert.ToInt32(np);
                    chart2.Series[i].Points.AddXY(leer.Entradas[aux2, 0], leer.Entradas[aux2, 1]);
                }
                i++;
            }
            
        }

        private void adalineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdaline frm = new FormAdaline();
            frm.Show();
        }

        private void clasificación()
        {
            string aux;
            int i = 0;
            foreach(ClasificarPuntos p in leer.diferentes)
            {
                aux = "";
                aux = "Clasificación:" + i;
                foreach(double n in p.posiciones)
                {
                    aux += "\n    " + n;
                }
                listBox2.Items.Add(aux);
                i++;
            }
        }

        private void graficarLineas()
        {
            double m, b, y1, y2;
            int i = 0;
            List<Series> auxSeries = new List<Series>();
            if (chart2.Series.Count > leer.diferentes.Count)
            {
                for (int j = 0; j < leer.diferentes.Count; j++)
                {
                    Series n = new Series();
                    n = chart2.Series[j];
                    auxSeries.Add(n);
                }
                chart2.Series.Clear();
                foreach(Series p in auxSeries)
                {
                    chart2.Series.Add(p);
                }
            }
            foreach(Perceptron p in RedN)
            {
                Series n = new Series();
                n.ChartArea = "ChartArea1";
                n.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                n.Name = "perceptron"+Convert.ToString(i);
                string name = n.Name;
                chart2.Series.Add(n);
                m = (-p.w[0] / p.w[1]);
                b = p.umbral / p.w[1];
                y1 = m * (-4) + b;
                y2 = m * 4 + b;
                chart2.Series[name].Points.AddXY(-4, y1);
                chart2.Series[name].Points.AddXY(4, y2);
                i++;
            }
        }
    }
}
