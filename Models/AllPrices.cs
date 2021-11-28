namespace TradingView.Models
{
    public class AllPrices
    {
        public string Timestamp { get; set; } = "";
        public string FantomPrice { get; set; } = "";
        public string TombPrice { get; set; } = "";
        public string TombFantomPrice { get; set; } = "";
        public string GeistPrice { get; set; } = "";
    }
}