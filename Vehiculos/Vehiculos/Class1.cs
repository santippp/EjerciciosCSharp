using System;

public interface IVehiculo
{
    // Metodos
    void Mover(int minutos);
    int DarPosicion();
    void ReiniciarPosicion();

    // Atributos
    int Posicion { get; set; }
    int Velocidad { get; set; }
}

public class Bicicleta : IVehiculo
{
    public int Posicion { get; set; }
    public int Velocidad { get; set; }

    public Bicicleta()
    {
        Posicion = 0;
        Velocidad = 10;
    }

    public void Mover(int minutos)
    {
        Posicion += minutos * Velocidad;
    }

    public int DarPosicion()
    {
        return Posicion;
    }

    public void ReiniciarPosicion()
    {
        Posicion = 0;
    }
}

public class Camion : IVehiculo
{
    public int Posicion { get; set; }
    public int Velocidad { get; set; }

    public Camion()
    {
        Posicion = 0;
        Velocidad = 30;
    }

    public void Mover(int minutos)
    {
        Posicion += minutos * Velocidad;
    }

    public int DarPosicion()
    {
        return Posicion;
    }

    public void ReiniciarPosicion()
    {
        Posicion = 0;
    }
}

public class Auto : IVehiculo
{
    public int Posicion { get; set; }
    public int Velocidad { get; set; }

    public Auto()
    {
        Posicion = 0;
        Velocidad = 40;
    }

    //Constructor con Veloc. Distinta
    public Auto(int velocidad)
    {
        Posicion = 0;
        Velocidad = velocidad;
    }


    public void Mover(int minutos)
    {
        Posicion += minutos * Velocidad;
    }

    public int DarPosicion()
    {
        return Posicion;
    }

    public void ReiniciarPosicion()
    {
        Posicion = 0;
    }
}