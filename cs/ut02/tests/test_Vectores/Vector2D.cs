namespace test_Vectores;

class Vector2D
{
    public double x;
    public double y;

    public double Modulo()
    {
        return Math.Sqrt(x*x + y*y);
    }
    
    public void Invertir()
    {
        x = -x;
        y = -y;
    }

    public bool EsIgualA(Vector2D otro)
    {
        return (x==otro.x && y==otro.y);
    }
}