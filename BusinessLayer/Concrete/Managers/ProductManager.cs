using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.CrossCuttingConcerns.Validation.FluentValidation;
using CoreLayer.Utilities.Business;
using CoreLayer.Utilities.Results;
using DataAccessLayer.Abstract;
using EntitiesLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result= BusinessRules.Run
                (
                ProductQuantityCheck(product.CategoryId), 
                ProductNameExistCheck(product.ProductName)
                );
            if (result!=null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        private IResult ProductNameExistCheck(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult ProductQuantityCheck(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductQuantityInvalid);
            }
            return new SuccessResult();
        }
        public IDataResult<List<Product>> GetAllProduct()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }

        public IResult Update(Product product)
        {
            
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
