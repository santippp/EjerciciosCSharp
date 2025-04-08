using System;
using System.Threading;

public class Semaforo
{
    private string colorActual;
    private int tiempoTranscurrido;
    private bool enIntermitente;
    private string colorInicial;

    // Constructor que define el color inicial
    public Semaforo(string colorInicial)
    {
        this.colorInicial = colorInicial;
        this.colorActual = colorInicial;
        this.tiempoTranscurrido = 0;
        this.enIntermitente = false;
    }

    // Método para simular el paso del tiempo en segundos
    public void pasoDelTiempo(int segundos)
    {
        if (enIntermitente)
        {
            // En modo intermitente, alterna entre "Amarillo" y "Apagado" cada segundo
            for (int i = 0; i < segundos; i++)
            {
                if (i % 2 == 0)
                    colorActual = "Amarillo";
                else
                    colorActual = "Apagado";

                mostrarColor();
                Thread.Sleep(1000);  // Espera un segundo
            }
        }
        else
        {
            // Si no está en intermitente, cambia el semáforo en base al tiempo transcurrido
            tiempoTranscurrido += segundos;

            while (tiempoTranscurrido >= 0)
            {
                if (colorActual == "Rojo" && tiempoTranscurrido >= 30)
                {
                    colorActual = "Rojo-Amarillo";
                    tiempoTranscurrido = 0;
                }
                else if (colorActual == "Rojo-Amarillo" && tiempoTranscurrido >= 2)
                {
                    colorActual = "Verde";
                    tiempoTranscurrido = 0;
                }
                else if (colorActual == "Verde" && tiempoTranscurrido >= 20)
                {
                    colorActual = "Amarillo";
                    tiempoTranscurrido = 0;
                }
                else if (colorActual == "Amarillo" && tiempoTranscurrido >= 2)
                {
                    colorActual = "Rojo";
                    tiempoTranscurrido = 0;
                }
                mostrarColor();
                break;  // Sale del ciclo tras haber mostrado el color actual.
            }
        }
    }

    // Método para mostrar el color actual
    public void mostrarColor()
    {
        Console.Clear();
        Console.WriteLine($"Color Actual: {colorActual}");
    }

    // Poner el semáforo en modo intermitente
    public void ponerEnIntermitente()
    {
        enIntermitente = true;
        colorActual = "Amarillo"; // Inicia como amarillo intermitente.
        Console.WriteLine("El semáforo está en modo intermitente.");
    }

    // Quitar el semáforo del modo intermitente
    public void sacarDeIntermitente()
    {
        enIntermitente = false;
        colorActual = colorInicial;  // Regresa al color inicial.
        Console.WriteLine("El semáforo ha salido del modo intermitente.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Crear el semáforo con el color inicial "Rojo"
        Semaforo semaforo = new Semaforo("Verde");
        semaforo.mostrarColor();

        // Paso del tiempo para simular la secuencia de colores
        for (int i = 0; i < 40; i++)
        {
            semaforo.pasoDelTiempo(1); // Paso del tiempo en 1 segundo
            Thread.Sleep(1000);  // Pausa de 1 segundo
        }

        // Cambiar a modo intermitente
        semaforo.ponerEnIntermitente();

        // Paso del tiempo mientras está en intermitente
        for (int i = 0; i < 10; i++)
        {
            semaforo.pasoDelTiempo(1); // Paso del tiempo en 1 segundo
            Thread.Sleep(1000);  // Pausa de 1 segundo
        }

        // Salir del modo intermitente
        semaforo.sacarDeIntermitente();

        // Paso del tiempo tras salir del modo intermitente
        for (int i = 0; i < 20; i++)
        {
            semaforo.pasoDelTiempo(1); // Paso del tiempo en 1 segundo
            Thread.Sleep(1000);  // Pausa de 1 segundo
        }
    }
}
