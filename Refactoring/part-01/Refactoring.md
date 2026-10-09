# Refactoring - Part 01

## ShippingCostCalculator

The original calculator used a `switch` on carrier names. Adding a carrier meant editing the calculator itself, so it violated the Open/Closed Principle.

I replaced the branching with `IShippingCarrier` implementations. `ShippingCostCalculator` now receives the available carriers and looks them up by name. I added `BostaCarrier` without changing the existing carrier classes.

## OrderProcessor

The original processor created `SqlOrderRepository` and `SmtpEmailSender` inside `Process`, which made it depend directly on concrete infrastructure classes.

I introduced `IOrderRepository`, `IEmailSender`, and `IClock`, then injected them through the constructor. The processor now coordinates the workflow without knowing how orders are saved or emails are sent.

## Notifications

The original notification classes used inheritance for every channel and behavior combination. That design grows quickly as more channels or options are added.

I replaced it with composition. Channels implement `INotification`, while `UrgentNotification` and `ScheduledNotification` wrap any channel. Email, SMS, and WhatsApp can now be urgent, scheduled, or both without creating a separate class for each combination.
