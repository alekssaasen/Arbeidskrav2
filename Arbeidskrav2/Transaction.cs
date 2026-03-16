namespace Arbeidskrav2;

public class Transaction
{
    public User Buyer { get; }
    public User Seller { get; }
    public Listing Listing { get; }
    public DateTime Date { get; }
    public Transaction(User buyer, User seller, Listing listing)
    {
        Buyer = buyer;
        Seller = seller;
        Listing= listing;
        Date = DateTime.Now;
    }
}