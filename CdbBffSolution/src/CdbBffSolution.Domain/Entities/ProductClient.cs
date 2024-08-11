namespace CdbBffSolution.Domain.Entities
{
    public class ProductClient
    {

        public int Id { get; set; }        
        public Product Product { get; set; }
        public Client Client { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseValue { get; set; }
    }
}
