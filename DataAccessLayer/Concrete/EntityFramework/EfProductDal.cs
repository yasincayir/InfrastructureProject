using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntitiesLayer.ComplexType;
using EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetail> GetProductsDetail()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetail
                             {
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 ProductId = p.ProductId,
                             };
                return result.ToList();
            }
        }
    }
}
