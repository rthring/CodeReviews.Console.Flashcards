using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Flashcards.rthring
{
    public class DatabaseController
    {
        private string? _connectionString;
        public DatabaseController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            var tableCreationScripts = new[]
            {
                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='stack' and xtype='U')
	                    CREATE TABLE stack (
		                    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
		                    Name varchar(64)
	                    )",
                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='card' and xtype='U')
	                    CREATE TABLE card (
		                    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
		                    Front varchar(255),
		                    Back varchar(255),
		                    StackId int FOREIGN KEY REFERENCES stack(Id)
	                    )",
                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='study_session' and xtype='U')
	                    CREATE TABLE study_session (
		                    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
		                    Correct int,
		                    Total int,
		                    DateCompleted Date,
		                    StackId int FOREIGN KEY REFERENCES stack(Id)
	                    )"
            };
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    foreach (var script in tableCreationScripts)
                    {
                        using (var command = new SqlCommand(script, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database initialization failed: {ex.Message}");
            }
        }
    }
}