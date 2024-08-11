namespace CdbBffSolution.Application.Dtos
{
    public class ProductCustomerDto
    {
        public ProductDto Product { get; set; }
        public CustomerDto Customer { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public decimal PurchaseValue { get; set; }
    }
}
