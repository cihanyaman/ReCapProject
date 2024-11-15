using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColourService
    {
        IResult AddColor(Color color);
        IResult DeleteColor(Color color);
        IResult UpdateColor(Color color);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetColorId(int colorId);
    }
}
