using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfColorDal:IColorDal
{
    public List<Color> GetAll(Expression<Func<Color, bool>>? filter = null)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            return filter == null
                ? context.Set<Color>().ToList()
                : context.Set<Color>().Where(filter).ToList();
        }
    }

    public Color Get(Expression<Func<Color, bool>> filter)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            return context.Set<Color>().SingleOrDefault(filter);
        }
    }

    public void Add(Color entity)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Update(Color entity)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            var updateEntity = context.Entry(entity);
            updateEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }

    public void Delete(Color entity)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            var deleteEntity = context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}