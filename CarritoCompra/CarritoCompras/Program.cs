using System;

namespace CarritoCompras
{
    class Program
    {
        static void Main(string[] args)
        {
            Tienda tienda = new Tienda();
            Carrito carrito = new Carrito();

            bool salir = false;

            while (!salir)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        VerCategorias(tienda);
                        break;
                    case "2":
                        VerProductos(tienda);
                        break;
                    case "3":
                        VerProductosPorCategoria(tienda);
                        break;
                    case "4":
                        AgregarAlCarrito(tienda, carrito);
                        break;
                    case "5":
                        EliminarDelCarrito(carrito);
                        break;
                    case "6":
                        VerCarrito(carrito);
                        break;
                    case "7":
                        VerTotal(carrito);
                        break;
                    case "8":
                        FinalizarCompra(tienda, carrito);
                        break;
                    case "9":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("MENÚ");
            Console.WriteLine("1. Ver categorías disponibles");
            Console.WriteLine("2. Ver todos los productos");
            Console.WriteLine("3. Ver productos por categoría");
            Console.WriteLine("4. Agregar producto al carrito");
            Console.WriteLine("5. Eliminar producto del carrito");
            Console.WriteLine("6. Ver contenido del carrito");
            Console.WriteLine("7. Ver total a pagar");
            Console.WriteLine("8. Finalizar compra");
            Console.WriteLine("9. Salir");
            Console.Write("Seleccione una opción: ");
        }

        static void VerCategorias(Tienda tienda)
        {
            Console.WriteLine("\nCATEGORÍAS DISPONIBLES");
            foreach (var categoria in tienda.Categorias)
            {
                Console.WriteLine(categoria);
            }
        }

        static void VerProductos(Tienda tienda)
        {
            Console.WriteLine("\nPRODUCTOS DISPONIBLES");
            foreach (var producto in tienda.Productos)
            {
                Console.WriteLine(producto);
            }
        }

        static void VerProductosPorCategoria(Tienda tienda)
        {
            VerCategorias(tienda);
            Console.Write("\nIngrese el nombre de la categoría: ");
            string nombreCategoria = Console.ReadLine();

            var productos = tienda.ObtenerProductosPorCategoria(nombreCategoria);

            if (productos.Count > 0)
            {
                Console.WriteLine($"\nPRODUCTOS DE LA CATEGORÍA {nombreCategoria.ToUpper()}");
                foreach (var producto in productos)
                {
                    Console.WriteLine(producto);
                }
            }
            else
            {
                Console.WriteLine("Categoría no encontrada o sin productos.");
            }
        }

        static void AgregarAlCarrito(Tienda tienda, Carrito carrito)
        {
            VerProductos(tienda);
            Console.Write("\nIngrese el código del producto: ");
            if (int.TryParse(Console.ReadLine(), out int codigo))
            {
                Console.Write("Ingrese la cantidad: ");
                if (int.TryParse(Console.ReadLine(), out int cantidad) && cantidad > 0)
                {
                    var producto = tienda.BuscarProductoPorCodigo(codigo);

                    if (producto != null)
                    {
                        if (producto.Stock >= cantidad)
                        {
                            carrito.AgregarItem(producto, cantidad);
                            Console.WriteLine("Se agrego el producto al carrito");
                        }
                        else
                        {
                            Console.WriteLine("No hay stock");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Producto no encontrado");
                    }
                }
                else
                {
                    Console.WriteLine("Cantidad inválida");
                }
            }
            else
            {
                Console.WriteLine("Código inválido");
            }
        }

        static void EliminarDelCarrito(Carrito carrito)
        {
            var items = carrito.ObtenerItems();

            if (items.Count == 0)
            {
                Console.WriteLine("El carrito está vacío");
                return;
            }

            Console.WriteLine("\nPRODUCTOS EN EL CARRITO");
            foreach (var item in items)
            {
                Console.WriteLine($"[{item.Producto.Codigo}] {item}");
            }

            Console.Write("\nIngrese el código del producto a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int codigo))
            {
                if (carrito.EliminarItem(codigo))
                {
                    Console.WriteLine("Producto eliminado del carrito");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado en el carrito");
                }
            }
            else
            {
                Console.WriteLine("Código inválido");
            }
        }

        static void VerCarrito(Carrito carrito)
        {
            Console.WriteLine(carrito.ToString());
        }

        static void VerTotal(Carrito carrito)
        {
            Console.WriteLine($"Total a pagar: ${carrito.CalcularTotal():0.00}");
        }

        static void FinalizarCompra(Tienda tienda, Carrito carrito)
        {
            var items = carrito.ObtenerItems();

            if (items.Count == 0)
            {
                Console.WriteLine("No es posible comprar ya que el carrito está vacío");
                return;
            }

            // Verificar stock antes de finalizar
            bool stockDisponible = true;
            foreach (var item in items)
            {
                if (item.Producto.Stock < item.Cantidad)
                {
                    Console.WriteLine($"No hay suficiente stock de {item.Producto.Nombre} (Stock: {item.Producto.Stock}, Solicitado: {item.Cantidad})");
                    stockDisponible = false;
                }
            }

            if (!stockDisponible)
            {
                Console.WriteLine("No se puede finalizar la compra por falta de stock");
                return;
            }

            // Actualizar stock y vaciar carrito
            foreach (var item in items)
            {
                tienda.ActualizarStock(item.Producto.Codigo, item.Cantidad);
            }

            decimal total = carrito.CalcularTotal();
            Console.WriteLine($"Compra finalizada, Total pagado: ${total:0.00}");
            carrito.VaciarCarrito();
        }
    }
}
