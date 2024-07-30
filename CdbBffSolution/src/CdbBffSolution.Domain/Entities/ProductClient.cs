namespace CdbBffSolution.Domain.Entities
{
    public class ProductClient
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseValue { get; set; }
    }
}
