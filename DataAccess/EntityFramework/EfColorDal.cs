using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.EntityFramework
{
    public class EfColorDal :EfEntityRepositoryBase<Color,CarDbContext>, IColorDal
    {
        
    }
}
