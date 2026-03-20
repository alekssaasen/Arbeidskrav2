using Arbeidskrav2.UI;

namespace Arbeidskrav2;

class Program
{
    static void Main(string[] args)
    {
        Marketplace M = new Marketplace();
        MarketplaceApp app = new MarketplaceApp(M);
        
        app.Run();
    }
}