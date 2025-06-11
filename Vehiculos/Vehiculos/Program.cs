using System;

namespace Vehiculos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Definimos Objetos
            Auto hondaFit = new Auto(45);
            Bicicleta bici = new Bicicleta();
            Camion camion = new Camion();

            bici.Mover(20); // Mover la bicicleta durante 20 segundos
            Console.WriteLine($"La bicicleta se movio {bici.DarPosicion()} metros");

            bici.Mover(10); // Mover la bicicleta durante otros 10 segundos más
            Console.WriteLine($"La bicicleta se movio {bici.DarPosicion()} metros");

            hondaFit.Mover(30);
            Console.WriteLine($"El Honda Fit se movio {hondaFit.DarPosicion()} metros");
        }
    }
}
