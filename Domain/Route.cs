namespace Domain;

public class Route
{
    public string Origin { get; }
    public string Destiny { get; }
    public double Value { get; }

    public Route(string origin, string destiny, double value)
    {
        Origin = origin;
        Destiny = destiny;
        Value = value;
    }
}
