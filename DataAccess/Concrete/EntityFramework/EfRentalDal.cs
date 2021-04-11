using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetail()
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from rent in context.Rentals
                             join car in context.Cars
                             on rent.CarId equals car.CarId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join customer in context.Customers
                             on rent.CustomerId equals customer.CustomerId
                             join user in context.Users
                             on customer.UserId equals user.Id
                             orderby (rent.RentalId)
                             select new RentalDetailDto
                             {
                                 Id = rent.RentalId,
                                 BrandName = brand.BrandName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = rent.RentDate,
                                 ReturnDate = rent.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
