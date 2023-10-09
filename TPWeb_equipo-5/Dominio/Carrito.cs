using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {
        private List<ItemCarrito> Items { get; set; }

        public Carrito()
        { 
            Items = new List<ItemCarrito>();
        }

        public void AgregarArticulo(Articulo articulo, int cantidad)
        {
            ItemCarrito item = Items.FirstOrDefault(i => i.Articulo.Id == articulo.Id);

            if (item != null)
            {
                item.Cantidad += cantidad;
            }
            else
            {
                Items.Add(new ItemCarrito(articulo, cantidad));
            }
        }

        public void EliminarArticulo(Articulo articulo, int cantidad)
        {
            ItemCarrito item = Items.FirstOrDefault(i => i.Articulo == articulo);

            if (item != null)
            {
                item.Cantidad -= cantidad;
                if(item.Cantidad <= 0)
                {
                    Items.Remove(item);
                }
            }
        }

        public int CantidadItems()
        {
            return Items.Count;
        }

        public int CantidadTotal()
        {
            int cantidad = 0;
            foreach (ItemCarrito item in Items)
            {
                cantidad += item.Cantidad;
            }
            return cantidad;
        }

        public decimal PrecioTotal()
        {
            decimal precioTotal = 0;
            foreach (ItemCarrito item in Items)
            {
                precioTotal += item.Cantidad * item.Articulo.Precio;
            }
            return precioTotal;
        }

    }
}
