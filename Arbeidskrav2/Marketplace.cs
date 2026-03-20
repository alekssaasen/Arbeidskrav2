using Arbeidskrav2.Enums;

namespace Arbeidskrav2;

public class Marketplace
{
    private List<User> _users;
    private List<Listing> _allListings;
    private List<Transaction> _allTransactions;
    private User? _currentUser;
    public User? GetCurrentUser() => _currentUser;
    /// <summary>
    /// Creates a list of users, listings, transactions and sets the currentUser to null. 
    /// </summary>
    public Marketplace()
    {
        _users = new List<User>();
        _allListings = new List<Listing>();
        _allTransactions = new List<Transaction>();
        _currentUser = null;
    }
    /// <summary>
    /// Method to handle registration. Adds a new user to the _user list 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    public void Register(string userName, string password)
    {
        User user = new User(userName, password);
        _users.Add(user);
    }
    /// <summary>
    /// Method to handle login. Using LINQ, it iterates through all users and stores that user to a bool. 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <returns>A user if a user is found with matching username and password</returns>
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
    /// <summary>
    /// Sets the logged in user to null
    /// </summary>
    public void Logout()
    {
        _currentUser = null;
    }
    /// <summary>
    /// Method to create listing and adds them to the list of all listings and the users listings.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <param name="category"></param>
    /// <param name="condition"></param>
    /// <param name="price"></param>
    public void CreateListing(string title, string description, Category category, Condition condition, decimal price)
    {
        Listing listing = new Listing(title, description, category, condition, price, _currentUser);
        _allListings.Add(listing);
        _currentUser.UserListings.Add(listing);
    }
    /// <summary>
    /// Method to get all listings that are available.
    /// </summary>
    /// <returns>a list of all available listings if the status is available.</returns>
    public List<Listing> GetAllAvailableListings()
    {
        IEnumerable<Listing> result = _allListings
            .Where(s => s.Status != ListingStatus.Sold);
        return result.ToList();
    }
    /// <summary>
    /// Iterates through all listings and finds listing(s) based on a keyword
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns>returns results if the keyword matches the title or description </returns>
    public List<Listing> SearchListings(string keyword)
    {
        IEnumerable<Listing> result = _allListings
            .Where(l => l.Title.ToLower().Contains(keyword.ToLower()) || l.Description.ToLower().Contains(keyword.ToLower()));
        return result.ToList();
    }
    /// <summary>
    /// A method to filter listing based on a category
    /// </summary>
    /// <param name="category"></param>
    /// <returns>returns a listing if it contains a mathcing category and if that listing is available</returns>
    public List<Listing> FilterByCategory(Category category)
    {
        return _allListings.Where(l => l.Category == category && l.Status == ListingStatus.Available).ToList();
    }
    /// <summary>
    /// Checks if a listing is available and if the user happens to be the seller. If not add a new transaction to _currentUser and the other party
    /// </summary>
    /// <param name="listing"></param>
    /// <exception cref="Exception">Throws if the user trying to buy is the seller and if the listing is available.</exception>
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
    /// <summary>
    /// Method to handle reviews, adds a review to the seller with the other party involved, listing details, rating and comment (if any)
    /// </summary>
    /// <param name="transaction"></param>
    /// <param name="rating"></param>
    /// <param name="comment"></param>
    /// <exception cref="Exception">Throws if user hasnt bought, if user tries to review own transaction and if rating is out of range</exception>
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