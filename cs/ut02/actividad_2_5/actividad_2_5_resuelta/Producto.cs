namespace actividad_2_5;

public class Producto
{
    public string Nombre; // Descripción del producto
    public string CodigoBarras; //Código de barras del producto.
    public int Existencias; // Número de unidades disponibles.
    public double PrecioCoste; // Precio de coste por unidad.
    public double PrecioVenta; //Precio de venta por unidad.


    public void Comprar(int cantidad, double precio) // Incrementa Existencias en la cantidad indicada y establece PrecioCoste con el valor recibido en precio.
    {
        PrecioCoste = precio;
        Existencias += cantidad;
    }
    public double Vender(int cantidad) // Descuenta la cantidad indicada de Existencias y devuelve el importe total de la venta, calculado como cantidad * PrecioVenta.
    {
        Existencias -= cantidad;        
        return cantidad*PrecioVenta;
    }
    public void EstablecerMargen(double porcentaje) // Calcula y actualiza PrecioVenta aplicando el incremento porcentual indicado sobre el valor actual de PrecioCoste.
    {
        PrecioVenta = PrecioCoste * (1 + (porcentaje / 100));
    }
    
}