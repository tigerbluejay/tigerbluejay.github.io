using System;

// Mediator interface
public interface IFlightBookingMediator
{
	void SearchFlights(string origin, string destination, DateTime date);
	void SelectFlight(string flightNumber);
	void BookFlight(string passengerName, string flightNumber);
	void ProcessPayment(string passengerName, string flightNumber, decimal amount);
}

// Concrete Mediator
public class FlightBookingMediator : IFlightBookingMediator
{
	private FlightSearchComponent flightSearchComponent;
	private PassengerInfoComponent passengerInfoComponent;
	private PaymentComponent paymentComponent;

	public FlightBookingMediator(FlightSearchComponent flightSearchComponent,
								 PassengerInfoComponent passengerInfoComponent,
								 PaymentComponent paymentComponent)
	{
		this.flightSearchComponent = flightSearchComponent;
		this.passengerInfoComponent = passengerInfoComponent;
		this.paymentComponent = paymentComponent;
	}

	public void SearchFlights(string origin, string destination, DateTime date)
	{
		// Perform flight search logic and update UI components
		// ...
		Console.WriteLine("Mediator: Flight search completed.");
		flightSearchComponent.DisplaySearchResults();
	}

	public void SelectFlight(string flightNumber)
	{
		// Perform flight selection logic and update UI components
		// ...
		Console.WriteLine("Mediator: Flight selected.");
		passengerInfoComponent.EnablePassengerInfoForm();
	}

	public void BookFlight(string passengerName, string flightNumber)
	{
		// Perform flight booking logic and update UI components
		// ...
		Console.WriteLine("Mediator: Flight booked.");
		paymentComponent.EnablePaymentForm();
	}

	public void ProcessPayment(string passengerName, string flightNumber, decimal amount)
	{
		// Perform payment processing logic and update UI components
		// ...
		Console.WriteLine("Mediator: Payment processed.");
		flightSearchComponent.Reset();
		passengerInfoComponent.Reset();
		paymentComponent.Reset();
	}
}

// Flight Search Component
public class FlightSearchComponent
{
	private IFlightBookingMediator mediator;

	public FlightSearchComponent(IFlightBookingMediator mediator)
	{
		this.mediator = mediator;
	}

	public void Search(string origin, string destination, DateTime date)
	{
		Console.WriteLine($"Flight search: {origin} to {destination}, Date: {date}");
		mediator.SearchFlights(origin, destination, date);
	}

	public void DisplaySearchResults()
	{
		Console.WriteLine("Displaying flight search results...");
	}

	public void Reset()
	{
		Console.WriteLine("Flight search component reset.");
	}
}

// Passenger Information Component
public class PassengerInfoComponent
{
	private IFlightBookingMediator mediator;

	public PassengerInfoComponent(IFlightBookingMediator mediator)
	{
		this.mediator = mediator;
	}

	public void EnablePassengerInfoForm()
	{
		Console.WriteLine("Passenger information form enabled.");
	}

	public void BookFlight(string passengerName, string flightNumber)
	{
		Console.WriteLine($"Passenger: {passengerName}, Flight: {flightNumber}");
		mediator.BookFlight(passengerName, flightNumber);
	}

	public void Reset()
	{
		Console.WriteLine("Passenger info component reset.");
	}
}

// Payment Component
public class PaymentComponent
{
	private IFlightBookingMediator mediator;

	public PaymentComponent(IFlightBookingMediator mediator)
	{
		this.mediator = mediator;
	}

	public void EnablePaymentForm()
	{
		Console.WriteLine("Payment form enabled.");
	}

	public void ProcessPayment(string passengerName, string flightNumber, decimal amount)
	{
		Console.WriteLine($"Payment for Passenger: {passengerName}, Flight: {flightNumber}, Amount: {amount}");
		mediator.ProcessPayment(passengerName, flightNumber, amount);
	}

	public void Reset()
	{
		Console.WriteLine("Payment component reset.");
	}
}

// Usage
public class Program
{
	public static void Main(string[] args)
	{
		// Create UI components
		var flightSearchComponent = new FlightSearchComponent(null);
		var passengerInfoComponent = new PassengerInfoComponent(null);
		var paymentComponent = new PaymentComponent(null);

		// Create mediator and associate with UI components
		var mediator = new FlightBookingMediator(flightSearchComponent,
												 passengerInfoComponent,
												 paymentComponent);
		flightSearchComponent = new FlightSearchComponent(mediator);
		passengerInfoComponent = new PassengerInfoComponent(mediator);
		paymentComponent = new PaymentComponent(mediator);

		// Simulate user actions
		flightSearchComponent.Search("New York", "London", DateTime.Now);
		// flightSearchComponent.DisplaySearchResults(); this method is invoked from the mediator
		flightSearchComponent.Reset();

		flightSearchComponent.Search("Los Angeles", "Tokyo", DateTime.Now);
		// flightSearchComponent.DisplaySearchResults();
		passengerInfoComponent.BookFlight("John Doe", "12345");
		paymentComponent.ProcessPayment("John Doe", "12345", 1000);
	}
}