using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI;

class Program
{
    private static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new EfCarDal());
        
        // Console.WriteLine(carManager.Get(2).Description);
        // foreach (var car in carManager.GetCarsByBrandId(2))
        // {
        //     Console.WriteLine(car.Description);
        // }
        
        //Console.WriteLine(carManager.Get(2).Description);
    }
}