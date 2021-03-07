using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch; //implementasyonunu ıcoremodule eklememiz gerekiyor. 

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>(); //
        }


        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start(); //metod önünde kronometreyi baslatıyourz
        }

        protected override void OnAfter(IInvocation invocation) //metod bittiğinde geçen süreyi hesaplıyoruz.
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval) //geçen süre verdiğimiz süreden büyükse
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}
