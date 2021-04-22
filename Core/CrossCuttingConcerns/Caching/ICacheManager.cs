using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key); // Keye karşılık olan datayı ver.
        object Get(string key); // Get komutunun genericsiz hali.
        void Add(string key, object value, int duration); // object= Her şeyin basesi olan tek şey olduğundan dolayı object kullandık.
        bool IsAdd(string key); // Komutun cache'de var mı yok mu kontrolünü yapan komut.
        void Remove(string key); // Cache'den uçurma işlemi
        void RemoveByPattern(string key);
    }
}
