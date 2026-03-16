namespace Arbeidskrav2;

public class User
{
   public string UserName { get; private set; }
   private string Password { get; set; }
   public List<Listing> Listings { get; private set; } 
   public List<Review> Reviews { get; private set; }
   public List<Transaction> Transactions { get; private set; }

   public User(string userName, string password)
   {
      UserName = userName;
      Password = password;
      Listings = new List<Listing>();
      Reviews = new List<Review>();
      Transactions = new List<Transaction>();
   }

   // TODO: Calculate the rating of User.
   public double GetAvgRating()
   {
      return 0.0;
   }
   
   
}