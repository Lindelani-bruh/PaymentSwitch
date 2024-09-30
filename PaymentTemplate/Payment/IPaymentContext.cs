﻿namespace PaymentTemplate.Payment
{
    public interface IPaymentContext
    {
        void SetPaymentStrategy(IPaymentStrategy paymentStrategy);
        void ExecutePayment(decimal amount);
    }
}
