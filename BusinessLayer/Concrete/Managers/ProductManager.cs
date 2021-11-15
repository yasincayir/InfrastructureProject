using BusinessLayer.Abstract;
using BusinessLayer.BusinessAspects.Autofac;
using BusinessLayer.Constants;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Caching;
using CoreLayer.Aspects.Autofac.Performance;
using CoreLayer.Aspects.Autofac.Transaction;
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

        public IDataResult<List<Product>> GetByCategory(int id)
        {
          return   new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id));
        }

        //[SecuredOperation("product.add")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
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

        [CacheAspect]
        public IDataResult<List<Product>> GetAllProduct()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }

        public IResult Update(Product product)
        {
            
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);
            if (product.UnitPrice < 10)
            {
                throw new Exception("");
            }
            Add(product);
            return null;
        }
    }
}
