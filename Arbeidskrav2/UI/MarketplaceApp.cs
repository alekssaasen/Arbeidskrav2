using System.Globalization;
using Arbeidskrav2.Enums;

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
                    break;
                case "4":
                    HandleMyListings();
                    break;
                case "5": 
                    HandleMyPurchases();
                    break;
                case "6":
                    HandleMyReviews();
                    break;
                case "7":
                    Marketplace.Logout();
                    running = false;
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
            ShowMainMenu();
        }
    }
    public void HandleCreateListing()
    {
        string title = "";
        while (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Enter listing title: ");
            title = Console.ReadLine();
        }
        
        string description = "";
        while (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Enter listing title: ");
            description = Console.ReadLine();
        }
        
        Console.WriteLine("\nSelect Category:");
        Console.WriteLine("1. Electronics");
        Console.WriteLine("2. Clothing & Accessories");
        Console.WriteLine("3. Furniture & Home");
        Console.WriteLine("4. Books & Media");
        Console.WriteLine("5. Sports & Outdoors");
        Console.WriteLine("6. Other");
        
        
        Category selectedCategory = Category.Other;
        bool validCategory = false;
        while (!validCategory)
        {
            Console.Write("Select (1-6): ");        
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    selectedCategory = Category.Electronics;
                    validCategory = true;
                    break;
                case "2":
                    selectedCategory = Category.ClothingAndAccessories;
                    validCategory = true;
                    break;
                case "3":
                    selectedCategory = Category.FurnitureAndHome;
                    validCategory = true;
                    break;
                case "4":
                    validCategory = true;
                    selectedCategory = Category.BooksAndMedia;
                    break;
                case "5":
                    selectedCategory = Category.SportsAndOutdoors;
                    validCategory = true;
                    break;
                case "6":
                    selectedCategory = Category.Other;
                    validCategory = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
        
        Console.WriteLine("\nSelect Condition:");
        Console.WriteLine("1. New");
        Console.WriteLine("2. Like New");
        Console.WriteLine("3. Good");
        Console.WriteLine("4. Fair");

        Condition selectedCondition = Condition.New;
        bool validCondition = false;
        while (!validCondition)
        {
            Console.Write("Select (1-4): ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": 
                    selectedCondition = Condition.New; 
                    validCondition = true; 
                    break;
                case "2": 
                    selectedCondition = Condition.LikeNew; 
                    validCondition = true; 
                    break;
                case "3": 
                    selectedCondition = Condition.Good; 
                    validCondition = true; 
                    break;
                case "4": 
                    selectedCondition = Condition.Fair; 
                    validCondition = true; 
                    break;
                default: 
                    Console.WriteLine("Invalid choice!"); 
                    break;
            }
        }
        
        decimal price = 0;
        while (price <= 0)
        {
            Console.WriteLine("Enter price (kr): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal parsedPrice))
            {
                price = parsedPrice;
                if (price <= 0)
                {
                    Console.WriteLine("Price must be greater than 0!");
                }
                else
                {
                    Console.WriteLine("Invalid price!");
                }
            }
        }
        Marketplace.CreateListing(title, description, selectedCategory, selectedCondition, price);
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