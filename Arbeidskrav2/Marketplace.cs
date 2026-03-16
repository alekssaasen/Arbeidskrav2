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
        throw new Exception("");
    }
}