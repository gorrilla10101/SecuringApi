namespace ClientService
{
    public class ClientDetails
    {
        public int ClientId { get; set; }
        public required string ClientName { get; set; }
        public string CurrencySymbol { get; set; } = "$";
    }
}
