namespace CdbBffSolution.Application.Dtos
{
    public class ProductClientDto
    {
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int ClientId { get; set; }
        public CustomerDto Customer { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public decimal PurchaseValue { get; set; }
    }
}
