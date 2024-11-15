using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //getCarAll();

            GetColorTest();

            //GetBrandTest();

            //joinTest();

        }

        private static void joinTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {

                foreach (var cars in result.Data)
                {
                    Console.WriteLine(cars.BrandName + " "
                        + cars.Description + " - "
                        + cars.ColorName + " renkli arabanın günlük kirası: "
                        + cars.DailyPrice + " ");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void GetBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success) {
                foreach (var brands in result.Data)
                {
                    Console.WriteLine("{0} id numarasına ait : {1} Marka", brands.BrandId, brands.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetColorTest()
        {
            ColourManager colourManager = new ColourManager(new EfColorDal());
            var result = colourManager.GetAll();
            if (result.Success)
            {
                foreach (var colors in result.Data)
                {
                    Console.WriteLine(colors.ColorName);
                    
                }
                Console.WriteLine(Message.ColorsListed);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void getCarAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();

            if(result.Success)
            {
                foreach (var cars in result.Data)
                {
                    Console.WriteLine(cars.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
