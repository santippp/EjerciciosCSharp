using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Tienda
    {
        public List<Producto> Productos { get; }
        public List<Categoria> Categorias { get; }

        public Tienda()
        {
            Categorias = new List<Categoria>
        {
            new Categoria("Electrónica", "Productos electrónicos y dispositivos"),
            new Categoria("Ropa", "Prendas de vestir para hombres, mujeres y niños"),
            new Categoria("Hogar", "Artículos para el hogar y decoración")
        };

            Productos = new List<Producto>
        {
            new Producto("Smartphone", 500, 10, Categorias[0]),
            new Producto("Laptop", 1200, 5, Categorias[0]),
            new Producto("Camiseta", 25, 50, Categorias[1]),
            new Producto("Pantalón", 45, 30, Categorias[1]),
            new Producto("Lámpara", 35, 20, Categorias[2]),
            new Producto("Almohada", 15, 40, Categorias[2])
        };
        }

        public List<Producto> ObtenerProductosPorCategoria(string nombreCategoria)
        {
            return Productos.FindAll(p => p.Categoria.Nombre.Equals(nombreCategoria));
        }

        public Producto BuscarProductoPorCodigo(int codigo)
        {
            return Productos.Find(p => p.Codigo == codigo);
        }

        public bool ActualizarStock(int codigoProducto, int cantidadVendida)
        {
            var producto = BuscarProductoPorCodigo(codigoProducto);
            if (producto != null && producto.Stock >= cantidadVendida)
            {
                producto.Stock -= cantidadVendida;
                return true;
            }
            return false;
        }
    }
}
