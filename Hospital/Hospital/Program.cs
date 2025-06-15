using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    //Lista de pacientes
    static List<Paciente> pacientes = new List<Paciente>();
    //Listamos los pagos pendientes
    static List<Pago> pagosPendientes = new List<Pago>();

    static void Main()
    {
        //Creamos obraSocial
        ObraSocial Avalian = new ObraSocial("Avalian", 0.20);

        // Creamos paciente
        Paciente p1 = new Paciente(12345678, "Santiago", "Pricco", "3415551234", Avalian);
        pacientes.Add(p1);

        // Creamos 2 médicos
        Medico medicoIncorrecto = new Medico("Laura", "Lopez", "1234", "Cardiología", true);
        Medico medicoCorrecto = new Medico("Pedro", "Gomez", "5678", "Cirugía General", true);

        // Crear intervención de alta complejidad
        IntervencionQuirurgica intervencion = new AltaComplejidad(1001, "Apendicectomía", "Cirugía General", 10000);

        // Intentamos con medico incorrecto
        Console.WriteLine("\nProbamos con medico incorrecto.");
        IntervencionRealizada  i1 = CrearIntervencion(DateTime.Now, intervencion, medicoIncorrecto, p1);

        // Probar con otro Paciente
        Console.Write("\nIngrese DNI del paciente para otra intervencion: ");
        int dni = int.Parse(Console.ReadLine());
        Paciente paciente = BuscarOPedirPaciente(dni);

        // Probamos con Paciente dado
        Console.WriteLine("Probamos con otro paciente");
        IntervencionRealizada i2 = CrearIntervencion(DateTime.Now, intervencion, medicoCorrecto, paciente);

        MostrarPagosPendientes();

        //Deseamos Pagar el ticket
        Console.WriteLine("Pagamos la IntervQuirugica");
        i2.Pagar();
        pagosPendientes.RemoveAt(pagosPendientes.Count - 1);

        MostrarPagosPendientes();

        }

    //Fucnion que busca el paciente o lo crea si no existe
    static Paciente BuscarOPedirPaciente(int dni)
    {
        var paciente = pacientes.Find(p => p.DNI == dni);
        if (paciente != null)
        {
            Console.WriteLine("Paciente encontrado.");
            return paciente;
        }

        Console.WriteLine("Paciente no encontrado. Vamos a darlo de alta.");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();

        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();

        paciente = new Paciente(dni, nombre, apellido, telefono, null);
        pacientes.Add(paciente);
        Console.WriteLine("Paciente registrado exitosamente.");
        return paciente;
    }

    static IntervencionRealizada CrearIntervencion(DateTime fecha, IntervencionQuirurgica interv, Medico medico, Paciente paciente)
    {
        try
        {
            IntervencionRealizada intervRealizada = new IntervencionRealizada(fecha, interv, medico, paciente);

            // Creamos el pago
            Pago pago = new Pago(fecha, interv.ObtenerDescripcion(), paciente, medico, intervRealizada);

            pagosPendientes.Add(pago);

            Console.WriteLine("\nIntervención registrada con éxito. Comprobante:");
            pago.ImprimirPago();

            return intervRealizada;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    static void MostrarPagosPendientes()
    {
        Console.WriteLine("\nPagos pendientes de liquidación:");
        foreach (var pago in pagosPendientes)
        {
            pago.ImprimirPago();
        }
    }


}

