namespace Arbeidskrav2;

public class User
{
   public string UserName { get; private set; }
   private string Password { get; set; }
   public List<Listing> UserListings { get; private set; } 
   public List<Review> Reviews { get; private set; }
   public List<Transaction> Transactions { get; private set; }
   /// <summary>
   /// Constructor that allows instantiation of username, password.
   /// Instantiates UserListings, reviews, and transaction in order to have an empty list we can add to.
   /// </summary>
   /// <param name="userName"></param>
   /// <param name="password"></param>
   public User(string userName, string password)
   {
      UserName = userName;
      Password = password;
      UserListings = new List<Listing>();
      Reviews = new List<Review>();
      Transactions = new List<Transaction>();
   }
   /// <summary>
   /// Calculates average rating of a user
   /// </summary>
   /// <returns>The average review score of a user</returns>
   public double GetAvgRating()
   {
      IEnumerable<int> result = Reviews
         .Select(r => r.DiceRating);

      return result.Average();
   }
   /// <summary>
   /// Checks if password is equal to registered password.
   /// </summary>
   /// <param name="password"></param>
   /// <returns>Sets the password</returns>
   public bool VerifyPassword(string password)
   {
      if (Password == password)
      {
         return true;
      }
      return false;
   }
}