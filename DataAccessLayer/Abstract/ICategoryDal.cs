using CoreLayer.DataAccess;
using EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
    }
}
