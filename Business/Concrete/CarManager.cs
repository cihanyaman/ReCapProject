using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;

        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrent(car.BrandId)
                            , CheckIfCarNameExists(car.Description)
                            , CheckIfBrandLimitExceded());

            if (result != null)
            {
                return result;
            }

                _carDal.Add(car);
            return new SuccessResult(Message.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Message.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(), Message.CarsListed);   
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Message.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Message.CarUpdated);
        }

        private IResult CheckIfCarCountOfBrandCorrent(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if(result>15)
            {
                return new ErrorResult(Message.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarNameExists(string description)
        {
            var result = _carDal.GetAll(c => c.Description == description).Any();
            if (result)
            {
                return new ErrorResult(Message.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfBrandLimitExceded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Message.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
