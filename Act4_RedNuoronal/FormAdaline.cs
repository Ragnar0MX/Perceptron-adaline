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

namespace Act4_RedNuoronal
{
    public partial class FormAdaline : Form
    {


        public double error, epoca;
        public bool termiando = false;
        public double[,] Entradas, SalidaEsperada;
        private Lectura leer;
        List<Adaline> RedN;
        public FormAdaline()
        {
            InitializeComponent();
            leer = new Lectura();
            RedN = new List<Adaline>();
        }

        private void InicalizarPerceptron()
        {
            int columnas = leer.SalidasEsperadas.GetLength(1);
            List<double[]> salidas = new List<double[]>();
            for (int i = 0; i < columnas; i++)
            {
                Adaline auxp;
                double[] aux = new double[leer.SalidasEsperadas.GetLength(0)];
                for (int j = 0; j < leer.SalidasEsperadas.GetLength(0); j++)
                {
                    aux[j] = leer.SalidasEsperadas[j, i];
                }
                salidas.Add(aux);
                auxp = new Adaline(leer.Entradas.GetLength(1), salidas[i], leer.Entradas);
                RedN.Add(auxp);
            }
        }

        private void IniciarAnalisis()
        {
            error = 0;
            int cont = 0;
            foreach (Adaline p in RedN)
            {
                p.paso02();
                error += Math.Abs(p.error[0]);
                cont++;
            }
            error = error / cont;
        }

        private void graficar_error()
        {
            epoca++;
            double error = 0, total = 0, promedio = 0;
            foreach (Adaline p in RedN)
            {
                error += Math.Abs(p.error[0]);
                total += 1;
            }
            promedio = error / total;
            chart1.Series[0].Points.AddXY(epoca, promedio);
            listBox1.Items.Add("Error Promedio: " + promedio);
        }

        private void graficarPuntos()
        {
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

        private void cargarArchivoDeEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leer.Cargar_archivo();
            leer.leer_entrada();
        }

        private void cargarArchivoDeSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leer.Cargar_archivo();
            leer.leer_salida();
        }

        private void iniciarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            error = 1;
            RedN.Clear();
            chart1.Series[0].Points.Clear();
            InicalizarPerceptron();
            epoca = 0;
            graficarPuntos();
            clasificación();

            IniciarAnalisis();
            graficarLineas();
            graficar_error();
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Console.WriteLine(error);
            bool continua = true;
            foreach (Adaline p in RedN)
                if (Math.Abs(p.error[0]) > 0.1)
                    continua = false;
            if (!continua)
            {
                IniciarAnalisis();
                graficarLineas();
                graficar_error();
            }

            else
            {
                graficarLineas();
                graficar_error();
                timer1.Stop();
                leer.archivoRAdaline(RedN);
            }
        }

        private void clasificación()
        {
            string aux;
            int i = 0;
            foreach (ClasificarPuntos p in leer.diferentes)
            {
                aux = "";
                aux = "Clasificación:" + i;
                foreach (double n in p.posiciones)
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
                foreach (Series p in auxSeries)
                {
                    chart2.Series.Add(p);
                }
            }
            foreach (Adaline p in RedN)
            {
                Series n = new Series();
                n.ChartArea = "ChartArea1";
                n.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                n.Name = "perceptron" + Convert.ToString(i);
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
