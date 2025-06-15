using System;

public class IntervencionRealizada
{
    //Id que incrementa solo
    private static int ultimoId = 0;

    public int Id;
    public DateTime Fecha;
    public IntervencionQuirurgica Intervencion;
    public Medico Medico;
    public Paciente Paciente;
    public bool Pagado;

    public IntervencionRealizada(DateTime fecha, IntervencionQuirurgica interv, Medico medico, Paciente paciente)
    {
        //Verifico que tengan misma especialidad
        if (medico.Especialidad != interv.Especialidad)
            throw new ArgumentException("No coincide la especialidad");

        //Verifico que este disponible
        if (!medico.Condicion)
            throw new InvalidOperationException("El medico no esta disponible");


        Id = ++ultimoId;
        Fecha = fecha;
        Intervencion = interv;
        Medico = medico;
        Paciente = paciente;
        Pagado = false;

        //Agremamos la intervencion al paciente
        Paciente.AgregarIntervencion(this);

    }

    public void Pagar()
    {
        Pagado = true;
    }
}
