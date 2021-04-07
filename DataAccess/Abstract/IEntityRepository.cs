using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Abstract
{
    // <T> tanımı sayesinde entitieslerin hepsini kullanabiliyoruz. T:class sayesinde T olarak class'lar kullanılabiliyor.
    // new() sayesinde de sadece new'lenebilen class'ları kullanıyoruz. IEntity devre dışı kaldı.
    public interface IEntityRepository<T> where T:class, IEntity,new() // Generic kısıt işlemini tamamladık.
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
