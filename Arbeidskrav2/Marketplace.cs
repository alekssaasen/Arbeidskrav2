using Arbeidskrav2.Enums;

namespace Arbeidskrav2;

public class Marketplace
{
    private List<User> _users;
    private List<Listing> _allListings;
    private List<Transaction> _allTransactions;
    private User? _currentUser;
    public User? GetCurrentUser() => _currentUser;

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

    public void PurchaseListing(Listing listing)
    {
        if (listing.Status != ListingStatus.Available)
        {
            throw new Exception("This Listing is already sold.");
        }
        if (_currentUser == listing.Seller)
        {
            throw new Exception("You can't purchase your own listing.");
        }
        
        Transaction transaction = new Transaction(_currentUser, listing.Seller, listing);
        
        listing.MarkAsSold(_currentUser);
        _allTransactions.Add(transaction);
        _currentUser.Transactions.Add(transaction);
        listing.Seller.Transactions.Add(transaction);
    }

    public void LeaveReview(Transaction transaction, int rating, string comment)
    {
        if (!_currentUser.Transactions.Contains(transaction))
        {
            throw new Exception("You need to purchase something before you can give a review.");
        }
        if (_currentUser != transaction.Buyer)
        {
            throw new Exception("You can't review your own transaction.");
        }
        if (rating < 1 || rating > 6)
        {
            throw new Exception("Give a rating between 1-6.");
        }
        Review review = new Review(_currentUser, transaction.Seller, transaction, rating, comment);
        
        transaction.Seller.Reviews.Add(review);
    }
}