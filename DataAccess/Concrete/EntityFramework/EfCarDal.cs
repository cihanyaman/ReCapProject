﻿using Core.DataAccess.EntityFramewok;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var resault = from c in context.Cars
                              join b in context.Brands
                              on c.BrandId equals b.BrandId
                              join co in context.Colors
                              on c.ColorId equals co.ColorId
                              select new CarDetailDto
                              {
                                  CarId = c.CarId,
                                  Description = c.Description,
                                  BrandName = b.BrandName,
                                  ColorName = co.ColorName, 
                                  DailyPrice = c.DailyPrice
                              };
                return (List<CarDetailDto>)resault.ToList();
            }
        }
    }
}
