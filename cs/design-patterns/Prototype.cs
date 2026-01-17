using Microsoft.Win32;
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

// Prototype interface
public interface IComponent
{
	void Render();
	IComponent Clone();
}

// Concrete prototype - Button
public class Button : IComponent
{
	public string Text { get; set; }

	public Button(string text)
	{
		Text = text;
	}

	public void Render()
	{
		Console.WriteLine("Rendering a button with text: " + Text);
	}

	public IComponent Clone()
	{
		return new Button(Text);
	}
}

// Concrete prototype - TextBox
public class TextBox : IComponent
{
	public string Placeholder { get; set; }

	public TextBox(string placeholder)
	{
		Placeholder = placeholder;
	}

	public void Render()
	{
		Console.WriteLine("Rendering a textbox with placeholder: " + Placeholder);
	}

	public IComponent Clone()
	{
		return new TextBox(Placeholder);
	}
}

// Component registry
public static class ComponentRegistry
{
	private static Dictionary<string, IComponent> components = new Dictionary<string, IComponent>();

	public static void RegisterComponent(string key, IComponent component)
	{
		components.Add(key, component);
	}

	public static IComponent GetComponent(string key)
	{
		if (components.ContainsKey(key))
		{
			return components[key].Clone();
		}
		return null;
	}
}

public class Program
{
	public static void Main(string[] args)
	{
		// Register prototype components
		ComponentRegistry.RegisterComponent("Button", new Button("Click me"));
		ComponentRegistry.RegisterComponent("TextBox", new TextBox("Enter text"));

		// Get cloned instances from the registry
		IComponent clonedButton = ComponentRegistry.GetComponent("Button");
		IComponent clonedTextBox = ComponentRegistry.GetComponent("TextBox");

		// Render the cloned components
		clonedButton?.Render();
		clonedTextBox?.Render();
		Console.ReadKey();
	}
}