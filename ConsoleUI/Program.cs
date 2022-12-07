using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI;

class Program
{
    private static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new InMemoryCar());
        foreach (var car in carManager.GetAll())
        {
            Console.WriteLine(car.Description);
        }
        
        Console.WriteLine(carManager.Get(2).Description);
    }
}