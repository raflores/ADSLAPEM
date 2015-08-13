using ADS.LAPEM.Infrastructure.Common;
using AopAlliance.Intercept;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.LAPEM.Infrastructure.Interceptor
{
    public class TxInterceptor : IMethodInterceptor
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        public object Invoke(IMethodInvocation invocation)
        {
            object returnValue = null;
            try
            {
                returnValue = invocation.Proceed();
                UnitOfWork.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return returnValue;
        }
    }
}
