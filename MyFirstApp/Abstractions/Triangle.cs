
public class Triangle : Shape
{
    private double width;
    private double height;

    public Triangle(double width, double height) : base("Triangle")
    {
        this.width = width;
        this.height = height;
    }

    public override double Area()
    {
        return 1.0 / 2 * (width * height);
    }
}