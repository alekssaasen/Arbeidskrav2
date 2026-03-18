using Arbeidskrav2.Enums;

namespace Arbeidskrav2;

class Program
{
    static void Main(string[] args)
    {
        Marketplace M = new Marketplace();

        Console.WriteLine("MarketPlace test");
        M.Register("Alek", "123");
        M.Login("Alek", "123");
        M.CreateListing("Sofa", "Nice sofa!", Category.FurnitureAndHome, Condition.LikeNew, 5000.00m);
        M.Logout();

        M.Register("Zoe", "123");
        M.Login("Zoe", "123");
        M.CreateListing("Bed", "Good to sit in!", Category.FurnitureAndHome, Condition.LikeNew, 5000.00m);
        Console.WriteLine("Created Listing");
        
        var listings = M.GetAllAvailableListings();
        var firstListing = listings[0];
        
        var foundListing = M.SearchListings("Sofa");
        Console.WriteLine($"Found listing! {foundListing.Count}");
        M.PurchaseListing(firstListing);
        Console.WriteLine("Purchase complete");
        
        // Made _users public for testing
        /*
        var userOne = M._users[0];
        var firstPurchase = userOne.Transactions[0];
        M.LeaveReview(firstPurchase,6, "Nice woman!");
        Console.WriteLine($"Seller has {firstPurchase.Seller.Reviews.Count} reviews");
         */
        
        

    }
}