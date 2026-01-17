// Step 1: Define the strategy interface
public interface IShippingStrategy
{
	decimal CalculateShippingCost(decimal orderTotal);
}

// Step 2: Implement concrete strategies
public class StandardShippingStrategy : IShippingStrategy
{
	public decimal CalculateShippingCost(decimal orderTotal)
	{
		// Implementation for standard shipping calculation
		return orderTotal * 0.05m;
	}
}

public class ExpressShippingStrategy : IShippingStrategy
{
	public decimal CalculateShippingCost(decimal orderTotal)
	{
		// Implementation for express shipping calculation
		return orderTotal * 0.1m;
	}
}

// Step 3: Define the context that uses the strategy
public class ShoppingCart
{
	private readonly IShippingStrategy _shippingStrategy;

	public ShoppingCart(IShippingStrategy shippingStrategy)
	{
		_shippingStrategy = shippingStrategy;
	}

	public decimal CalculateTotalWithShippingCost(decimal orderTotal)
	{
		decimal shippingCost = _shippingStrategy.CalculateShippingCost(orderTotal);
		return orderTotal + shippingCost;
	}
}

// Step 4: Client code
class Program
{
	static void Main(string[] args)
	{
		// Create strategies
		IShippingStrategy standardShipping = new StandardShippingStrategy();
		IShippingStrategy expressShipping = new ExpressShippingStrategy();

		// Create context with standard shipping strategy
		ShoppingCart cart = new ShoppingCart(standardShipping);
		decimal orderTotal = 100.00m;

		decimal totalWithStandardShipping = cart.CalculateTotalWithShippingCost(orderTotal);
		Console.WriteLine($"Total with standard shipping: {totalWithStandardShipping:C}");

		// Change strategy to express shipping
		cart = new ShoppingCart(expressShipping);
		decimal totalWithExpressShipping = cart.CalculateTotalWithShippingCost(orderTotal);
		Console.WriteLine($"Total with express shipping: {totalWithExpressShipping:C}");

		Console.ReadLine();
	}
}