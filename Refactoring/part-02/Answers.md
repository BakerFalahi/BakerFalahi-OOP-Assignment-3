# Part 02 Answers

## Reports

I used the Template Method pattern with an abstract `ReportExporter` class. The `Export` method now defines the full workflow once: load, validate, format, and save.

An abstract class is a better fit than an interface here because there is real shared behavior, not just a shared method shape. The subclasses only provide the part that changes, which is the report formatting.

## Enrollment

The facade hides the steps needed to enroll a student. `Program.cs` no longer needs to know that enrollment requires charging payment, reserving a seat, creating an invoice, and sending an email in that order.

The caller now makes one call to `Enroll`, while the facade keeps the workflow in one place.
