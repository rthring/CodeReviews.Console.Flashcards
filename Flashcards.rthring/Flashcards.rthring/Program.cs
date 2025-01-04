using Microsoft.Extensions.Configuration;

namespace Flashcards.rthring
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) // Base path to look for appsettings.json
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) // Load JSON file
                .AddEnvironmentVariables() // Load environment variables
                .Build();
            var database = new DatabaseController(configuration);
            UserHandler handler = new UserHandler(database);
            Boolean closeApp = false;
            while (!closeApp)
            {
                closeApp = handler.GetUserInput();
            }
        }
    }
}