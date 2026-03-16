using Arbeidskrav2.Enums;

namespace Arbeidskrav2;

public class Listing
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Categories Category { get; private set; }
    public Conditions Condition { get; private set; }
    public ListingStatus Status { get; private set; }
    public decimal Price { get; private set; }
    public DateTime Date { get; private set; }
    public User? Buyer { get; private set; }
    public User Seller { get; private set; }

    public Listing(string title, string description, Categories category, Conditions condition, decimal price, DateTime date)
    {
        Title = title;
        Description = description;
        Category = category;
        Condition = condition;
        Status = ListingStatus.Available;
        Price = price;
        Date = date;
    }

    public void isSold()
    {
        throw new Exception("");
    }



}