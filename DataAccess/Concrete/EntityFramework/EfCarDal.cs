using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDto()
        {
            using (ReCapProjectDbContext context=new ReCapProjectDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join r in context.Colors
                             on c.ColorId equals r.ColorId
                             select new CarDetailDto { Name=c.CarName, BrandId = c.BrandId, BrandName = b.BrandName, Id = c.CarId, 
                                                     ColorId = c.ColorId, DailyPrice = c.DailyPrice, Description = c.Description,  
                                                     ModelYear = c.ModelYear, ColorName = r.ColorName};
                return result.ToList();
            } 
        }
    }
}
