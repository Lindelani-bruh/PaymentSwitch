namespace PaymentTemplate
{
    public interface IPaymentStrategy
    {
        void ProcessPayment(decimal amount);
    }
}
