using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfBrandDal:IBrandDal
{
    public List<Brand> GetAll(Expression<Func<Brand, bool>>? filter = null)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            return filter == null
                ? context.Set<Brand>().ToList()
                : context.Set<Brand>().Where(filter).ToList();
        }
    }

    public Brand Get(Expression<Func<Brand, bool>> filter)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            return context.Set<Brand>().SingleOrDefault(filter);
        }
    }

    public void Add(Brand entity)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Update(Brand entity)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            var updateEntity = context.Entry(entity);
            updateEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }

    public void Delete(Brand entity)
    {
        using (RentaCarDbContext context = new RentaCarDbContext())
        {
            var deleteEntity = context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}

