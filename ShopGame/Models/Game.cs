namespace ShopGame.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? SystemRequirements { get; set; }
        public string Image { get; set; }
        public List<Order>? Orders { get; set; }
        

    }
}
