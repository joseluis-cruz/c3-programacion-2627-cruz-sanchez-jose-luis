namespace actividad_4_3;
public class CuentaBancaria3
{
    public string Titular { get; set; }
    public double Saldo { get; private set; }
    public void MostrarSaldo()
    {
        Console.WriteLine($"{Titular}, tienes {Saldo} €"); 
    }   
    //Ingresar una cantidad
    public void Ingresar(double cantidad)
    {
        Saldo += cantidad;
    }
    //Retirar una cantidad
    public double Retirar(double cantidad)
    {
        Saldo -= cantidad;
        return Saldo;
    }

}