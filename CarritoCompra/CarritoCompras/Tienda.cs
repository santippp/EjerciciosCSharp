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
            new Categoria("Hogar", "Artículos para el hogar y decoración"),
            new Categoria("Comida",  "Articulos consumibles"),
            new Categoria("Mascotas", "Articulos para el cuidado canino"),
            new Categoria("Juguetes", "Articulos para niños y niñas")
        };

            Productos = new List<Producto>
        {
            new Producto("Smartphone", 500, 10, Categorias[0]),
            new Producto("Laptop", 1200, 5, Categorias[0]),
            new Producto("Camiseta", 25, 50, Categorias[1]),
            new Producto("Pantalón", 45, 30, Categorias[1]),
            new Producto("Lámpara", 35, 20, Categorias[2]),
            new Producto("Almohada", 15, 40, Categorias[2]),
            new Producto("Iphone", 1600, 12, Categorias[0]),
            new Producto("Termotanque", 1000, 4, Categorias[2]),
            new Producto("Caramelos", 5, 2000, Categorias[3]),
            new Producto("Cafetera", 400, 8, Categorias[2]),
            new Producto("Salmon", 90, 20, Categorias[3]),
            new Producto("Sobre trocitos de Carne", 5, 30, Categorias[4]),
            new Producto("Juguete Spiderman", 150, 8, Categorias[5]),
            new Producto("Tablero Ajedrez", 50, 15, Categorias[5])
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
