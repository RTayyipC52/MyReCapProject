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
            CarManager carManager = new CarManager(new EfCarDal());
            //CarTest();
            //BrandTest();
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine("----------------------------------");
            UserManager userManager = new UserManager(new EfUserDal());
            var consequence = userManager.GetUserDetails();
            if (consequence.Success == true)
            {
                foreach (var user in consequence.Data)
                {
                    Console.WriteLine(user.UserName + "/" + user.RentDate + "/" + user.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(consequence.Message);
            }
            Console.WriteLine("----------------------------------");
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var sonuc = rentalManager.GetRentalDetails();
            if (sonuc.Success==true)
            {
                foreach (var rental in sonuc.Data)
                {
                    Console.WriteLine(rental.RentId + "/" + rental.RentDate + "/" + rental.ReturnDate);
                }
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetByDailyPrice(750).Data)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("-------------------");
            foreach (var product in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(product.CarName + "/" + product.BrandName);
            }
        }
    }
}
