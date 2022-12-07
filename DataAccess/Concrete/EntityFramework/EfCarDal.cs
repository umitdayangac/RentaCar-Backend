using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal:EfEntityRepositoryBase<Car,RentaCarDbContext>,ICarDal
{
    public List<CarDetailDto> GetCarDetails()
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            var result = from c in context.Cars
                join b in context.Brands on c.BrandId equals b.Id
                join cl in context.Colors on c.ColorId equals cl.Id
                select new CarDetailDto
                {
                    CarName = c.Description,
                    BrandName = b.Name,
                    ColorName = cl.Name,
                    DailyPrice = c.DailyPrice
                };
            return result.ToList();
        }
    }
}