namespace ClientServices.Dtos
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public required string ClientName { get; set; }
        public required string CurrencySymbol { get; set; } = "$";
    }
}
