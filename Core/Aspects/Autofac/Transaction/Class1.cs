using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    //Metodu işlet
                    invocation.Proceed();
                    //Ugurlu olarsa yekunlasdir
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    //Error vererse yerine yetirilen emeliyyati geri qaytar
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
