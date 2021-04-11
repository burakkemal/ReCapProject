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
        public List<CarDetailDto> GetCarDetailDto(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from cr in context.Cars 
                             join b in context.Brands on cr.BrandId equals b.BrandId
                             join cl in context.Colors on cr.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarId = cr.CarId,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 ColorId = cl.ColorId,
                                 ColorName = cl.ColorName,
                                 DailyPrice = cr.DailyPrice,
                                 ModelYear = cr.ModelYear,
                                 Description = cr.Description,
                                 Images=(from i in context.CarImages where i.CarId==cr.CarId select i.ImagePath).ToList()                                 
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();


    }

}       
    }
}

