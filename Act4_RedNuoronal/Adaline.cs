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
        public double umbral,tasa;
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
            double z;
            error[2] = error[1];
            for (int i = 0; i < salida.Count(); i++)
            {
                z = sumatoriaPesos(i);
                salida[i] = z;
                error[3] = salidaEsperada[i] - z;
                diferencia[i] = error[3];
                calcularPesosUmrabal(i, error[3]);
            }
            double aux =salida.Length;
            error[1] = (1/2) ;
            error[0] = (error[1] - error[2]);
        }
        private void calcularPesosUmrabal(int p,double error)
        {
            double auxU = 0;
            for (int j = 0; j < w.Count(); j++)
            {
                dws[j] = tasa * diferencia[p] * Entradas[p, j];
            }
             auxU=(tasa * diferencia[p]*(-1));
            for (int j =0;j < w.Count(); j++)
            {
                w[j] = w[j] + dws[j];
            }
            umbral = umbral + auxU;


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
            acomulado = acomulado - umbral;
            return acomulado;
        }

        private void  diferenciYpDp(int i, double yp)
        {
             diferencia[i]=salidaEsperada[i] - salida[i];
        }

    }
}
