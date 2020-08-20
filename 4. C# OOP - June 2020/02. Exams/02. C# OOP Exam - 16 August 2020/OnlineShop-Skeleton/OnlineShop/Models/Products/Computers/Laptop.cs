namespace OnlineShop.Models.Products.Computers
{
    public class Laptop : Computer
    {
        public Laptop(int id, string manufacturer, string model, decimal price, double overallPerformance = 10) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
        }
    }
}
