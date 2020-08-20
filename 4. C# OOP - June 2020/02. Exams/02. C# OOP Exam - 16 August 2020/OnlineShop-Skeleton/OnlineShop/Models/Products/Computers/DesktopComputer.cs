namespace OnlineShop.Models.Products.Computers
{
    public class DesktopComputer : Computer
    {
        public DesktopComputer(int id, string manufacturer, string model, decimal price, double overallPerformance = 15) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
        }
    }
}
