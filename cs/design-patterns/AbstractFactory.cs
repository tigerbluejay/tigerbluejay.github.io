using System;

// Abstract Product: Database Connection
public interface IDatabaseConnection
{
	void Connect();
}

// Concrete Products: SQL Server, Oracle, and MySQL Connections
public class SqlConnection : IDatabaseConnection
{
	public void Connect()
	{
		Console.WriteLine("Connected to SQL Server database.");
	}
}

public class OracleConnection : IDatabaseConnection
{
	public void Connect()
	{
		Console.WriteLine("Connected to Oracle database.");
	}
}

public class MySqlConnection : IDatabaseConnection
{
	public void Connect()
	{
		Console.WriteLine("Connected to MySQL database.");
	}
}

// Abstract Factory: Database Factory
public interface IDatabaseFactory
{
	IDatabaseConnection CreateConnection();
}

// Concrete Factories: SQL Server, Oracle, and MySQL Factories
public class SqlDatabaseFactory : IDatabaseFactory
{
	public IDatabaseConnection CreateConnection()
	{
		return new SqlConnection();
	}
}

public class OracleDatabaseFactory : IDatabaseFactory
{
	public IDatabaseConnection CreateConnection()
	{
		return new OracleConnection();
	}
}

public class MySqlDatabaseFactory : IDatabaseFactory
{
	public IDatabaseConnection CreateConnection()
	{
		return new MySqlConnection();
	}
}

// Data Access Layer
public class DataAccessLayer
{
	private IDatabaseConnection connection;

	public DataAccessLayer(IDatabaseFactory factory)
	{
		connection = factory.CreateConnection();
	}

	public void ConnectToDatabase()
	{
		connection.Connect();
	}
}

// Usage
public class Program
{
	public static void Main()
	{
		// Create a SQL Server data access layer
		IDatabaseFactory sqlFactory = new SqlDatabaseFactory();
		DataAccessLayer sqlDataAccessLayer = new DataAccessLayer(sqlFactory);
		sqlDataAccessLayer.ConnectToDatabase();

		// Create an Oracle data access layer
		IDatabaseFactory oracleFactory = new OracleDatabaseFactory();
		DataAccessLayer oracleDataAccessLayer = new DataAccessLayer(oracleFactory);
		oracleDataAccessLayer.ConnectToDatabase();

		// Create a MySQL data access layer
		IDatabaseFactory mysqlFactory = new MySqlDatabaseFactory();
		DataAccessLayer mysqlDataAccessLayer = new DataAccessLayer(mysqlFactory);
		mysqlDataAccessLayer.ConnectToDatabase();
	}
}