namespace PaymentTemplate.Payment
{
    public class PaymentContext : IPaymentContext
    {
        private IPaymentStrategy _paymentStrategy { get; set; }
        public void ExecutePayment(decimal amount)
        {
            _paymentStrategy.ProcessPayment(amount);
        }

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }
    }
}
