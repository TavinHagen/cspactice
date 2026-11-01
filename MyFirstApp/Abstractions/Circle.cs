
public class Circle : Shape
{
    private double radius;

    public Circle(double radius) : base("Circle")
    {
        this.radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Math.Pow(radius, 2);
    }
}