using System;

// Subject interface
public interface IInternet
{
	void ConnectTo(string serverHost);
}

// RealSubject class
public class RealInternet : IInternet
{
	public void ConnectTo(string serverHost)
	{
		Console.WriteLine("Connecting to " + serverHost);
	}
}

// Proxy class
public class InternetProxy : IInternet
{
	private IInternet _realInternet;
	private string _restrictedSite;

	public InternetProxy(string restrictedSite)
	{
		_restrictedSite = restrictedSite;
	}

	public void ConnectTo(string serverHost)
	{
		if (_restrictedSite == serverHost)
		{
			Console.WriteLine("Access to " + serverHost + " is denied.");
		}
		else
		{
			if (_realInternet == null)
			{
				_realInternet = new RealInternet();
			}
			_realInternet.ConnectTo(serverHost);
		}
	}
}

// Client code
public class Client
{
	static void Main(string[] args)
	{
		// Create an internet proxy
		IInternet internet = new InternetProxy("facebook.com");

		// Access a restricted site
		internet.ConnectTo("facebook.com");

		// Access a non-restricted site
		internet.ConnectTo("google.com");
	}
}