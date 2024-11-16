using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly ICarDal _carDal;

        public RentalManager(IRentalDal rentalDal, ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
        }

        public IResult AddRental(Rental rental)
        {
            var car = _carDal.Get(c=>c.CarId == rental.CarId);
            var activeRental = _rentalDal.Get(r=>r.CarId == rental.CarId && r.ReturnDate == null);

            if (activeRental != null)
            {
                return new ErrorResult(Message.CarIsAlreadyRented);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Message.RentalAdded);
        }

        public IResult DeleteRental(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Message.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Message.RentalsListed);
        }

        public IDataResult<Rental> GetRentalId(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }

        public IResult UpdateRental(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Message.RentalUpdated);
        }
    }
}
