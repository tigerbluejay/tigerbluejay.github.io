using System;
using System.IO;

// Abstraction
abstract class Document
{
	protected IFormatter formatter;

	public Document(IFormatter formatter)
	{
		this.formatter = formatter;
	}

	public abstract void Print();
}

// Refined Abstraction
class Resume : Document
{
	public Resume(IFormatter formatter) : base(formatter)
	{
	}

	public override void Print()
	{
		string formattedContent = formatter.Format("John Doe", "Software Engineer");
		Console.WriteLine($"Printing Resume:\n{formattedContent}");
	}
}

// Implementor
interface IFormatter
{
	string Format(string name, string title);
}

// Concrete Implementor
class PlainTextFormatter : IFormatter
{
	public string Format(string name, string title)
	{
		return $"Name: {name}\nTitle: {title}";
	}
}

// Concrete Implementor
class HtmlFormatter : IFormatter
{
	public string Format(string name, string title)
	{
		return $"<h1>{name}</h1><p>{title}</p>";
	}
}

// Client
class Program
{
	static void Main(string[] args)
	{
		Document resume = new Resume(new PlainTextFormatter());
		resume.Print();

		Console.WriteLine();

		Document resumeHtml = new Resume(new HtmlFormatter());
		resumeHtml.Print();
	}
}