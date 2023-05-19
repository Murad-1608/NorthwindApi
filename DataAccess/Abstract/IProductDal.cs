using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductDal : IRepositoryBase<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
