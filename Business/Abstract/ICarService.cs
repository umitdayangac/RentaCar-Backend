using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICarService
{
    List<Car> GetAll();
    Car Get(int id);
    void Add(Car car);
    void Update(Car car);
    void Delete(Car car);

    List<Car> GetCarsByBrandId(int id);
    List<Car> GetCarsByColorId(int id);

    List<CarDetailDto> GetCarDetails();
}