using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Pago> pagosPendientes = new List<Pago>();
    static Hospital hospital = new Hospital();

    static void Main()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine("1. Agregar nuevo paciente");
            Console.WriteLine("2. Listar todos los pacientes");
            Console.WriteLine("3. Asignar intervención a paciente");
            Console.WriteLine("4. Calcular costo de intervenciones por DNI");
            Console.WriteLine("5. Reporte de pagos pendientes");
            Console.WriteLine("6. Pagar intervención");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione opción: ");

            switch (Console.ReadLine())
            {
                case "1": AgregarPacienteMenu(); break;
                case "2": ListarPacientes(); break;
                case "3": AsignarIntervencion(); break;
                case "4": CalcularCostosPorDNI(); break;
                case "5": MostrarPagosPendientes(); break;
                case "6": PagarIntervencion(); break;
                case "7": salir = true; break;
                default: Console.WriteLine("Opción invalida"); break;
            }
        }
    }

    static void AgregarPacienteMenu()
    {
        Console.Write("DNI: ");
        int dni = int.Parse(Console.ReadLine());
        AgregarPaciente(dni);
    }

    static void AgregarPaciente(int dni)
    {
        // Verificar si el paciente ya existe
        if (hospital.BuscarPaciente(dni) != null)
        {
            Console.WriteLine("Paciente ya existe");
            return;
        }

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();

        Console.Write("¿Tiene obra social? (s/n): ");
        if (Console.ReadLine().ToLower() == "s")
        {
            Console.WriteLine("Obras sociales disponibles:");
            for (int i = 0; i < hospital.ObrasSociales.Count; i++)
                Console.WriteLine($"{i + 1}. {hospital.ObrasSociales[i].Nombre}");

            Console.Write("Seleccione obra social: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            hospital.AgregarPaciente(new Paciente(dni, nombre, apellido, telefono, hospital.ObrasSociales[index]));
        }
        else
        {
            hospital.AgregarPaciente(new Paciente(dni, nombre, apellido, telefono));
        }
        Console.WriteLine("Paciente agregado exitosamente");
    }

    static void ListarPacientes()
    {
        Console.WriteLine("\nLISTA DE PACIENTES");
        foreach (var p in hospital.Pacientes)
        {
            Console.WriteLine($"{p.DNI}: {p.Nombre} {p.Apellido} - Tel: {p.Telefono} - OS: {(p.ObraSocial?.Nombre ?? "Ninguna")}");
        }
    }

    static void AsignarIntervencion()
    {
        Console.Write("DNI del paciente: ");
        int dni = int.Parse(Console.ReadLine());

        // Buscar paciente existente
        Paciente paciente = hospital.BuscarPaciente(dni);

        // Si no existe, llamar a AgregarPaciente
        if (paciente == null)
        {
            Console.WriteLine("El paciente no existe, vamos a registrarlo");
            AgregarPaciente(dni);  // Pasamos el DNI para evitar pedirlo denuevo
            paciente = hospital.BuscarPaciente(dni);  // Agarramos el paciente creado
        }

        // Continuamos con el proceso
        Console.WriteLine("\nINTERVENCIONES DISPONIBLES");
        for (int i = 0; i < hospital.Intervenciones.Count; i++)
            Console.WriteLine($"{i + 1}. {hospital.Intervenciones[i].Descripcion} ({hospital.Intervenciones[i].Especialidad})");

        Console.Write("Seleccione intervencion: ");
        int indexInterv = int.Parse(Console.ReadLine()) - 1;
        var intervencion = hospital.Intervenciones[indexInterv];

        var medicosDisponibles = hospital.Medicos
            .Where(m => m.Especialidad == intervencion.Especialidad && m.Condicion)
            .ToList();

        if (medicosDisponibles.Count == 0)
        {
            Console.WriteLine("No hay medicos disponibles para esta intervencion");
            return;
        }

        Console.WriteLine("\nMÉDICOS DISPONIBLES");
        for (int i = 0; i < medicosDisponibles.Count; i++)
            Console.WriteLine($"{i + 1}. {medicosDisponibles[i].Nombre} {medicosDisponibles[i].Apellido}");

        Console.Write("Seleccione medico: ");
        int indexMedico = int.Parse(Console.ReadLine()) - 1;

        try
        {
            var intervRealizada = new IntervencionRealizada(
                DateTime.Now,
                intervencion,
                medicosDisponibles[indexMedico],
                paciente
            );

            var pago = new Pago(
                DateTime.Now,
                intervencion.Descripcion,
                paciente,
                medicosDisponibles[indexMedico],
                intervRealizada
            );

            pagosPendientes.Add(pago);
            Console.WriteLine("\nIntervencion asignada exitosamente. Comprobante:");
            pago.ImprimirPago();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void CalcularCostosPorDNI()
    {
        Console.Write("DNI del paciente: ");
        int dni = int.Parse(Console.ReadLine());
        var paciente = hospital.BuscarPaciente(dni);

        if (paciente == null)
        {
            Console.WriteLine("Paciente no encontrado");
            return;
        }

        Console.WriteLine($"Costo total: {paciente.CalcularCostoTotal():C}");
        Console.WriteLine($"Costo pendiente: {paciente.CalcularCostoPendiente():C}");
    }

    static void MostrarPagosPendientes()
    {
        Console.WriteLine("\nPAGOS PENDIENTES");
        foreach (var pago in pagosPendientes)
        {
            pago.ImprimirPago();
        }
    }

    static void PagarIntervencion()
    {
        if (pagosPendientes.Count == 0)
        {
            Console.WriteLine("No hay pagos pendientes");
            return;
        }

        Console.WriteLine("Seleccione pago a liquidar:");
        for (int i = 0; i < pagosPendientes.Count; i++)
            Console.WriteLine($"{i + 1}. {pagosPendientes[i].Descripcion} - {pagosPendientes[i].NombrePaciente}");

        Console.Write("Seleccione: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        pagosPendientes[index].IntervencionRealizada.Pagar();
        pagosPendientes.RemoveAt(index);
        Console.WriteLine("Pago realizado exitosamente");
    }

}