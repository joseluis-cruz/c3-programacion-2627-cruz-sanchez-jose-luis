namespace actividad_4_2;

public class Vector2D
{
  public double X;
  public double Y;

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