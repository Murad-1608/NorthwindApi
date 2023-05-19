using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal productDal;
        private readonly ICategoryService categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            this.productDal = productDal;
            this.categoryService = categoryService;
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //biznes kodu ile validation arasindaki ferq, validationda sadece elave olan entity'nin qaydalari olur. Biznesde ise bir nece

            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                                               CheckIfProductNameExists(product.ProductName),
                                               CheckCategoryCount());

            if (result != null)
            {
                return result;
            }

            productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(productDal.GetAll(x => x.CategoryId == categoryId));
        }

        public IDataResult<List<Product>> GetAllByUnitPrive(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(productDal.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(productDal.Get(x => x.ID == productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(productDal.GetProductDetails());
        }


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                                               CheckIfProductNameExists(product.ProductName));

            if (result != null)
            {
                return result;
            }

            productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }


        //Business Codes
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var numberOfProduct = productDal.GetAll(x => x.CategoryId == categoryId).Count;

            if (numberOfProduct > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var value = productDal.GetAll(x => x.ProductName == productName).Any();

            if (value)
            {
                return new ErrorResult(Messages.ProdutNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckCategoryCount()
        {
            var categoryCount = categoryService.GetAll().Data.Count;

            if (categoryCount > 15)
            {
                return new ErrorResult(Messages.CategoryCountError);
            }
            return new SuccessResult();
        }
    }
}
