namespace CdbBffSolution.Domain.Entities
{
    public class ProductCustomer
    {

        public int Id { get; set; }
        public ProductEntity Product { get; set; }
        public Customer Customer { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseValue { get; set; }
    }
}
