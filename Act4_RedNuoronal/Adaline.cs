using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act4_RedNuoronal
{
    class Adaline
    {
        public List<double> w,wT;
        public double umbral, tasa, error_total, e_red;
        public double[] salidaEsperada, salida, error,diferencia,dws;
        public double[,] Entradas;

        public Adaline(int columnas, double[] salidaEsperada, double[,] Entradas)
        {
            this.w = new List<double>();
            this.wT = new List<double>();
            for (int i = 0; i < columnas; i++){
                this.w.Add(0);
                this.wT.Add(0);
            }
            this.e_red = 0;
            this.error_total = 0;
            this.umbral = 0;
            this.tasa = 0.3;
            this.dws = new double[salidaEsperada.Count()];
            this.salidaEsperada = salidaEsperada;
            this.salida = new double[salidaEsperada.Count()];
            this.diferencia = new double[salidaEsperada.Count()];
            this.Entradas = Entradas;
            this.error = new double[4] { 0,0,0,0};//error de la red, Error cuadratico ew, erroe_Previo, error actual
            paso01();
        }

        public void paso01()
        {
            var random = new Random();
            for (int i = 0; i < w.Count(); i++)
                w[i] = random.NextDouble();
            umbral = random.NextDouble();
        }

        public void paso02()
        {
            double y;
            error[2] = error[1];
            for (int i = 0; i < salida.Count(); i++)
            {
                y = sumatoriaPesos(i);
                salida[i] = y;
                error[3] =salidaEsperada[i] - y;
                diferencia[i] = error[3];
                calcularPesosUmrabal(i, error[3]);
                error_total += Math.Pow(error[3], 2);
            }
            double aux =salida.Length;
            error[1] = (1/aux)*error_total ;
            error[0] = (error[1] - error[2]);
            e_red = error[0];
        }
        private void calcularPesosUmrabal(int p,double error)
        {
            for (int j = 0; j < w.Count(); j++)
            {
                w[j] += tasa*error*salida[p]*(1-salida[p])*Entradas[p,j];
            }
            umbral -= tasa * error*salida[p]*(1-salida[p]);

        }

        public void SalidaFinal()
        {
            for (int i = 0; i < salida.Count(); i++)
            {
                salida[i] = sumatoriaPesos(i);
            }
        }

        private double sumatoriaPesos(int numfila)
        {
            
            double acomulado = 0;
            for (int i = 0; i < w.Count(); i++)
            {
                acomulado += Entradas[numfila, i] * w[i];
            }
            acomulado -= umbral;
            return 1.0/(1.0+Math.Exp(-acomulado));
        }

    }
}
