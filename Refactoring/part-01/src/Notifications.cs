namespace RefactoringLab;

public interface INotification
{
    void Send(string to, string message, DateTime? sendAt = null);
}

public sealed class EmailChannel : INotification
{
    public void Send(string to, string message, DateTime? sendAt = null)
    {
        Console.WriteLine(sendAt is null
            ? $"[email] {to}: {message}"
            : $"[email scheduled {sendAt:g}] {to}: {message}");
    }
}

public sealed class SmsChannel : INotification
{
    public void Send(string to, string message, DateTime? sendAt = null)
    {
        Console.WriteLine(sendAt is null
            ? $"[sms] {to}: {message}"
            : $"[sms scheduled {sendAt:g}] {to}: {message}");
    }
}

public sealed class WhatsAppChannel : INotification
{
    public void Send(string to, string message, DateTime? sendAt = null)
    {
        Console.WriteLine(sendAt is null
            ? $"[whatsapp] {to}: {message}"
            : $"[whatsapp scheduled {sendAt:g}] {to}: {message}");
    }
}

public sealed class UrgentNotification : INotification
{
    private readonly INotification inner;

    public UrgentNotification(INotification inner)
    {
        this.inner = inner;
    }

    public void Send(string to, string message, DateTime? sendAt = null)
    {
        inner.Send(to, $"[URGENT] {message}", sendAt);
    }
}

public sealed class ScheduledNotification : INotification
{
    private readonly INotification inner;
    private readonly DateTime sendAt;

    public ScheduledNotification(INotification inner, DateTime sendAt)
    {
        this.inner = inner;
        this.sendAt = sendAt;
    }

    public void Send(string to, string message, DateTime? sendAt = null)
    {
        inner.Send(to, message, sendAt ?? this.sendAt);
    }
}
