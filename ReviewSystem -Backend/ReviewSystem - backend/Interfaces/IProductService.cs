using ReviewSystem.DTOs;

namespace ReviewSystem.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductListDto>> GetAllProductsAsync();
        Task<ProductDetailsDto?> GetProductByIdAsync(int id);
    }
}