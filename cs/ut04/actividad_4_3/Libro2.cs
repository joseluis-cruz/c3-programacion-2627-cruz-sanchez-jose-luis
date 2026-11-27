namespace actividad_4_3;

public class Libro2
{
    private string _titulo; // Título del libro.
    public string Titulo
    {
        get
        {
            return _titulo;
        }
        set
        {
            _titulo = value;
        }
    }    
    private string _autor; // Nombre del autor.
    public string Autor
    {
        get
        {
            return _autor;
        }
        set
        {
            _autor = value;
        }
    }     
    private int _idCliente; // Identificador del último cliente que ha tomado prestado el ejemplar. Inicialmente será 0.
    public int IdCliente
    {
        get
        {
            return _idCliente;
        }
        set
        {
            _idCliente = value;
        }
    } 
    private int _vecesPrestado; // Número de veces que se ha prestado el ejemplar.
    public int VecesPrestado
    {
        get
        {
            return _vecesPrestado;
        }
        set
        {
            _vecesPrestado = value;
        }        
    }
    private string _estado; // Estado del ejemplar: "P" (prestado), "D" (disponible) o "N" (no disponible).    
    public string Estado
    {
        get
        {
            return _estado;
        }
        set
        {
            _estado = value;
        }        
    }
    // Inicializa el estado del ejemplar a "D" (disponible) y los atributos VecesPrestado e IdCliente a cero.
    public void Comprar() 
    {
        _estado = "D";
        _vecesPrestado = 0;
        _idCliente = 0;
    }

    // Cambia el estado del ejemplar a "P" (prestado), almacena en el atributo IdCliente el identificador del cliente...
    // ... recibido e incrementa en una unidad el contador VecesPrestado.
    public void Prestar(int cliente) 
    {
        _estado = "P";
        _idCliente = cliente;
        _vecesPrestado++;                        
    }

    // Cambia el estado del ejemplar a "D" (disponible) y devuelve el identificador del cliente....
    //  ...que lo tenía prestado, para permitir comprobar que realmente lo tenía ese cliente, sin modificar el atributo IdCliente.
    public int Devolver()     
    {
        _estado = "D";
        return _idCliente;
    }

    // Cambia el estado del ejemplar a "N" (no disponible), salvo que actualmente esté prestado ("P"). En ese caso, deberá lanzar...
    // ... una excepción con el mensaje indicado a continuación, sin modificar su estado.
    public void Retirar() 
    {
        if (_estado=="P")
        {
            throw new Exception ("El libro está prestado y no puede marcarse como no disponible mientras no se devuelva");
        }
        else
        {
            _estado = "N";            
        }
    }
    
    // Devuelve una cadena de caracteres que describe el estado actual del ejemplar, incluyendo su título, su estado y...
    // ... el identificador del cliente, siguiendo el formato indicado a continuación.
    public string DescribeEstado() 
    {
        return $"El ejemplar titulado {_titulo} se encuentra en estado {_estado} y vinculado al cliente con id {_idCliente}";
    }

}