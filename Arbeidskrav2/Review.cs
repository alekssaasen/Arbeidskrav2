namespace Arbeidskrav2;

public class Review
{
    /// <summary>
    /// Storage for what a review needs
    /// </summary>
    public User Reviewer { get; }
    public User Seller { get; }
    public Transaction Transaction { get; }
    public int DiceRating { get; }
    // Comment is optional
    public string? Comment { get; }
    public DateTime Date { get; }
    /// <summary>
    /// Creates a review for a transaction with a rating from 1-6 and optional comment
    /// </summary>
    /// <param name="reviewer">The user leaving a review</param>
    /// <param name="seller">The user being reviewed</param>
    /// <param name="transaction">The transaction receiving a review</param>
    /// <param name="diceRating">rating 1-6</param>
    /// <param name="comment">optional comment</param>
    /// <exception cref="ArgumentException">Thrown when rating is not between 1-6</exception>
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