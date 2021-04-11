using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=2012,DailyPrice=170000,Description="sahibinden sıfır gibi" },

                new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=2012,DailyPrice=170000,Description="sahibinden sıfır gibi" },
                new Car{CarId=2,BrandId=3,ColorId=2,ModelYear=2020,DailyPrice=270000,Description="sahibinden sıfır gibi" },
                new Car{CarId=3,BrandId=2,ColorId=6,ModelYear=2018,DailyPrice=170000,Description="sahibinden sıfır gibi" },
                new Car{CarId=4,BrandId=4,ColorId=5,ModelYear=2021,DailyPrice=370000,Description="sahibinden sıfır gibi" },
                new Car{CarId=5,BrandId=5,ColorId=9,ModelYear=2017,DailyPrice=90000,Description="sahibinden sıfır gibi" }

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            
            
            if( carToDelete!=null )
                _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.CarId == id);
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            return  _cars.SingleOrDefault();//??????error 
        }

        public CarDetailDto GetCarDetail(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDto()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDto(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

       

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=> c.CarId == car.CarId);
            if(carToUpdate!=null)
            {
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.ModelYear = car.ModelYear;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
            }
        }
    }
}
