using Arbeidskrav2.Enums;

namespace Arbeidskrav2;

public class Marketplace
{
    // business logic
    /* Collection of:
     Users,
     Listings,
     Transactions,
    */
    // User currently logged in
    private List<User> _users;
    private List<Listing> _allListings;
    private List<Transaction> _allTransactions;
    private User? _currentUser;

    public Marketplace()
    {
        _users = new List<User>();
        _allListings = new List<Listing>();
        _allTransactions = new List<Transaction>();
        _currentUser = null;
    }

    public void Register(string userName, string password)
    {
        User user = new User(userName, password);
        _users.Add(user);
    }

    public bool Login(string userName, string password)
    {
        IEnumerable<User> result = _users
            .Where(user => user.UserName == userName && user.VerifyPassword(password));
        bool foundUser = result.Any();
        if (foundUser)
        {
            _currentUser = result.First();
            return true;
        }
        return false;
    }
    
    public void Logout()
    {
        _currentUser = null;
    }

    public void CreateListing(string title, string description, Category category, Condition condition, decimal price)
    {
        Listing listing = new Listing(title, description, category, condition, price, _currentUser);
        _allListings.Add(listing);
        _currentUser.UserListings.Add(listing);
    }
    
    public List<Listing> GetAllAvailableListings()
    {
        IEnumerable<Listing> result = _allListings
            .Where(s => s.Status != ListingStatus.Sold);
        return result.ToList();
    }

    public List<Listing> SearchListings(string keyword)
    {
        IEnumerable<Listing> result = _allListings
            .Where(l => l.Title.ToLower().Contains(keyword.ToLower()) || l.Description.ToLower().Contains(keyword.ToLower()));
        return result.ToList();
    }
}