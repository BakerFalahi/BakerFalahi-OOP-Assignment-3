namespace RefactoringLab.Part02.Enrollment;

public sealed class EnrollmentFacade
{
    private readonly PaymentGateway payment;
    private readonly SeatInventory seats;
    private readonly InvoiceGenerator invoices;
    private readonly EmailService email;

    public EnrollmentFacade(
        PaymentGateway payment,
        SeatInventory seats,
        InvoiceGenerator invoices,
        EmailService email)
    {
        this.payment = payment;
        this.seats = seats;
        this.invoices = invoices;
        this.email = email;
    }

    public void Enroll(string studentId, string courseId, decimal amount)
    {
        payment.Charge(studentId, amount);
        seats.Reserve(courseId, studentId);
        var invoiceId = invoices.Create(studentId, amount);
        email.Send(studentId, "Enrollment confirmed", $"Invoice {invoiceId} for {courseId}");
    }
}
