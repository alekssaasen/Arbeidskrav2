namespace Arbeidskrav2;

public class Transaction
{
    public User Buyer { get; }
    public User Seller { get; }
    public Listing Listing { get; }
    public DateTime Date { get; }
    /// <summary>
    /// Creates a transaction between a buyer and a seller, and the listing being bought
    /// </summary>
    /// <param name="buyer">the user whos buying</param>
    /// <param name="seller">the user who is selling</param>
    /// <param name="listing">The listing being purchased</param>
    public Transaction(User buyer, User seller, Listing listing)
    {
        Buyer = buyer;
        Seller = seller;
        Listing= listing;
        Date = DateTime.Now;
    }
}