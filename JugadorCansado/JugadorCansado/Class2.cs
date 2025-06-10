using System;

public interface Jugador  
{
    bool Correr(int minutos);  
    bool Cansado();
    void Descansar(int minutos);

    int Minutos { get; set; }  
}

public class Amateur : Jugador
{
    public int Minutos { get; set; }  

    public Amateur()
    {
        Minutos = 20;  
    }

    public bool Correr(int minutos)
    {
        Minutos -= minutos;

        if (Minutos < 0)
        {
            Minutos = 0;
            return false;
        }

        return true;
    }

    public bool Cansado()
    {
        return (Minutos == 0);
    }

    public void Descansar(int minutos) 
    {
        Minutos += minutos;
        if (Minutos > 20) Minutos = 20;
    }
}

public class Profesional : Jugador
{
    public int Minutos { get; set; }

    public Profesional()
    {
        Minutos = 40;  
    }

    public bool Correr(int minutos)
    {
        Minutos -= minutos;

        if (Minutos < 0)
        {
            Minutos = 0;
            return false;
        }

        return true;
    }

    public bool Cansado()
    {
        return (Minutos == 0);
    }

    public void Descansar(int minutos) 
    {
        Minutos += minutos;
        if (Minutos > 40) Minutos = 40;
    }
}