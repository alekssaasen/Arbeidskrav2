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
        StartMenu();
    }
    /// <summary>
    /// Displays the initial menu and handles user registration and login
    /// </summary>
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
    /// <summary>
    /// Displays the main menu after login with options for listings, purchases, and reviews
    /// </summary>
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
    /// <summary>
    /// Handles user registration by prompting for username and password
    /// </summary>
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
    /// <summary>
    /// Handles user login by prompting for credentials and validating them
    /// </summary>
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
    /// <summary>
    /// Handles creation of a new listing by prompting for all required details
    /// </summary>
    public void HandleCreateListing()
    {
        string title = "";
        while (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Enter a title: ");
            title = Console.ReadLine();
        }
        
        string description = "";
        while (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Enter a description: ");
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
            if (decimal.TryParse(Console.ReadLine(), out decimal parsedPrice) && parsedPrice > 0)
            {
                price = parsedPrice;
            }
            else
            {
                Console.WriteLine("Invalid price! Must be positive");
            }
        }
        Marketplace.CreateListing(title, description, selectedCategory, selectedCondition, price);
    }
    /// <summary>
    /// Displays all available listings with optional category filter
    /// </summary>
        public void HandleBrowseListings()
    {
        Console.WriteLine("\n1. View all listings");
        Console.WriteLine("2. Filter by category");
        Console.Write("Select option: ");
    
        string filterChoice = Console.ReadLine();
        List<Listing> listings;
    
        if (filterChoice == "2")
        {
            Console.WriteLine("\nSelect Category:");
            Console.WriteLine("1. Electronics");
            Console.WriteLine("2. Clothing & Accessories");
            Console.WriteLine("3. Furniture & Home");
            Console.WriteLine("4. Books & Media");
            Console.WriteLine("5. Sports & Outdoors");
            Console.WriteLine("6. Other");
            Console.Write("Select (1-6): ");
        
            string catChoice = Console.ReadLine();
            Category? selectedCategory = catChoice switch
            {
                "1" => Category.Electronics,
                "2" => Category.ClothingAndAccessories,
                "3" => Category.FurnitureAndHome,
                "4" => Category.BooksAndMedia,
                "5" => Category.SportsAndOutdoors,
                "6" => Category.Other,
                _ => null
            };
        
            if (selectedCategory == null)
            {
                Console.WriteLine("Invalid category!");
                return;
            }
        
            listings = Marketplace.FilterByCategory(selectedCategory.Value);
        }
        else
        {
            listings = Marketplace.GetAllAvailableListings();
        }
        
        if (listings.Count == 0)
        {
            Console.WriteLine("\nNo listings available.");
            return;
        }
        
        Console.WriteLine("\n=== Available Listings ===");
        for (int i = 0; i < listings.Count; i++)
        {
            Listing l = listings[i];
            Console.WriteLine($"{i + 1}. {l.Title} - {l.Price} kr ({l.Category}, {l.Condition})");
        }
        
        Console.Write("\nSelect listing to view (0 to go back): ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= listings.Count)
        {
            ShowListingDetails(listings[choice - 1]);
        }
    }
    /// <summary>
    /// Displays detailed information about a specific listing with purchase option
    /// </summary>
    /// <param name="listing">The listing to display</param>
    public void ShowListingDetails(Listing listing)
    {
        Console.WriteLine($"\n=== {listing.Title} ===");
        Console.WriteLine($"Seller: {listing.Seller.UserName}");
        Console.WriteLine($"Category: {listing.Category}");
        Console.WriteLine($"Condition: {listing.Condition}");
        Console.WriteLine($"Price: {listing.Price} kr");
        Console.WriteLine($"Description: {listing.Description}");
        
        Console.WriteLine("\n1. Buy this item");
        Console.WriteLine("2. Go back");
        Console.Write("Select option: ");
        
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            try
            {
                Marketplace.PurchaseListing(listing);
                Console.WriteLine("\n✓ Purchase complete!");
                
                Console.Write("\nWould you like to leave a review? (Y/N): ");
                if (Console.ReadLine()?.ToUpper() == "Y")
                {
                    HandleLeaveReview(listing);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Handles leaving a review for a purchased item
    /// </summary>
    /// <param name="listing">The listing being reviewed</param>
    public void HandleLeaveReview(Listing listing)
    {
        int rating = 0;
        while (rating < 1 || rating > 6)
        {
            Console.Write("Rating (1-6): ");
            int.TryParse(Console.ReadLine(), out rating);
            if (rating < 1 || rating > 6)
                Console.WriteLine("Rating must be 1-6!");
        }
        
        Console.Write("Comment (or press Enter to skip): ");
        string comment = Console.ReadLine();
        
        // Find the transaction for this purchase
        Transaction transaction = Marketplace.GetCurrentUser().Transactions
            .FirstOrDefault(t => t.Listing == listing);
        
        if (transaction != null)
        {
            try
            {
                Marketplace.LeaveReview(transaction, rating, comment);
                Console.WriteLine("✓ Review submitted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    /// <summary>
    /// Handles searching for listings by keyword
    /// </summary>
    public void HandleSearchListings()
    {
        Console.Write("Enter search keyword: ");
        string keyword = Console.ReadLine();
        
        List<Listing> results = Marketplace.SearchListings(keyword);
        
        if (results.Count == 0)
        {
            Console.WriteLine("\nNo results found.");
            return;
        }
        
        Console.WriteLine($"\n=== Search Results ({results.Count}) ===");
        for (int i = 0; i < results.Count; i++)
        {
            var l = results[i];
            Console.WriteLine($"{i + 1}. {l.Title} - {l.Price} kr");
        }
        
        Console.Write("\nSelect listing to view (0 to go back): ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= results.Count)
        {
            ShowListingDetails(results[choice - 1]);
        }
    }
    /// <summary>
    /// Displays all listings created by the current user
    /// </summary>
    public void HandleMyListings()
    {
        User user = Marketplace.GetCurrentUser();
        if (user == null)
        {
            return;
        }

        if (!user.UserListings.Any())
        {
            Console.WriteLine("\nYou have no listings");
            return;
        }
        
        Console.WriteLine("\n=== My Listings ===");
        user.UserListings.ForEach(listing => 
            Console.WriteLine($"- {listing.Title} ({listing.Status}) - {listing.Price} kr"));
    }
    /// <summary>
    /// Displays all purchases made by the current user
    /// </summary>
    public void HandleMyPurchases()
    {
        User user = Marketplace.GetCurrentUser();
        if (user == null)
        {
            return;
        }
        
        if (!user.Transactions.Any())
        {
            Console.WriteLine("You have no purchases.");
            return;
        }
        
        Console.WriteLine("\n=== My Purchases ===");
        user.Transactions.ForEach(transaction => 
            Console.WriteLine($"- {transaction.Listing.Title} from {transaction.Seller.UserName} - {transaction.Listing.Price} kr"));
    }
    /// <summary>
    /// Displays all reviews received by the current user with average rating
    /// </summary>
    public void HandleMyReviews()
    {
        User user = Marketplace.GetCurrentUser();
        if (user == null)
        {
            return;
        }

        if (!user.Reviews.Any())
        {
            Console.WriteLine("You have no reviews yet.");
            return;
        }

        double avgRating = user.GetAvgRating();
        Console.WriteLine($"\n=== My Reviews (Average: {avgRating:F1}/6) ===");
        user.Reviews.ForEach(review =>
        {
            Console.WriteLine($"- Rating: {review.DiceRating}/6");
            if (!string.IsNullOrEmpty(review.Comment))
                Console.WriteLine($"  \"{review.Comment}\"");
        });
    }
}