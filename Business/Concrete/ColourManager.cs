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
    public class ColourManager:IColourService
    {
        IColorDal _colorDal;

        public ColourManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult AddColor(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Message.ColorAdded);
        }

        public IResult DeleteColor(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Message.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Message.ColorsListed);
        }

        public IDataResult<Color> GetColorId(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(co=>co.ColorId == colorId));
        }

        public IResult UpdateColor(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Message.ColorUpdated);
        }
    }
}
