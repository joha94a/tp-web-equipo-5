using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ItemCarrito
    {
        public Articulo Articulo { get; }
        public int Cantidad { get; set; }

        public ItemCarrito(Articulo articulo, int cantidad)
        { 
            Articulo = articulo;
            Cantidad = cantidad;
        }
    }
}
