using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal()); //InMemoryCarDal() 
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());


            foreach (var car in carManager.GetCarDetailDto())
            {
                Console.WriteLine(car.Name+"/"+car.BrandName+"/"+car.ColorName+"/"+car.DailyPrice); 
            }
            Console.WriteLine("----------");
            foreach (var colour in colorManager.GetAll()) 
            {
                Console.WriteLine(colour.ColorName); 
            }
            Console.WriteLine("-----------");
            foreach (var brands in brandManager.GetAll())
            {
                Console.WriteLine(brands.BrandName);
            }
            Console.WriteLine("-------");

            //foreach (var cars in carManager.GetAll())
            //{
            //    Console.WriteLine(cars.CarName);
            //}
            Console.WriteLine("-------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine(carManager.GetById(1).CarName);
            Console.WriteLine(colorManager.GetById(2).ColorName);
            Console.WriteLine(brandManager.GetById(1).BrandName);
            Console.WriteLine("-----------");











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
    }
}
