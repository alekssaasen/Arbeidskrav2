namespace Arbeidskrav2;

public class Review
{
    public User Reviewer { get; }
    public User Seller { get; }
    public Transaction Transaction { get; }
    public int DiceRating { get; }
    // Comment is optional
    public string? Comment { get; }
    public DateTime Date { get; }

    public Review(User reviewer, User seller, Transaction transaction, int diceRating, string? comment)
    {
        Reviewer = reviewer;
        Seller = seller;
        Transaction = transaction;
        if (diceRating < 1 || diceRating > 6)
        {
            throw new ArgumentException("Your given rating isn't between 1-6. Try again.");
        }
        DiceRating = diceRating;
        Comment = comment;
        Date = DateTime.Now;
    }
}