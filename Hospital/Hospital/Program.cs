using System;
using System.Collections;
using System.Collections.Generic;

class Program
{

    //Listamos los pagos pendientes
    static List<Pago> pagosPendientes = new List<Pago>();

    static void Main()
    {

        Hospital hospital = new Hospital(); 

        // Intentamos con medico incorrecto
        Console.WriteLine("\nProbamos con medico incorrecto.");
        //Medico de Cardiologia para Traumatologia
        IntervencionRealizada  i1 = CrearIntervencion(DateTime.Now, hospital.Intervenciones[1], hospital.Medicos[0], hospital.Pacientes[0]);

        // Probar con otro Paciente
        Console.Write("\nIngrese DNI del paciente para otra intervencion: ");
        int dni = int.Parse(Console.ReadLine());
        Paciente paciente = BuscarOPedirPaciente(hospital, dni);

        // Probamos con Paciente dado
        Console.WriteLine("Probamos con otro paciente");
        IntervencionRealizada i2 = CrearIntervencion(DateTime.Now, hospital.Intervenciones[0], hospital.Medicos[0], paciente);

        MostrarPagosPendientes();

        //Deseamos Pagar el ticket
        Console.WriteLine("Pagamos la IntervQuirugica");
        i2.Pagar();
        pagosPendientes.RemoveAt(pagosPendientes.Count - 1);

        MostrarPagosPendientes();

    }

    //Fucnion que busca el paciente o lo crea si no existe
    static Paciente BuscarOPedirPaciente(Hospital hospital, int dni)
    {
        var paciente = hospital.Pacientes.Find(p => p.DNI == dni);
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
        hospital.AgregarPaciente(paciente);
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
        Console.WriteLine("\nPagos pendientes de liquidación:\n");
        foreach (var pago in pagosPendientes)
        {
            pago.ImprimirPago();
        }
    }


}

