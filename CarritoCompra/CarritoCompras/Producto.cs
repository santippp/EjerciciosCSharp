using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Producto
    {
        public static int ultimoCodigo = 0;

        public int Codigo { get; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Categoria Categoria { get; set; }

        public Producto(string nombre, decimal precio, int stock, Categoria categoria)
        {
            Codigo = ++ultimoCodigo;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            Categoria = categoria;
        }

        public override string ToString()
        {
            return $"[{Codigo}] {Nombre} - ${Precio} - Stock: {Stock} - Categoría: {Categoria.Nombre}";
        }
    }
}
