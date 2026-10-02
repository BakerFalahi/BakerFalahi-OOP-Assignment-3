namespace RefactoringLab;

public class ShippingCostCalculator
{
    private readonly Dictionary<string, IShippingCarrier> carriers;

    public ShippingCostCalculator(IEnumerable<IShippingCarrier> carriers)
    {
        this.carriers = carriers.ToDictionary(carrier => carrier.Name, StringComparer.OrdinalIgnoreCase);
    }

    public decimal Calculate(string carrier, decimal weightKg)
    {
        if (!carriers.TryGetValue(carrier, out var shippingCarrier))
        {
            throw new ArgumentException($"Unknown carrier: {carrier}");
        }

        return shippingCarrier.Calculate(weightKg);
    }
}

public interface IShippingCarrier
{
    string Name { get; }
    decimal Calculate(decimal weightKg);
}

public sealed class AramexCarrier : IShippingCarrier
{
    public string Name => "Aramex";

    public decimal Calculate(decimal weightKg) => weightKg * 12m;
}

public sealed class FedExCarrier : IShippingCarrier
{
    public string Name => "FedEx";

    public decimal Calculate(decimal weightKg) => weightKg * 15m;
}

public sealed class DhlCarrier : IShippingCarrier
{
    public string Name => "DHL";

    public decimal Calculate(decimal weightKg) => weightKg * 18m;
}

public sealed class BostaCarrier : IShippingCarrier
{
    public string Name => "Bosta";

    public decimal Calculate(decimal weightKg) => weightKg * 10m;
}
