public abstract class IntervencionQuirurgica
{
    public int Codigo;
    public string Descripcion;
    public string Especialidad;
    public decimal Precio;

    public abstract decimal CostoAPagar();

    public abstract string ObtenerDescripcion();
}

public class Normal : IntervencionQuirurgica
{
    //Constructor
    public Normal(int codigo, string descripcion, string especialidad, decimal precio)
    {
        Codigo = codigo;
        Descripcion = descripcion;
        Especialidad = especialidad;
        Precio = precio;
    }

    public override decimal CostoAPagar() => Precio;

    public override string ObtenerDescripcion()
    {
        return Descripcion;
    }

}

public class AltaComplejidad : IntervencionQuirurgica
{
    //Valor extra fijado
    public static double PorcentajeExtra = 0.15;

    //Constructor
    public AltaComplejidad(int codigo, string descripcion, string especialidad, decimal precio)
    {
        Codigo = codigo;
        Descripcion = descripcion;
        Especialidad = especialidad;
        Precio = precio;
    }


    public override decimal CostoAPagar()
    {
        //Aseguramos q tengan el mismo tipo
        return Precio + (Precio * (decimal)PorcentajeExtra);
    }

    public override string ObtenerDescripcion()
    {
        return Descripcion;
    }
}
