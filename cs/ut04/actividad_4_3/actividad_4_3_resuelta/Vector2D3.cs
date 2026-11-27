namespace actividad_4_3;

public class Vector2D3
{
  public double X { get; set; } 
  public double Y { get; set; } 

  public double ObtenerModulo()
  {
    return Math.Sqrt(X * X + Y * Y);
  }

  public void Invertir()
  {
    X = -X;
    Y = -Y;
  }
}