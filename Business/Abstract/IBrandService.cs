﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult AddBrand(Brand brand);
        IResult DeleteBrand(Brand brand);
        IResult UpdateBrand(Brand brand);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetBrandById(int brandId);

    }
}
