public class CuentaBancaria
{
    private int NumeroCuenta;
    private int Saldo;
    private string Nombre;

    public CuentaBancaria(int numeroCuenta, int saldo, string name)
    {
        NumeroCuenta = numeroCuenta;
        Saldo = saldo;
        Nombre = name;
    }

    public int ObtenerSaldo()
    {
        return Saldo;
    }

    public void ModificarSaldo(int nuevoSaldo)
    {
        Saldo = nuevoSaldo;
    }
}

public class Banco
{
    public Banco() { }

    public void Depositar(int monto, CuentaBancaria cuenta)
    {
        if (monto < 0) return;

        cuenta.ModificarSaldo(cuenta.ObtenerSaldo() + monto);
    }

    public void Extraer(int monto, CuentaBancaria cuenta)
    {
        //Si el monto es mayor se le devuelve 0 a la cuenta
        if (cuenta.ObtenerSaldo() < monto)
        {
            cuenta.ModificarSaldo(0);
            return;
        }

        cuenta.ModificarSaldo(cuenta.ObtenerSaldo() - monto);
    }

    public bool Transferencia(CuentaBancaria origen, int monto, CuentaBancaria destino)
    {
        if (origen.ObtenerSaldo() < monto) return false;

        Extraer(monto, origen);
        Depositar(monto, destino);
        return true;


    }
}