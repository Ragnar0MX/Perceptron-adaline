using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Act4_RedNuoronal
{
    class Perceptron
    {
        public List<double> w;
        public double umbral;
        public double[] salidaEsperada,salida,error;
        public double[,] Entradas;
        
        public Perceptron(int columnas,double[]salidaEsperada,double[,] Entradas)
        {
            this.w = new List<double>();
            for (int i = 0; i < columnas; i++)
                this.w.Add(0);
            this.umbral = 0;
            this.salidaEsperada = salidaEsperada;
            this.salida = new double[salidaEsperada.Count()];
            this.Entradas = Entradas;
            this.error = new double[2];
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
            double correctos = 0;
            double z;
            for (int i = 0; i < salida.Count(); i++)
            {
                z = sumatoriaPesos(i);
                if (z > 0)
                    salida[i] = 1;
                else
                    salida[i] = 0;
                if (salida[i] == salidaEsperada[i])
                    correctos++;

                if (salida[i] != salidaEsperada[i])
                {
                    for (int j = 0; j < w.Count(); j++)
                    {
                        w[j] = w[j] + (0.2 * (salidaEsperada[i] - salida[i]) * (Entradas[i, j]));
                        //w[i] = w[i] + (w[i] * 0.2 * error[0]);
                        umbral = umbral - (0.2 * (salidaEsperada[i] - salida[i]));
                    }
                }
            }
            calcularError();
        }

        private double sumatoriaPesos(int numfila)
        {
            double acomulado = 0;
            for (int i = 0; i < w.Count(); i++)
            {
                acomulado += Entradas[numfila, i] * w[i];
            }
            acomulado = acomulado - umbral;
            return acomulado;
        }
        private void calcularError()
        {
            error[0] = 0;
            error[1] = 0;
            for (int i = 0; i < salidaEsperada.Count(); i++)
            {
                error[0] = error[0] + (salidaEsperada[i] - salida[i]);
                error[1] = error[1] + ((salidaEsperada[i] - salida[i]) * (salidaEsperada[i] - salida[i]));
            }
        }
    }
}
