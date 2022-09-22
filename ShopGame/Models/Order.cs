namespace ShopGame.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Game> Games { get; set; }
        
    }
}
