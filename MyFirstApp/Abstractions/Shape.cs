
public abstract class Shape
{
    private string _name;
    public string Name => _name;

    protected Shape(string name)
    {
        _name = name;
    }

    public abstract double Area();
}