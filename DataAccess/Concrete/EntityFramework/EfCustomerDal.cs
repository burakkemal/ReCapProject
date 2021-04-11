using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCustomerDal:EfEntityRepositoryBase<Customer,ReCapProjectDbContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetail(Expression<Func<Customer, bool>> filter = null)
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from customer in filter == null ? context.Customers : context.Customers.Where(filter)
                             join user in context.Users on customer.UserId equals user.Id
                             orderby (customer.CustomerId)
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.CustomerId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CompanyName = customer.CompanyName
                             };

                return result.ToList();

            }
        }
    }
}
