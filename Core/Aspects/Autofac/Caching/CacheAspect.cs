using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Cashing;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60) //60dakika cache'de duracak
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>(); //hangi servicetool kullandığımızı belirtiyoruz.
        }

        public override void Intercept(IInvocation invocation) //metotınterceptiondan gelen override method. 
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"); //ReflectedType ile namespace buluyoruz. + metodun ismini buluyoruz
            var arguments = invocation.Arguments.ToList();//methodun parametrelerini listeye çevir
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";//parametre değerin varsa bu parametre değerini ekliyoruz yoksa null geçiyoruz.
            if (_cacheManager.IsAdd(key))//key var mı daha önce eklenen 
            {
                invocation.ReturnValue = _cacheManager.Get(key); //metodu hiç çalıştırmadan geriye döner. cachemanagerden get eder çünkü orda var.
                return;
            }
            invocation.Proceed();//veritabanından datayı getirdi
            _cacheManager.Add(key, invocation.ReturnValue, _duration); //yeni cache eklendi.
            //genel olarak cachede var mı diye kontrol eder varsa cache'den getirir yoksa cacheye ekleyip veritabanından getirir.
        }
    }
}
