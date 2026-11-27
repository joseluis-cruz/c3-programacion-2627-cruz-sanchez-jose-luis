namespace actividad_4_3;

public class Producto3
{
    public string Nombre { get; set; }
    private string _codigoBarras; //Código de barras del producto.
    public string CodigoBarras
    {
        get
        {
            return _codigoBarras;
        }
        set
        {
            if (value.Length>20)
            {
                throw new Exception("El código de barras no puede superar los 20 caracteres de longitud.");
            }
            _codigoBarras = value;
        }        
    }
    private int _existencias; // Número de unidades disponibles.
    public int Existencias
    {
        get
        {
            return _existencias;
        }
        set
        {
            if (value<0)
            {
                throw new Exception("Las existencias no pueden ser negativas.");
            }
            _existencias = value;
        }
    }

    public double PrecioCoste {get; private set;}

    public double PrecioVenta {get; private set;}

    public void Comprar(int cantidad, double precio) // Incrementa Existencias en la cantidad indicada y establece PrecioCoste con el valor recibido en precio.
    {
        PrecioCoste = precio;
        Existencias += cantidad;
        /* ATENCIÓN: Aunque existe el atributo privado _existencias...
        ...accedo a la propiedad Existencias para que se hagan las...
        ...verificaciones de su método set() */
    }
    public double Vender(int cantidad) // Descuenta la cantidad indicada de Existencias y devuelve el importe total de la venta, calculado como cantidad * PrecioVenta.
    {
        Existencias -= cantidad;        
        /* ATENCIÓN: Aunque existe el atributo privado _existencias...
        ...accedo a la propiedad Existencias para que se hagan las...
        ...verificaciones de su método set() */
        return cantidad*PrecioVenta;
    }
    public void EstablecerMargen(double porcentaje) // Calcula y actualiza PrecioVenta aplicando el incremento porcentual indicado sobre el valor actual de PrecioCoste.
    {
        PrecioVenta = PrecioCoste * (1 + (porcentaje / 100));
    }
    
}