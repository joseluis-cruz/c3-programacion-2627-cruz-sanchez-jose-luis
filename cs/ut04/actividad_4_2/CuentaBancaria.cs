namespace actividad_4_2;
public class CuentaBancaria
{
    public string Titular; // nombre del titular de la cuenta
    public double Saldo; // saldo (importe económico) de la cuenta
    public void MostrarSaldo()
    {
        //AYUDA, cuando lo tengas todo tendrás que poner esto: $"{titular}, tienes {saldo} €"
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