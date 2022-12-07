using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryCar:ICarDal
{
    private List<Car> _cars;

    public InMemoryCar()
    {
        _cars = new List<Car>
        {
            new Car{Id = 1,BrandId = 1,ColorId = 1,ModelYear = 2018,DailyPrice = 250.00m,Description = "Audi"},
            new Car{Id = 2,BrandId = 2,ColorId = 2,ModelYear = 2019,DailyPrice = 350.00m,Description = "BMW"},
            new Car{Id = 3,BrandId = 3,ColorId = 3,ModelYear = 2020,DailyPrice = 450.00m,Description = "Renault"},
            
        };
    }
    public List<Car> GetAll()
    {
        return _cars;
    }

    public Car Get(int id)
    {
        return _cars.SingleOrDefault(c => c.Id == id);
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Update(Car car)
    {
        Car carUpdateTo = _cars.SingleOrDefault(c => c.Id == car.Id);
        carUpdateTo.BrandId = car.BrandId;
        carUpdateTo.ColorId = car.ColorId;
        carUpdateTo.ModelYear = car.ModelYear;
        carUpdateTo.DailyPrice = car.DailyPrice;
        carUpdateTo.Description = car.Description;
    }

    public void Delete(Car car)
    {
        Car carDeletTo = _cars.SingleOrDefault(c => c.Id == car.Id);
        _cars.Remove(carDeletTo);
    }
}