using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation) 
        {
            using (TransactionScope transactionScope = new TransactionScope()) //şablon oluşturuluyor. 
            {
                try
                {
                    invocation.Proceed(); //metodu çalıştır.
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
        //
        // Transaction yönetimi tutarlılığı yöneten sistemdir. 
        //mesela 10 tl para gönderiyoruz hesabımız da var mı varsa gönder yoksa göndermeye calıstıgın parayı gerı al.
    }
}
