using System.Collections.Generic;

public class Paciente
{
    //Atributos
    public int DNI;
    public string Nombre;
    public string Apellido;
    public string Telefono;
    public ObraSocial? ObraSocial; // Puede tener o no
    public List<IntervencionRealizada> IntervencionesRealizadas; //Lista de intervenciones del paciente


    //Metodos

    //Constructor con Obra Social
    public Paciente(int dni, string nombre, string apellido, string telefono, ObraSocial obraSocial)
    {
        DNI = dni;
        Nombre = nombre;
        Apellido = apellido;
        Telefono = telefono;
        ObraSocial = obraSocial;
        IntervencionesRealizadas = new List<IntervencionRealizada>();
    }

    //Constructor sin obra social
    public Paciente(int dni, string nombre, string apellido, string telefono)
    {
        DNI = dni;
        Nombre = nombre;
        Apellido = apellido;
        Telefono = telefono;
        ObraSocial = null;
        IntervencionesRealizadas = new List<IntervencionRealizada>();
    }

    //Metodo para agregar Intervencion Realizada
    public void AgregarIntervencion(IntervencionRealizada interv)
    {
        IntervencionesRealizadas.Add(interv);
    }
}