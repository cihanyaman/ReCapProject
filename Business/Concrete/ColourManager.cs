using Business.Abstract;
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

        public void AddColor(Color color)
        {
            _colorDal.Add(color);
        }

        public void DeleteColor(Color color)
        {
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetColorId(int colorId)
        {
            return _colorDal.Get(co=>co.ColorId == colorId);
        }

        public void UpdateColor(Color color)
        {
            _colorDal.Update(color);
        }
    }
}
