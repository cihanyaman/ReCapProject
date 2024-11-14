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
        void AddColor(Color color);
        void DeleteColor(Color color);
        void UpdateColor(Color color);
        List<Color> GetAll();
        Color GetColorId(int colorId);
    }
}
