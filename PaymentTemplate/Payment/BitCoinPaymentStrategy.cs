namespace PaymentTemplate.Payment
{
    public class BitCoinPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing Bitcoin payment of {amount:C}");
        }
    }
}
