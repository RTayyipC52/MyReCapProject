using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{ Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2000, DailyPrice = 1500, Description = "Tofas" },
                new Car{ Id = 2, BrandId = 2, ColorId = 2, ModelYear = 1990, DailyPrice = 1900, Description = "Audi" },
                new Car{ Id = 3, BrandId = 3, ColorId = 3, ModelYear = 1999, DailyPrice = 2500, Description = "Seat" },
                new Car{ Id = 4, BrandId = 4, ColorId = 4, ModelYear = 2011, DailyPrice = 3600, Description = "Range Rover" },
                new Car{ Id = 5, BrandId = 5, ColorId = 5, ModelYear = 2004, DailyPrice = 4400, Description = "BMW" },
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            // Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul.
            Car carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
