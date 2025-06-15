public class Medico
{
    public string Nombre;
    public string Apellido;
    public string Matricula;
    public string Especialidad;
    public bool Condicion;

    public Medico(string nombre, string apellido, string matricula, string especialidad, bool condicion)
    {
        Nombre = nombre;
        Apellido = apellido;
        Matricula = matricula;
        Especialidad = especialidad;
        Condicion = condicion;
    }
}