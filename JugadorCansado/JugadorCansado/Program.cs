using System;

class Program
{
    static void Main()
    {
     
        Jugador amateur = new Amateur();
        Jugador profesional = new Profesional();

        Console.WriteLine("Amateur: \n");
        ProbarJugador(amateur, 25); 

        // Probar Profesional
        Console.WriteLine("Profesional:\n");
        ProbarJugador(profesional, 50); 
    }

    static void ProbarJugador(Jugador jugador, int minutos)
    {
        Console.WriteLine($"Minutos de energía {jugador.Minutos} ");

        Console.WriteLine($"\nIntento correr {minutos} minutos...");
        bool exito = jugador.Correr(minutos);

        if (exito)
        {
            Console.WriteLine("Corrio");
        }

        else
            Console.WriteLine("No pudo correr");

        Console.WriteLine($"minutos restantes: {jugador.Minutos}");
        Console.WriteLine($"Cansado: {jugador.Cansado()}");

       
        int descanso = 15;
        jugador.Descansar(descanso);
        Console.WriteLine($"Recuperó {jugador.Minutos} minutos");

    }
}