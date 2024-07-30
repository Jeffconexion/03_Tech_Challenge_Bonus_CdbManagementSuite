using Product.Application.Dtos;
using Product.Domain.Entities;

namespace Product.Application.IServices
{
    public interface IProductServices
    {
        Task<ProductEntity> Add(ProductDto productDto);
        Task<List<ProductEntity>> GetAll();
        Task<ProductEntity> GetById(int id);
        Task<ProductEntity> Update(ProductDto productDto, int id);
        Task<int> Delete(int id);
    }
}
