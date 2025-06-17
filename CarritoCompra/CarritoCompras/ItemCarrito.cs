using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class ItemCarrito
    {
        public Producto Producto { get; }
        public int Cantidad { get; set; }

        public ItemCarrito(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }

        public decimal Subtotal()
        {
            decimal subtotal = Producto.Precio * Cantidad;


            if (Cantidad >= 5)
            {
                subtotal = subtotal * (15/100); 
            }

            return subtotal;
        }

        public override string ToString()
        {
            return $"{Producto.Nombre} x{Cantidad} - ${Subtotal()}";
        }
    }
}
