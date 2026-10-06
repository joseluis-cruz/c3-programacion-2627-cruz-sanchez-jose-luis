namespace HolaPOO;

class Program
{
  static async Task Main(string[] args)
  {
    HttpClient cliente = new HttpClient();

    string respuesta = await cliente.GetStringAsync("https://cifpcarlos3.es/es");

    Console.WriteLine(respuesta);
  }
}