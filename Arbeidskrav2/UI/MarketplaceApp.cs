namespace Arbeidskrav2.UI;

public class MarketplaceApp
{
    private Marketplace Marketplace;
    private string? userInput;

    public MarketplaceApp(Marketplace marketplace)
    {
        Marketplace = marketplace;
    }
    
    public void Run()
    {
        
    }

    public void StartMenu()
    {
        bool running = true;
        do
        {
            Console.WriteLine("=== Marketplace ===");
            Console.WriteLine($"1. Register");
            Console.WriteLine($"2. Log In");
            Console.WriteLine($"3. Exit");
            Console.WriteLine("Select an option: ");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    HandleRegister();
                    break;
                case "2": 
                    HandleLogin();
                    break;
                case "3":
                    Console.WriteLine("You chose exit");
                    running = false;
                    break;
                default:
                    Console.WriteLine("enter a valid number: ");
                    continue;
            }
        } while (running);
    }

    public void HandleRegister()
    {
        string username = "";
        while (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Please enter a username: \n");
            username = Console.ReadLine();
        }
        
        string password = "";
        while (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Please enter a password: \n");
            password = Console.ReadLine();
        }
        
        Marketplace.Register(username, password);
        Console.WriteLine("Registration successful.");
    }
    public void HandleLogin()
    {
        
        string username = "";
        while (string.IsNullOrWhiteSpace(username))
        {
            Console.Write("Enter your username: ");
            username = Console.ReadLine();
        }
        
        string password = "";
        while (string.IsNullOrWhiteSpace(password))
        {
            Console.Write("Enter your password: ");
            password = Console.ReadLine();
        }

        bool success = Marketplace.Login(username, password);
        
        if(!success)
        {
            Console.WriteLine("Username or password was wrong: try again");
        }
        else
        {
            Console.WriteLine("Login successful.");
        }
    }
}