using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class CarManager:ICarService
{
    private ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }
    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll());
    }

    public IDataResult<Car> Get(int id)
    {
        return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id==id));
    }

    public IResult Add(Car car)
    {
        var result = Isvalid(car.Description, car.DailyPrice);
        if (result.Success)
        {
            _carDal.Add(car);
            Console.WriteLine(result.Message);
            return new SuccessResult();
        }
        Console.WriteLine(result.Message);
        return new ErrorResult();

    }

    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult();
    }

    public IResult Delete(Car car)
    {
        _carDal.Delete(car);
        return new SuccessResult();
    }

    public IDataResult<List<Car>> GetCarsByBrandId(int id)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
    }

    public IDataResult<List<Car>> GetCarsByColorId(int id)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
    }

    public IDataResult<List<CarDetailDto>> GetCarDetails()
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
    }

    private  Result Isvalid(string? carName, decimal dailyPrice)
    {
        if (carName!=null && carName.Length > 1)
        {
            if (dailyPrice > 0)
            {
                return new SuccessResult("Eklendi");
            }
            else
            {
                return new ErrorResult("Arabanın günlük fiyatı 0'dan küçük olamaz! Girilen : " + dailyPrice);
            }
        }
        else
        {
            return new ErrorResult("Araba ismi en az 2 karakter olmalıdır !");
        }
        
    }
}