using System;

class Program
{
    static void Main(string[] args)
    {
        // Crear banco
        Banco banco = new Banco();

        // Crear cuentas bancarias
        CuentaBancaria cuenta1 = new CuentaBancaria(1001, 1000, "Juan");
        CuentaBancaria cuenta2 = new CuentaBancaria(1002, 500, "Ana");

        // Mostrar saldos iniciales
        Console.WriteLine("Saldos Iniciales");
        Console.WriteLine($"Cuenta de Juan: {cuenta1.ObtenerSaldo()}");
        Console.WriteLine($"Cuenta de Ana:  {cuenta2.ObtenerSaldo()}");
        Console.WriteLine();

        // Depositar dinero en cuenta2
        banco.Depositar(200, cuenta2);
        Console.WriteLine("Se depositaron $200 a la cuenta de Ana.");

        // Extraer dinero de cuenta1
        banco.Extraer(150, cuenta1);
        Console.WriteLine("Se extrajeron $150 de la cuenta de Juan.");

        // Intentar una transferencia de $300
        bool exito = banco.Transferencia(cuenta1, 300, cuenta2);

        if (exito)
            Console.WriteLine("La transferencia tuvo exito");
        else
                Console.WriteLine("La transferencia fallo");

        // Mostrar saldos finales
        Console.WriteLine("Saldos Finales");
        Console.WriteLine($"Cuenta de Juan: {cuenta1.ObtenerSaldo()}");
        Console.WriteLine($"Cuenta de Ana: {cuenta2.ObtenerSaldo()}");
    }
}
