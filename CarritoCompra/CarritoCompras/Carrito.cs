using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Carrito
    {
        private List<ItemCarrito> items;

        public Carrito()
        {
            items = new List<ItemCarrito>();
        }

        public void AgregarItem(Producto producto, int cantidad)
        {
            ItemCarrito itemExistente = null;
            foreach (var i in items)
            {
                if (i.Producto.Codigo == producto.Codigo)
                {
                    itemExistente = i;
                    break;
                }
            }


            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                items.Add(new ItemCarrito(producto, cantidad));
            }
        }

        public bool EliminarItem(int codigoProducto)
        {
            var item = items.Find(i => i.Producto.Codigo == codigoProducto);
            if (item != null)
            {
                items.Remove(item);
                return true;
            }
            return false;
        }

        public void VaciarCarrito()
        {
            items.Clear();
        }

        public decimal CalcularTotal()
        {
            decimal subtotal = 0;

            foreach (var item in items)
            {
                subtotal += item.Subtotal();
            }

            return subtotal * 1.21m;
        }

        public List<ItemCarrito> ObtenerItems()
        {
            return new List<ItemCarrito>(items);
        }

        public override string ToString()
        {
            if (items.Count == 0)
            {
                return "Carrito vacío";
            }

            string contenido = "Contenido del carrito:\n";
            foreach (var item in items)
            {
                contenido += $"- {item}\n";
            }
            contenido += $"Total a pagar (IVA incluido): ${CalcularTotal():0.00}";

            return contenido;
        }
    }
}
