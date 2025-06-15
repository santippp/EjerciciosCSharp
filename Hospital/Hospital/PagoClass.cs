using System;
using System.ComponentModel.Design;

class Pago
{
    //Id que incrementa solo
    private static int ultimoId = 0;

    public int Id;
    public DateTime Fecha;
    public string Descripcion;
    public string NombrePaciente;
    public string ApellidoPaciente;
    public string NombreMedico;
    public string Matricula;
    public string ObraSocial;
    public decimal Importe;
    //Guardamos nombre de ObraSocial


    public Pago(DateTime fecha, string descripcion, Paciente paciente, Medico medico, IntervencionRealizada interv)
    {
        Id = ++ultimoId;
        Fecha = fecha;
        Descripcion = descripcion;
        NombrePaciente = paciente.Nombre;
        ApellidoPaciente= paciente.Apellido;
        NombreMedico = medico.Nombre;
        Matricula = medico.Matricula;

        if (paciente.ObraSocial != null)
            ObraSocial = paciente.ObraSocial.Nombre;
        else
            ObraSocial = "-";

        Importe = interv.Intervencion.CostoAPagar();
    }

    public void ImprimirPago()
    {
        Console.WriteLine("             Pago Hospital             ");
        Console.WriteLine("         COMPROBANTE DE PAGO           ");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Fecha: {Fecha.ToShortDateString()}");
        Console.WriteLine();
        Console.WriteLine($"Descripción: {Descripcion}");
        Console.WriteLine($"Paciente: {NombrePaciente} {ApellidoPaciente}");
        Console.WriteLine($"Médico: {NombreMedico} (Matrícula: {Matricula})");
        Console.WriteLine($"Obra Social: {ObraSocial}");
        Console.WriteLine();
        Console.WriteLine($"TOTAL A PAGAR: ${Importe:0.00}");
        Console.WriteLine();
    }



}