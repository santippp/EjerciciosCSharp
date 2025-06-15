using System;

namespace FigurasGeometricas
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Crear un semáforo con estado inicial en "Rojo"
            Semaforo semaforo = new Semaforo("Rojo");

            // Simular el paso de 70 segundos
            semaforo.pasoDelTiempo(70);

            // Mostrar color final
            Console.WriteLine($"Color final: {semaforo.Color}");

            // Pausar consola
            Console.WriteLine("Presione ENTER para salir...");
            Console.ReadLine();
        }
    }
}
