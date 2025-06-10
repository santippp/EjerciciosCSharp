using System;
using System.Threading; // Necesario para Thread.Sleep


class Program
{
    static void Main()
    {
        Cronometro miCronometro = new Cronometro();

        for (int i = 0; i <5000; i++)
        {
            miCronometro.MostrarTiempo();
            miCronometro.IncrementarTiempo();
            Thread.Sleep(1000);

        }
        
    }
}