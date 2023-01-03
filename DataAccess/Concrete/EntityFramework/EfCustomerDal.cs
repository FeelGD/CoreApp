using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CoreContext>, ICustomerDal
    {
        public bool CheckById(int customerId)
        {
            using (var context=new CoreContext())
            {
                var result = (from customer in context.Customers
                             where customer.Id == customerId
                             select new Customer
                             {
                                 Id = customer.Id
                             }).ToList();
                if (result.Count==0)
                {
                    return false;
                }
                return true;
            };
        }
    }
}
