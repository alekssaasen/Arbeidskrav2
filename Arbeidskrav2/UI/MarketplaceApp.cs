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
                    ShowMainMenu();
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

    public void ShowMainMenu()
    {
        bool running = true;
        do
        {
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine($"1. Create Listing");
            Console.WriteLine($"2. Browse Listings");
            Console.WriteLine($"3. Search Listings");
            Console.WriteLine($"4. My Listings");
            Console.WriteLine($"5. My Purchases");
            Console.WriteLine($"6. My Reviews");
            Console.WriteLine("7. Log Out ");
            
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    HandleCreateListing();
                    break;
                case "2": 
                    HandleBrowseListings();
                    break;
                case "3":
                    HandleSearchListings();
                    running = false;
                    break;
                case "4":
                    HandleMyListings();
                    break;
                case "5": 
                    HandleMyPurchases();
                    break;
                case "6":
                    HandleMyReviews();
                    running = false;
                    break;
                case "7":
                    Marketplace.Logout();
                    break;
                default:
                    Console.WriteLine("enter a valid option: ");
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
    public void HandleCreateListing()
    {
            
    }
    
    public void HandleBrowseListings()
    {
        
    }
    public void HandleSearchListings()
    {
        
    }
    public void HandleMyListings()
    {
        
    }
    public void HandleMyPurchases()
    {
        
    }
    public void HandleMyReviews()
    {
        
    }
}