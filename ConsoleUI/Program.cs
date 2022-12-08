using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.VisualBasic;

namespace ConsoleUI;

class Program
{
    private static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new EfCarDal());
        // Car carAdd = new Car { BrandId = 2, ColorId = 2, ModelYear = 2018, DailyPrice = 0, Description = "ddsds" };
        // carManager.Add(carAdd);
        // Console.WriteLine(carManager.Get(2).Description);
        foreach (var car in carManager.GetCarDetails().Data)
        {
            Console.WriteLine($"Araba Model : {Strings.Trim(car.CarName)} Araba Marka : {Strings.Trim(car.BrandName)} Araba Renk : {Strings.Trim(car.ColorName)} Araba Fiyatı : {car.DailyPrice} Tl");
        }

        //Console.WriteLine(carManager.Get(2).Description);
    }
}