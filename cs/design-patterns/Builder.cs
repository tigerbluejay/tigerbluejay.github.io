// The Product class represents an HTML document.
public class HTMLDocument
{
	public string Title { get; set; }
	public string Body { get; set; }
	public List<string> Elements { get; set; }

	public HTMLDocument() { 
	
		Elements = new List<string>();
	}

	public void Display()
	{
		Console.WriteLine($"Title: {Title}");
		Console.WriteLine($"Body: {Body}");
		Console.WriteLine("Elements:");
		foreach (var element in Elements)
		{
			Console.WriteLine($"- {element}");
		}
	}
}

// The Builder interface defines the steps required to build an HTML document.
public interface IHTMLBuilder
{
	void SetTitle(string title);
	void SetBody(string body);
	void AddElement(string element);
	HTMLDocument GetResult();
}

// The ConcreteBuilder class implements the Builder interface and provides the specific implementation for building an HTML document.
public class HTMLBuilder : IHTMLBuilder
{
	private HTMLDocument document = new HTMLDocument();

	public void SetTitle(string title)
	{
		document.Title = title;
	}

	public void SetBody(string body)
	{
		document.Body = body;
	}

	public void AddElement(string element)
	{
		document.Elements.Add(element);
	}

	public HTMLDocument GetResult()
	{
		return document;
	}
}

// The Director class controls the construction process by using the Builder interface.
public class HTMLDocumentDirector
{
	private IHTMLBuilder builder;

	public HTMLDocumentDirector(IHTMLBuilder builder)
	{
		this.builder = builder;
	}

	public void Construct()
	{
		builder.SetTitle("Sample HTML Document");
		builder.SetBody("This is the body of the document.");
		builder.AddElement("<p>This is a paragraph.</p>");
		builder.AddElement("<h1>This is a heading.</h1>");
		builder.AddElement("<ul><li>Item 1</li><li>Item 2</li><li>Item 3</li></ul>");
	}
}

// Example usage
class Program
{
	static void Main(string[] args)
	{
		// Create a builder instance
		IHTMLBuilder builder = new HTMLBuilder();

		// Create a director instance and set the builder
		HTMLDocumentDirector director = new HTMLDocumentDirector(builder);

		// Construct the HTML document using the director
		director.Construct();

		// Get the final HTML document from the builder
		HTMLDocument document = builder.GetResult();

		// Display the HTML document
		document.Display();
	}
}