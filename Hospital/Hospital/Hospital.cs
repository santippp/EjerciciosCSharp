using System;
using System.Collections.Generic;

public class Hospital
{
    public List<Medico> Medicos { get; set; } = new List<Medico>();
    public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
    public List<IntervencionQuirurgica> Intervenciones { get; set; } = new List<IntervencionQuirurgica>();

    public List<ObraSocial> ObrasSociales = new List<ObraSocial>();

    public Hospital()
    {
        // Medicos
        Medicos.Add(new Medico("Juan", "Pérez", "12345", "Cardiología", true));
        Medicos.Add(new Medico("Laura", "Gómez", "23456", "Traumatología", false));
        Medicos.Add(new Medico("Carlos", "Ruiz", "34567", "Neurología", true));
        Medicos.Add(new Medico("María", "Silva", "45678", "Gastroenterología", true));
        Medicos.Add(new Medico("Fernando", "Torres", "56789", "Cardiología", true));
        Medicos.Add(new Medico("Cecilia", "López", "67890", "Traumatología", true));

        //Obras Sociales
        ObraSocial obraMed = new ObraSocial("ObraMed", 0.80);
        ObraSocial saludPlus = new ObraSocial("SaludPlus", 0.90);
        ObraSocial vidaTotal = new ObraSocial("VidaTotal", 0.70);

        ObrasSociales.Add(obraMed);
        ObrasSociales.Add(saludPlus);
        ObrasSociales.Add(vidaTotal);

        // Pacientes con obra social
        Pacientes.Add(new Paciente(30111222, "Ana", "Torres", "1111-2222", obraMed));
        Pacientes.Add(new Paciente(28444555, "Clara", "Méndez", "3333-4444", saludPlus));
        Pacientes.Add(new Paciente(27555666, "Pedro", "Gómez", "4444-5555", vidaTotal));
        Pacientes.Add(new Paciente(25777888, "Jorge", "Ramírez", "6666-7777", saludPlus));

        // Pacientes sin obra social
        Pacientes.Add(new Paciente(29222333, "Luis", "Fernández", "2222-3333"));
        Pacientes.Add(new Paciente(26666777, "Lucía", "Ortega", "5555-6666"));

        // Intervenciones comunes
        Intervenciones.Add(new Normal(1, "Bypass coronario", "Cardiología", 120000));
        Intervenciones.Add(new Normal(3, "Artroscopía de rodilla", "Traumatología", 80000));
        Intervenciones.Add(new Normal(5, "Endoscopía digestiva", "Gastroenterología", 40000));
        Intervenciones.Add(new Normal(7, "Colocación de stent", "Cardiología", 95000));
        Intervenciones.Add(new Normal(8, "Reducción de fractura", "Traumatología", 60000));

        // Intervenciones de alta complejidad
        Intervenciones.Add(new AltaComplejidad(2, "Neurocirugía", "Neurología", 200000));
        Intervenciones.Add(new AltaComplejidad(4, "Revascularización miocárdica", "Cardiología", 250000));
        Intervenciones.Add(new AltaComplejidad(6, "Cirugía de columna", "Traumatología", 180000));
        Intervenciones.Add(new AltaComplejidad(9, "Cirugía bariátrica", "Gastroenterología", 220000));
        Intervenciones.Add(new AltaComplejidad(10, "Craneotomía", "Neurología", 270000));
    }

    public void AgregarPaciente(Paciente nuevoPaciente)
    {
        Pacientes.Add(nuevoPaciente);
    }
}