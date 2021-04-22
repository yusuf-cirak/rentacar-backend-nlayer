using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect:MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;
        public CacheAspect(int duration=60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"); // reflected type = namespace+class
            // Üstteki komut reflected type ile çalışıyor. Business.Concrete.ProductManager.GetAll
            var arguments = invocation.Arguments.ToList();
            // invocation parametreler demek. parametreleri listeye çevir komutunu verdik
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            //  arguments.Select(x => x?.ToString() parametre değerlerini listeye çevirir
            // eğer parametre değeri varsa o parametre değerini GetAll içine ekliyor.
            if (_cacheManager.IsAdd(key)) // Bellekte böyle bir cache anahtarı var mı ?
            {
                invocation.ReturnValue = _cacheManager.Get(key); // Varsa methodu hiç çalıştırmadan geri dön.
                return;
            }
            invocation.Proceed();  // Yoksa parametreyi çalıştır.
            _cacheManager.Add(key, invocation.ReturnValue, _duration); // Daha önce hiç cacheye eklenmemiş fakat eklenmesi gerekiyor. Bu işlemi yapıyoruz.
        }
    }
}
