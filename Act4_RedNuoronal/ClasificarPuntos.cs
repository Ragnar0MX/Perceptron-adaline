using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act4_RedNuoronal
{
    class ClasificarPuntos
    {
        public string cadena;
        public List<double> posiciones;
        
        public ClasificarPuntos(string cadena, double posicion)
        {
            this.cadena = cadena;
            this.posiciones = new List<double>();
            posiciones.Add(posicion);
        }
    }
}
