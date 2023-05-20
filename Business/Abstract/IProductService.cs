using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategory(int categoryId);
        IDataResult<List<Product>> GetAllByUnitPrive(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        IResult AddTransactionalTest(Product product);
        IResult Update(Product product);
    }
}
