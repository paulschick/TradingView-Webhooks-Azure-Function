namespace TradingView.Models
{
    public class AlertResponse
    {
        public string Exchange { get; set; }
        public string Symbol { get; set; }
        public string Datetime { get; set; }
        public string Price { get; set; }
        public string Volume { get; set; }
    }
}