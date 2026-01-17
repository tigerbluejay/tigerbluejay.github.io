using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Xml.Linq;

// Component interface
interface IFileSystemComponent
{
	void PrintDetails();
}

// Leaf class representing a file
class File : IFileSystemComponent
{
	private string name;

	public File(string name)
	{
		this.name = name;
	}

	public void PrintDetails()
	{
		Console.WriteLine($"File: {name}");
	}
}

// Composite class representing a directory
class Directory : IFileSystemComponent
{
	private string name;
	private List<IFileSystemComponent> components = new List<IFileSystemComponent>();

	public Directory(string name)
	{
		this.name = name;
	}

	public void AddComponent(IFileSystemComponent component)
	{
		components.Add(component);
	}

	public void RemoveComponent(IFileSystemComponent component)
	{
		components.Remove(component);
	}

	public void PrintDetails()
	{
		Console.WriteLine($"Directory: {name}");
		foreach (IFileSystemComponent component in components)
		{
			component.PrintDetails();
		}
	}
}

class Program
{
	static void Main(string[] args)
	{
		// Creating file objects
		File file1 = new File("file1.txt");
		File file2 = new File("file2.txt");
		File file3 = new File("file3.txt");

		// Creating directory objects
		Directory rootDirectory = new Directory("Root");
		Directory subDirectory1 = new Directory("Subdirectory 1");
		Directory subDirectory2 = new Directory("Subdirectory 2");

		// Adding files to the root directory
		rootDirectory.AddComponent(file1);

		// Adding files to subdirectory 1
		subDirectory1.AddComponent(file2);
		subDirectory1.AddComponent(file3);

		// Adding subdirectories to the root directory
		rootDirectory.AddComponent(subDirectory1);
		rootDirectory.AddComponent(subDirectory2);

		// Printing the file system structure
		rootDirectory.PrintDetails();

		Console.ReadKey();
	}
}