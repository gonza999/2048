using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Entidades
{
    public class Casilla
    {
        private int valor;

        private Bitmap imagen;

        public Bitmap Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }

    }
}
