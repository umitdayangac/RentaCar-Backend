using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal:ICarDal
{
    public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            return filter == null
                ? context.Set<Car>().ToList()
                : context.Set<Car>().Where(filter).ToList();
        }
    }

    public Car Get(Expression<Func<Car, bool>> filter)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            return context.Set<Car>().SingleOrDefault(filter);
        }
    }

    public void Add(Car entity)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Update(Car entity)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            var updateEntity = context.Entry(entity);
            updateEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }

    public void Delete(Car entity)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            var deleteEntity = context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    
}