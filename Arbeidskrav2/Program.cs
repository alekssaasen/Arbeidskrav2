using Arbeidskrav2.Enums;

namespace Arbeidskrav2;

class Program
{
    static void Main(string[] args)
    {
        Marketplace M = new Marketplace();

        Console.WriteLine("MarketPlace test");
        M.Register("Alek", "123");
        bool success = M.Login("Alek", "123");
        Console.WriteLine($"Login Alek: {success}");
        M.CreateListing("Sofa", "Good to sit in!", Category.FurnitureAndHome, Condition.LikeNew, 5000.00m);
        M.CreateListing("Bed", "Good to sit in!", Category.FurnitureAndHome, Condition.LikeNew, 5000.00m);

        Console.WriteLine("Created Listing");
        var available = M.GetAllAvailableListings();
        Console.WriteLine($"Available listings: {available.Count}");
        
        var foundListing = M.SearchListings("good");
        Console.WriteLine($"Found listing! {foundListing.Count}");
        

    }
}