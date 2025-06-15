using System;
using System.Threading;

namespace FigurasGeometricas
{
    public class Semaforo
    {
        // Atributos
        public string Color;
        public bool Intermitente;

        // Constructor
        public Semaforo(string color)
        {
            Color = color;
            Intermitente = false;
        }

        // Métodos
        public void mostrarColor()
        {
            Console.WriteLine($"El semáforo está en color: {Color}");
        }

        public void ponerEnIntermitente()
        {
            Intermitente = true;
        }

        public void SacarIntermitente()
        {
            Intermitente = false;
        }

        public void pasoDelTiempo(int segundos)
        {
            if (segundos <= 0)
                return;

            if (Intermitente)
            {
                for (int i = 0; i < segundos; i++)
                {
                    Color = Color == "Amarillo" ? "Apagado" : "Amarillo";
                    Console.WriteLine($"{Color} - segundo {i + 1}");
                    Thread.Sleep(1000);
                }
                return;
            }

            if (Color == "Rojo")
            {
                int duracion = Math.Min(30, segundos);
                for (int j = 0; j < duracion; j++)
                {
                    Console.WriteLine($"{Color} - segundo {j + 1}");
                    Thread.Sleep(1000);
                }
                Color = "Rojo - Amarillo";
                pasoDelTiempo(segundos - duracion);
                return;
            }

            if (Color == "Rojo - Amarillo")
            {
                int duracion = Math.Min(2, segundos);
                for (int j = 0; j < duracion; j++)
                {
                    Console.WriteLine($"{Color} - segundo {j + 1}");
                    Thread.Sleep(1000);
                }
                Color = "Verde";
                pasoDelTiempo(segundos - duracion);
                return;
            }

            if (Color == "Verde")
            {
                int duracion = Math.Min(20, segundos);
                for (int j = 0; j < duracion; j++)
                {
                    Console.WriteLine($"{Color} - segundo {j + 1}");
                    Thread.Sleep(1000);
                }
                Color = "Amarillo";
                pasoDelTiempo(segundos - duracion);
                return;
            }

            if (Color == "Amarillo")
            {
                int duracion = Math.Min(2, segundos);
                for (int j = 0; j < duracion; j++)
                {
                    Console.WriteLine($"{Color} - segundo {j + 1}");
                    Thread.Sleep(1000);
                }
                Color = "Rojo";
                pasoDelTiempo(segundos - duracion);
                return;
            }
        }
    }
}
