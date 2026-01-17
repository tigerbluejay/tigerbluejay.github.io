// Target interface that the client expects
interface IPaymentGateway
{
	void ProcessPayment(decimal amount);
}

// Adaptee class with incompatible interface
class ThirdPartyPaymentGateway
{
	public void MakePayment(decimal amount)
	{
		Console.WriteLine("Processing payment of amount: $" + amount + " via ThirdPartyPaymentGateway");
	}
}

// Adapter class that adapts the ThirdPartyPaymentGateway to the IPaymentGateway interface
class ThirdPartyPaymentGatewayAdapter : IPaymentGateway
{
	private ThirdPartyPaymentGateway paymentGateway;

	public ThirdPartyPaymentGatewayAdapter(ThirdPartyPaymentGateway paymentGateway)
	{
		this.paymentGateway = paymentGateway;
	}

	public void ProcessPayment(decimal amount)
	{
		// Perform necessary operations to adapt the interface
		// Call the specific method of the ThirdPartyPaymentGateway
		paymentGateway.MakePayment(amount);
	}
}

// Client code
class PaymentProcessor
{
	private IPaymentGateway paymentGateway;

	public PaymentProcessor(IPaymentGateway paymentGateway)
	{
		this.paymentGateway = paymentGateway;
	}

	public void ProcessPaymentRequest(decimal amount)
	{
		paymentGateway.ProcessPayment(amount);
	}
}

// Usage
class Program
{
	static void Main(string[] args)
	{
		// Create an instance of the ThirdPartyPaymentGateway
		ThirdPartyPaymentGateway paymentGateway = new ThirdPartyPaymentGateway();

		// Create an instance of the ThirdPartyPaymentGatewayAdapter and pass the ThirdPartyPaymentGateway to its constructor
		IPaymentGateway adaptedPaymentGateway = new ThirdPartyPaymentGatewayAdapter(paymentGateway);

		// Create an instance of the PaymentProcessor and pass the adaptedPaymentGateway to its constructor
		PaymentProcessor paymentProcessor = new PaymentProcessor(adaptedPaymentGateway);

		// Process payment request
		decimal paymentAmount = 100.50m;
		paymentProcessor.ProcessPaymentRequest(paymentAmount);
	}
}