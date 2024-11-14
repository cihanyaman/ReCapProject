using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // getCarAll();

            //GetColorTest();

            //GetBrandTest();

            //joinTest();

        }

        private static void joinTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var cars in carManager.GetCarDetails())
            {
                Console.WriteLine(cars.BrandName + " "
                    + cars.Description + " - "
                    + cars.ColorName + " renkli arabanın günlük kirası: "
                    + cars.DailyPrice + " ");
            }
        }

        private static void GetBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brands in brandManager.GetAll())
            {
                Console.WriteLine("{0} id numarasına ait : {1} Marka",brands.BrandId,brands.BrandName);
            }
        }

        private static void GetColorTest()
        {
            ColourManager colourManager = new ColourManager(new EfColorDal());
            foreach (var colors in colourManager.GetAll())
            {
                Console.WriteLine(colors.ColorName);
            }
        }

        private static void getCarAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }
        }
    }
}
