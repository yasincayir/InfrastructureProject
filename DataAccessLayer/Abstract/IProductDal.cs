using CoreLayer.DataAccess;
using EntitiesLayer.ComplexType;
using EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetail> GetProductsDetail();
    }
}
