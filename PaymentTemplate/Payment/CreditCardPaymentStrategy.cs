using Ardalis.GuardClauses;

namespace PaymentTemplate.Payment
{
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            // Guard clause
            Guard.Against.NegativeOrZero(amount, nameof(amount));
            Console.WriteLine($"Processing credit card payment of {amount:C}");
        }
    }
}
