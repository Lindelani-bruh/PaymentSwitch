using Ardalis.GuardClauses;

namespace PaymentTemplate.Payment
{
    public class PayPalPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            // Guard clause
            Guard.Against.NegativeOrZero(amount, nameof(amount));
            Console.WriteLine($"Processing PayPal payment of {amount:C}");
        }
    }
}
