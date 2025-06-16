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

    public decimal CalcularCostoTotal()
    {
        decimal total = 0;
        foreach (var interv in IntervencionesRealizadas)
        {
            decimal costoBase = interv.Intervencion.CostoAPagar();
            if (ObraSocial != null)
                total += costoBase * (1 - (decimal)ObraSocial.PorcentajeCobertura);
            else
                total += costoBase;
        }
        return total;
    }

    public decimal CalcularCostoPendiente()
    {
        decimal total = 0;
        foreach (var interv in IntervencionesRealizadas)
        {
            if (!interv.Pagado)
            {
                decimal costoBase = interv.Intervencion.CostoAPagar();
                if (ObraSocial != null)
                    total += costoBase * (1 - (decimal)ObraSocial.PorcentajeCobertura);
                else
                    total += costoBase;
            }
        }
        return total;
    }
}