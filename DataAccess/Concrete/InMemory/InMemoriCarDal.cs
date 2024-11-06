﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoriCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoriCarDal()
        {
            _cars = new List<Car> { 
                new Car{CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 800, ModelYear = 2023, Description="Renult Clio"},
                new Car{CarId = 2, BrandId = 1, ColorId = 1, DailyPrice = 1000, ModelYear = 2022, Description="Renult Captur"},
                new Car{CarId = 3, BrandId = 2, ColorId = 2, DailyPrice = 600, ModelYear = 2023, Description="Hyundai i20"},
                new Car{CarId = 4, BrandId = 3, ColorId = 2, DailyPrice = 700, ModelYear = 2024, Description="Opel Astra"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(p=>p.CarId == car.CarId);
            _cars.Remove(CarToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId, int colorId)
        {
            return _cars.Where(p=>p.BrandId == brandId ).ToList();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(p=> p.CarId == car.CarId);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.Description = car.Description;
        }
    }
}