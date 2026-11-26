namespace actividad_4_2;
public class CuentaBancaria2
{
    private string _titular; // nombre del titular de la cuenta
    public string Titular
    {
        get
        {
            return _titular;
        }
        set
        {
            _titular = value;
        }
    }
    private double _saldo; // saldo (importe económico) de la cuenta
    public double Saldo
    {
        get
        {
            return _saldo;
        }
        set
        {
            _saldo = value;
        }
    }
    public void MostrarSaldo()
    {
        //AYUDA, cuando lo tengas todo tendrás que poner esto: $"{titular}, tienes {saldo} €"
        Console.WriteLine($"{_titular}, tienes {_saldo} €"); 
    }   
    //Ingresar una cantidad
    public void Ingresar(double cantidad)
    {
        _saldo += cantidad;
    }
    //Retirar una cantidad
    public double Retirar(double cantidad)
    {
        _saldo -= cantidad;
        return _saldo;
    }

}