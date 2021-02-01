using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _Cars;

        public InMemoryCarDal()
        {
            _Cars = new List<Car>{
            new Car {Id=1,BrandId=1,ColorId=1,DailyPrice=2000000,Description="Sanroof mevcut" },
            new Car {Id=2,BrandId=2,ColorId=2,DailyPrice=3000000,Description="Memurdan hastasına" },
            new Car {Id=3,BrandId=3,ColorId=3,DailyPrice=4000000,Description="Temiz Kullanılmış" },
            new Car {Id=4,BrandId=4,ColorId=4,DailyPrice=5000000,Description="Kilometre düşük alana ho"}
            };

        }

        public void Add(Car car)
        {
            _Cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _Cars.SingleOrDefault(c => c.Id == car.Id);
            _Cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _Cars;
        }

        public List<Car> GetById(int id)
        {
            return _Cars.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _Cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
