using NLog;
string path = Directory.GetCurrentDirectory() + "//nlog.config";

var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();

Console.WriteLine("Enter 1 Browse Movies.");
Console.WriteLine("Enter 2 Add Movie.");
Console.WriteLine("Enter Anything Else to Quit.");

string? resp = Console.ReadLine();

Random random = new Random();
int movieID = random.Next(100000, 1000000); // Wasnt sure about the movieID increments because the movieID data provided isnt consistent 


try
{
    if (resp == "1")
    {
        if (File.Exists("movies.csv"))
        {
            string[] lines = File.ReadAllLines("movies.csv");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("Movie File Not Found.");
            logger.Error("Movie File Not Found.");
        }
    }
    else if (resp == "2")
    {
        movieID = random.Next(100000, 1000000);
        Console.WriteLine("Enter Title:");
        string title = Console.ReadLine();
        Console.WriteLine("Enter the Year:");
        string year = " (" + Console.ReadLine() + ")";
        Console.WriteLine("Enter Genres:");
        string genre = Console.ReadLine();

        genre = genre.Replace(", ", "|").Replace(",", "|"); // https://learn.microsoft.com/en-us/dotnet/api/system.string.replace?view=net-8.0

        string newMovie = $"{movieID},{title}{year},{genre}\n";

        File.AppendAllText("movies.csv", newMovie); // https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendalltext?view=net-8.0
        Console.WriteLine("We added your movie!");
    }
}
catch (Exception e)
{
    logger.Error(e, "Error Found");
    Console.WriteLine("Please Try Again.");
}