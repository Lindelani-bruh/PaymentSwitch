using Ardalis.GuardClauses;

namespace PaymentTemplate.Payment
{
    public class BitCoinPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            // Guard clause
            Guard.Against.NegativeOrZero(amount, nameof(amount));

            Console.WriteLine($"Processing Bitcoin payment of {amount:C}");
        }
    }
}
