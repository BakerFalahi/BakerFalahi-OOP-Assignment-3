namespace RefactoringLab;

public class OrderProcessor
{
    private readonly IOrderRepository repository;
    private readonly IEmailSender emailSender;
    private readonly IClock clock;

    public OrderProcessor(IOrderRepository repository, IEmailSender emailSender, IClock clock)
    {
        this.repository = repository;
        this.emailSender = emailSender;
        this.clock = clock;
    }

    public void Process(int orderId, string customerEmail)
    {
        var processedAt = clock.Now;

        repository.Save(orderId, processedAt);
        emailSender.Send(customerEmail, $"Order {orderId} confirmed at {processedAt}");
    }
}

public interface IOrderRepository
{
    void Save(int orderId, DateTime processedAt);
}

public interface IEmailSender
{
    void Send(string to, string body);
}

public interface IClock
{
    DateTime Now { get; }
}

public sealed class SystemClock : IClock
{
    public DateTime Now => DateTime.Now;
}

public sealed class SqlOrderRepository : IOrderRepository
{
    public void Save(int orderId, DateTime processedAt) =>
        Console.WriteLine($"[SQL] save order {orderId} @ {processedAt:O}");
}

public sealed class SmtpEmailSender : IEmailSender
{
    public void Send(string to, string body) =>
        Console.WriteLine($"[SMTP] to={to} body={body}");
}
