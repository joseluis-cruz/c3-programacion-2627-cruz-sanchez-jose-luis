namespace actividad_4_3;

public class Vector2D2
{
  private double _x;
  public double X
  {
      get
      {
          return _x;
      }
      set
      {
          _x = value;
      }
  } 

  private double _y;
  public double Y
  {
      get
      {
          return _y;
      }
      set
      {
          _y = value;
      }
  }   

  public double ObtenerModulo()
  {
    return Math.Sqrt(_x * _x + _y * _y);
  }

  public void Invertir()
  {
    _x = -_x;
    _y = -_y;
  }
}