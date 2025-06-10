using System;

public class Cronometro
{
	public int Minutos { get; set; } 
    public int Segundos { get; set; }


	public Cronometro()
	{
		Minutos = 0;
		Segundos = 0;
	}

	public void Reiniciar()
	{
		Minutos = 0;
		Segundos = 0;
	}

	public void IncrementarTiempo()
	{
		if (Segundos + 1 == 60)
		{
			Minutos++;
			Segundos = 0;
			return;
		}

		Segundos++;
		return;
	 }

	public void MostrarTiempo()
    {
		Console.WriteLine("{0} : {1}", Minutos, Segundos);
    }
}


