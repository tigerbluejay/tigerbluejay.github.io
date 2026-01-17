using System;
using System.Collections.Generic;

// The Command interface declares the Execute() method.
interface ICommand
{
	void Execute();
	void Undo();
}

// Concrete command classes implementing the ICommand interface.

class TypeCommand : ICommand
{
	private readonly string _text;

	public TypeCommand(string text)
	{
		_text = text;
	}

	public void Execute()
	{
		Console.WriteLine("Typing: " + _text);
	}

	public void Undo()
	{
		Console.WriteLine("Deleting: " + _text);
	}
}

class DeleteCommand : ICommand
{
	private readonly string _text;

	public DeleteCommand(string text)
	{
		_text = text;
	}

	public void Execute()
	{
		Console.WriteLine("Deleting: " + _text);
	}

	public void Undo()
	{
		Console.WriteLine("Typing: " + _text);
	}
}

// The Invoker class maintains a history of executed commands and executes them upon request.

class TextEditor
{
	private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();

	public void ExecuteCommand(ICommand command)
	{
		command.Execute();
		_commandHistory.Push(command);
	}

	public void UndoCommand()
	{
		if (_commandHistory.Count > 0)
		{
			var command = _commandHistory.Pop();
			command.Undo();
		}
		else
		{
			Console.WriteLine("No more commands to undo.");
		}
	}
}

// Client code

class Program
{
	static void Main(string[] args)
	{
		var editor = new TextEditor();

		// Typing commands
		var typeCommand1 = new TypeCommand("Hello");
		var typeCommand2 = new TypeCommand(", world!");

		// Deleting command
		var deleteCommand = new DeleteCommand(" world!");

		// Executing commands
		editor.ExecuteCommand(typeCommand1);
		editor.ExecuteCommand(typeCommand2);
		editor.ExecuteCommand(deleteCommand);

		// Undoing commands
		editor.UndoCommand();
		editor.UndoCommand();
		editor.UndoCommand();
	}
}