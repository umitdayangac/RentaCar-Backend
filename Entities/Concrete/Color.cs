using Entities.Abstract;

namespace Entities.Concrete;

public class Color:IEntity
{
    public int Id { get; set; }
    public string Type { get; set; }
}