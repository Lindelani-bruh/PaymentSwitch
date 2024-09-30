using PaymentTemplate;
using PaymentTemplate.Payment;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPaymentContext, PaymentContext>();
builder.Services.AddSingleton<CreditCardPaymentStrategy>();
builder.Services.AddSingleton<PayPalPaymentStrategy>();
builder.Services.AddSingleton<BitCoinPaymentStrategy>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/Pay", async (decimal amount,
                            string method,
                            IPaymentContext paymentContext,
                            IServiceProvider serviceProvider) =>
{
    IPaymentStrategy strategy = method.ToLower()
    switch
    {
        "creditcard" => serviceProvider.GetRequiredService<CreditCardPaymentStrategy>(),
        "paypal" => serviceProvider.GetRequiredService<PayPalPaymentStrategy>(),
        "bitcoin" => serviceProvider.GetRequiredService<BitCoinPaymentStrategy>(),
        _ => throw new NotSupportedException("Invalid payment method.")
    };

    paymentContext.SetPaymentStrategy(strategy);
    paymentContext.ExecutePayment(amount);

    return Results.Ok($"Payment of {amount:C} using {method} processed successfully.");
});

app.Run();