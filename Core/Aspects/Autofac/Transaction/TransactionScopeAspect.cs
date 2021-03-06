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
            using (var transactionScope = new TransactionScope())
            {
                try
                {
                    transactionScope.Complete();
                    invocation.Proceed();
                }
                catch (Exception e)
                {
                    transactionScope.Dispose();
                    throw e;
                }
            }
        }
    }
}
