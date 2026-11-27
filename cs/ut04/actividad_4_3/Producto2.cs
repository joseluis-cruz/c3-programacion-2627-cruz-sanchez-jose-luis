namespace actividad_4_3;

public class Producto2
{
    private string _nombre; // Descripción del producto
    public string Nombre
    {
        get
        {
            return _nombre;
        }
        set
        {
            _nombre = value;
        }        
    }
    private string _codigoBarras; //Código de barras del producto.
    public string CodigoBarras
    {
        get
        {
            return _codigoBarras;
        }
        set
        {
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
            _existencias = value;
        }
    }
    private double _precioCoste; // Precio de coste por unidad.
    public double PrecioCoste
    {
        get
        {
            return _precioCoste;
        }
        set
        {
            _precioCoste = value;
        }        
    }
    private double _precioVenta; //Precio de venta por unidad.
    public double PrecioVenta
    {
        get
        {
            return _precioVenta;
        }
        set
        {
            _precioVenta = value;
        }        
    }


    public void Comprar(int cantidad, double precio) // Incrementa Existencias en la cantidad indicada y establece PrecioCoste con el valor recibido en precio.
    {
        _precioCoste = precio;
        _existencias += cantidad;
    }
    public double Vender(int cantidad) // Descuenta la cantidad indicada de Existencias y devuelve el importe total de la venta, calculado como cantidad * PrecioVenta.
    {
        _existencias -= cantidad;        
        return cantidad*_precioVenta;
    }
    public void EstablecerMargen(double porcentaje) // Calcula y actualiza PrecioVenta aplicando el incremento porcentual indicado sobre el valor actual de PrecioCoste.
    {
        _precioVenta = _precioCoste * (1 + (porcentaje / 100));
    }
    
}