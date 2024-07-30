using Product.Domain.Entities;

namespace Product.Domain.IRepository
{
    public interface IProductRepository
    {
        Task<ProductEntity> Add(ProductEntity customerDto);
        Task<List<ProductEntity>> GetAll();
        Task<ProductEntity> GetById(int id);
        Task<ProductEntity> Update(ProductEntity customerDto);
        Task<int> Delete(int id);
    }
}
