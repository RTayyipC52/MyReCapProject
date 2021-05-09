using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;
        IColorService _colorService;
        public CarManager(ICarDal iCarDal, IBrandService brandService, IColorService colorService)
        {
            _carDal = iCarDal;
            _brandService = brandService;
            _colorService = colorService;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckMinDailyPrice(car.DailyPrice));
            if (result!=null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==14)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.DailyPrice>=min));
        }

        public IDataResult<List<Car>> GetByDescription(string Name)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.Description==Name));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==Id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == Id));
        }

        public IResult Update(Car car)
        {
            var result = _carDal.GetAll(c=>c.Id == car.Id).Count();
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountError);
            }
            throw new NotImplementedException();
        }

        private IResult CheckMinDailyPrice(decimal dailyPrice)
        {
            var result = _carDal.GetAll(c => c.DailyPrice == dailyPrice).Min(null);
            if (result<=500)
            {
                return new ErrorResult(Messages.MinDailyPrice);
            }
            return new SuccessResult();
        }
    }
}
