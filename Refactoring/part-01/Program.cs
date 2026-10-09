using RefactoringLab;

var shipping = new ShippingCostCalculator(
[
    new AramexCarrier(),
    new FedExCarrier(),
    new DhlCarrier(),
    new BostaCarrier()
]);

Console.WriteLine($"Aramex 2kg -> {shipping.Calculate("Aramex", 2)}");
Console.WriteLine($"FedEx 2kg  -> {shipping.Calculate("FedEx", 2)}");
Console.WriteLine($"Bosta 2kg  -> {shipping.Calculate("Bosta", 2)}");
Console.WriteLine();

var processor = new OrderProcessor(new SqlOrderRepository(), new SmtpEmailSender(), new SystemClock());
processor.Process(1001, "customer@example.com");
Console.WriteLine();

new ScheduledNotification(new UrgentNotification(new EmailChannel()), DateTime.Today.AddHours(18))
    .Send("customer@example.com", "Your order ships tomorrow");
new UrgentNotification(new SmsChannel())
    .Send("+201000000000", "OTP 4821");
new ScheduledNotification(new WhatsAppChannel(), DateTime.Today.AddHours(20))
    .Send("+201000000000", "Delivery reminder");
