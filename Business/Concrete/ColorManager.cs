using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ColorManager:IColorService
{
    private IColorDal _colorDal;

    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }
    public List<Color> GetAll()
    {
        return _colorDal.GetAll();
    }

    public Color Get(int id)
    {
        return _colorDal.Get(color => color.Id == id);
    }

    public void Add(Color color)
    {
        _colorDal.Add(color);
    }

    public void Update(Color color)
    {
        _colorDal.Update(color);
    }

    public void Delete(Color color)
    {
        _colorDal.Delete(color);
    }
}