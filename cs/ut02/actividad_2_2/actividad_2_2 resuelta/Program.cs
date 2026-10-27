namespace actividad_2_2;

class Program
{
    static void Main(string[] args)
    {
        CuentaBancaria cuenta1 = new CuentaBancaria();
        /*
        cuenta1.titular = "Juan";
        cuenta1.Ingresar(500.0);
        cuenta1.Retirar(100.0);
        cuenta1.Retirar(50.0);
        */
        cuenta1.MostrarSaldo(); // Debería mostrar: "Juan, tienes 350 €"
    }
}

class CuentaBancaria
{
    public void MostrarSaldo()
    {
        //AYUDA, cuando lo tengas todo tendrás que poner esto: $"{titular}, tienes {saldo} €"
        Console.WriteLine("Método MostrarSaldo() no implementado aún!"); 
    }    
}