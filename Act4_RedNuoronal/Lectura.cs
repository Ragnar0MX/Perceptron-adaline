using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Act4_RedNuoronal
{
    class Lectura
    {
        public string path;
        public double[,] Entradas, SalidasEsperadas;
        public List<ClasificarPuntos> diferentes;
        public Lectura()
        {
            this.path = "";
            diferentes = new List<ClasificarPuntos>();
        }

        public void Cargar_archivo()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Archivos csv (*.csv)|*.csv";
            open.Title = "archivos csv";
            if (open.ShowDialog() == DialogResult.OK)
            {
                this.path = (open.FileName);
            }
            open.Dispose();
        }

        public void leer_salida()
        {
            string[] entrada;
            double[,] Entradas;
            int i = 0, filas, columnas;
            string[] lines = System.IO.File.ReadAllLines(@path);
            filas = lines.Count();
            entrada = lines[0].Split(',');
            columnas = entrada.Count();
            Entradas = new double[filas, columnas];
            foreach (string line in lines)
            {
                int k = 0, auxr = 0; ;
                bool rep = false;
                if (diferentes.Count>0)
                {
                    for (k = 0; k < diferentes.Count(); k++)
                    {
                        if (diferentes[k].cadena == line)
                        {
                            rep = true;
                            auxr = k;
                        }
                    }
                    if (rep)
                        diferentes[auxr].posiciones.Add(i);

                    else
                    {
                        ClasificarPuntos n = new ClasificarPuntos(line, i);
                        diferentes.Add(n);
                    }
                    
                }
                else
                {
                    ClasificarPuntos n = new ClasificarPuntos(line, i);
                    diferentes.Add(n);
                }
                entrada = line.Split(',');
                for (int j = 0; j < columnas; j++)
                {
                    Entradas[i, j] = Convert.ToDouble(entrada[j]);
                }
                i++;
            }
            this.SalidasEsperadas = Entradas;
        }

        public void leer_entrada()
        {
            string[] entrada;
            double[,] Entradas;
            int i = 0, filas, columnas;
            string[] lines = System.IO.File.ReadAllLines(@path);
            filas = lines.Count();
            entrada = lines[0].Split(',');
            columnas = entrada.Count();
            Entradas = new double[filas, columnas];
            foreach (string line in lines)
            {
                entrada = line.Split(',');
                for (int j = 0; j < columnas; j++)
                {
                    Entradas[i, j] = Convert.ToDouble(entrada[j]);
                }
                i++;
            }
            this.Entradas = Entradas;
        }

        private StreamWriter writer;
        public void archivoN(List<Perceptron> RedN)
        {
            string rutaCompleta = @path + "_Salida.csv";
            path = rutaCompleta;
            string linea;
            try
            {
                writer = new StreamWriter(rutaCompleta, true);
            }
            catch
            {
                throw (new Exception("error al abrir/crear archivo"));
            }
            for(int i=0; i< SalidasEsperadas.GetLength(0); i++)
            {
                linea = "";
                for (int j = 0; j < RedN.Count; j++)
                {
                    if (j + 1 <= RedN.Count)
                        linea += RedN[j].salida[i]+",";
                }
                linea += "\n";
                writer.Write(linea);
            }
            writer.Close();
        }

        public void archivoRAdaline(List<Adaline> RedN)
        {
            string rutaCompleta = @path + "_Salida.csv";
            path = rutaCompleta;
            string linea;
            try
            {
                writer = new StreamWriter(rutaCompleta, true);
            }
            catch
            {
                throw (new Exception("error al abrir/crear archivo"));
            }
            for (int i = 0; i < SalidasEsperadas.GetLength(0); i++)
            {
                linea = "";
                for (int j = 0; j < RedN.Count; j++)
                {
                    if (j + 1 <= RedN.Count)
                        linea += RedN[j].salida[i] + ",";
                }
                linea += "\n";
                writer.Write(linea);
            }
            writer.Close();
        }
    }

}
