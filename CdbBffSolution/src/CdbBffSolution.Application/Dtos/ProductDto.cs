namespace CdbBffSolution.Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal InterestRate { get; set; }
        public bool IsActive { get; set; }
    }
}
