namespace WowAPI.Models
{
    public class AuctionModel
    {
        public int id { get; set; }
        public ItemEntity? item { get; set; }
        public int? buyout { get; set; }
        public int? quantity { get; set; }
        public string? time_left { get; set; }
    }
}
