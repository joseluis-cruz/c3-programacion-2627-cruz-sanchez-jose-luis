namespace actividad_4_3;

public class Libro3
{
    public string Titulo {get; set;}
    public string Autor {get; set;}
    public int IdCliente {get; private set;}
    public int VecesPrestado {get; private set;}
    private string _estado; // Estado del ejemplar: "P" (prestado), "D" (disponible) o "N" (no disponible).    
    public string Estado
    {
        get
        {
            return _estado;
        }
        set
        {
            if (value != "D" && value != "N" && value != "P")
            {
                throw new Exception("Estado no válido, debe ser 'D', 'N' o 'P'");
            }
            _estado = value;
        }        
    }
    // Inicializa el estado del ejemplar a "D" (disponible) y los atributos VecesPrestado e IdCliente a cero.
    public void Comprar() 
    {
        Estado = "D";
        VecesPrestado = 0;
        IdCliente = 0;
    }

    // Cambia el estado del ejemplar a "P" (prestado), almacena en el atributo IdCliente el identificador del cliente...
    // ... recibido e incrementa en una unidad el contador VecesPrestado.
    public void Prestar(int cliente) 
    {
        Estado = "P";
        IdCliente = cliente;
        VecesPrestado++;                        
    }

    // Cambia el estado del ejemplar a "D" (disponible) y devuelve el identificador del cliente....
    //  ...que lo tenía prestado, para permitir comprobar que realmente lo tenía ese cliente, sin modificar el atributo IdCliente.
    public int Devolver()     
    {
        Estado = "D";
        return IdCliente;
    }

    // Cambia el estado del ejemplar a "N" (no disponible), salvo que actualmente esté prestado ("P"). En ese caso, deberá lanzar...
    // ... una excepción con el mensaje indicado a continuación, sin modificar su estado.
    public void Retirar() 
    {
        if (Estado=="P")
        {
            throw new Exception ("El libro está prestado y no puede marcarse como no disponible mientras no se devuelva");
        }
        else
        {
            Estado = "N";            
        }
    }
    
    // Devuelve una cadena de caracteres que describe el estado actual del ejemplar, incluyendo su título, su estado y...
    // ... el identificador del cliente, siguiendo el formato indicado a continuación.
    public string DescribeEstado() 
    {
        return $"El ejemplar titulado {Titulo} se encuentra en estado {Estado} y vinculado al cliente con id {IdCliente}";
    }

}