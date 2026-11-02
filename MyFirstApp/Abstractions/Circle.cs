
public class Circle : Shape
{
    private double radius;
    private double area;

    public Circle(double radius) : base("Circle")
    {
        this.radius = radius;
        area = 0;
    }

    public override double Area()
    {
        return Math.PI * Math.Pow(radius, 2);
    }
}