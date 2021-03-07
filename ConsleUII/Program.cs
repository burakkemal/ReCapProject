using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {

            //CarManager carManager = new CarManager(new EfCarDal()); //InMemoryCarDal() 
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //UserManager userManager = new UserManager(new EfUserDal());
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            ////foreach (var user in userManager.GetAll().Data)
            ////{
            ////    Console.WriteLine(user.UserId + " / " + user.FirstName + "  / " + user.LastName + " / " + user.Password);
            ////}

            ////customerManager.Add(new Customer { CompanyName = "deneme", UserId = 1 });
            ////Console.WriteLine("Eklendi");

            //var result = rentalManager.Add(new Rental {CarId=1,CustomerId=1,RentDate=DateTime.Now});
            //Console.WriteLine(result.Message);


            //ilişkiliListeleme(carManager);


            //Console.WriteLine("----------");
            //foreach (var colour in colorManager.GetAll())
            //{
            //    Console.WriteLine(colour.ColorName);
            //}
            //Console.WriteLine("-----------");
            //foreach (var brands in brandManager.GetAll())
            //{
            //    Console.WriteLine(brands.BrandName);
            //}
            //Console.WriteLine("-------");

            ////foreach (var cars in carManager.GetAll())
            ////{
            ////    Console.WriteLine(cars.CarName);
            ////}
            //Console.WriteLine("-------------");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.CarName);
            //}

            //carManager.Add(new Car() { BrandId = 1, CarName = "Ford", ColorId = 1, DailyPrice = 180, Description = "Alırsan ford olursun lord", ModelYear = 2020 });
            //Console.WriteLine(carManager.GetById(1));
            //Console.WriteLine(colorManager.GetById(2).ColorName);
            //Console.WriteLine(brandManager.GetById(1).BrandName);
            //Console.WriteLine("-----------");


            //carManager.Update(new Car { CarId = 1, CarName = "Ford", ColorId = 1, DailyPrice = 180, Description = "Alırsan ford ol lord", ModelYear = 2020 });


            //foreach (var car in carManager.GetCarDetailDto())
            //{
            //    Console.WriteLine(car.Name + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            //}








            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Id + "-" + car.BrandId + "-" + car.ColorId + " " + car.ModelYear);
            //}

            //Console.WriteLine("---------------------");
            //Console.WriteLine(carManager.GetById(5).ToString());

            //carManager.Add(new Entities.Concrete.Car
            //{
            //    //Id = 6,
            //    //Name="A4",
            //    BrandId = 3,
            //    ColorId = 2,
            //    DailyPrice = 100000,
            //    ModelYear = 2008,
            //    Description = "Ön tapon değişmiş "
            //});

            //Console.WriteLine("---------------------");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Id + "-" + car.BrandId + "-" + car.ColorId + " " + car.ModelYear);
            //}


        }

        private static void ilişkiliListeleme(CarManager carManager)
        {
            var result = carManager.GetCarDetailDto();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Name + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
