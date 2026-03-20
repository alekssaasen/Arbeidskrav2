using Arbeidskrav2.Enums;

namespace Arbeidskrav2;

public class Listing
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Category Category { get; private set; }
    public Condition Condition { get; private set; }
    public ListingStatus Status { get; private set; }
    public decimal Price { get; private set; }
    public DateTime Date { get; private set; }
    public User? Buyer { get; private set; }
    public User Seller { get; private set; }
/// <summary>
/// Creates a listing with a title, description, category, conditon, price and the user who created it.
/// </summary>
/// <param name="title">The listing title</param>
/// <param name="description">The description for the listing</param>
/// <param name="category">The category for the listing</param>
/// <param name="condition">the condition for the listing</param>
/// <param name="price">The price for the listing</param>
/// <param name="seller">The user who created the listing</param>
    public Listing(string title, string description, Category category, Condition condition, decimal price, User seller)
    {
        Title = title;
        Description = description;
        Category = category;
        Condition = condition;
        Status = ListingStatus.Available;
        Price = price;
        Seller = seller;
        Date = DateTime.Now;
    }
/// <summary>
/// Changes the listing status to sold when bought and sets buyer to the user who bought the listing
/// </summary>
/// <param name="buyer">the user who bought the listing</param>
    public void MarkAsSold(User buyer)
    {
        Buyer = buyer;
        Status = ListingStatus.Sold;
    }
}