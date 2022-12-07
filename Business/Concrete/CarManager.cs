using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CarManager:ICarService
{
    private ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }
    public List<Car> GetAll()
    {
        return _carDal.GetAll();
    }

    public Car Get(int id)
    {
        return _carDal.Get(c=>c.Id==id);
    }

    public void Add(Car car)
    {
        if (Isvalid(car.Description,car.DailyPrice))
        {
            _carDal.Add(car);
        }
        
        
    }

    public void Update(Car car)
    {
        _carDal.Update(car);
    }

    public void Delete(Car car)
    {
        _carDal.Delete(car);
    }

    public List<Car> GetCarsByBrandId(int id)
    {
        return _carDal.GetAll(c => c.BrandId == id);
    }

    public List<Car> GetCarsByColorId(int id)
    {
        return _carDal.GetAll(c => c.ColorId == id);
    }

    private bool Isvalid(string? carName, decimal dailyPrice)
    {
        if (carName!=null && carName.Length > 1)
        {
            if (dailyPrice > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Arabanın günlük fiyatı 0'dan küçük olamaz! Girilen : " + dailyPrice);
            }
        }
        else
        {
            Console.WriteLine("Araba ismi en az 2 karakter olmalıdır !");
        }

        return false;
    }
}