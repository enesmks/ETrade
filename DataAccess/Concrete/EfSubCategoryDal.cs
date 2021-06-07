﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfSubCategoryDal : EfEntityRepositoryBase<SubCategory,ETradeContext>,ISubCategoryDal
    {
    }
}
