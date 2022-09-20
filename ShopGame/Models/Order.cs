namespace ShopGame.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<Game> Games { get; set; }
        
    }
}
