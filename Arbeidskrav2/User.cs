namespace Arbeidskrav2;

public class User
{
   public string UserName { get; private set; }
   private string Password { get; set; }
   public List<Listing> UserListings { get; private set; } 
   public List<Review> Reviews { get; private set; }
   public List<Transaction> Transactions { get; private set; }

   public User(string userName, string password)
   {
      UserName = userName;
      Password = password;
      UserListings = new List<Listing>();
      Reviews = new List<Review>();
      Transactions = new List<Transaction>();
   }
   
   public double GetAvgRating()
   {
      IEnumerable<int> result = Reviews
         .Select(r => r.DiceRating);

      return result.Average();
   }

   public bool VerifyPassword(string password)
   {
      if (Password == password)
      {
         return true;
      }
      return false;
   }
}