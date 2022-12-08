﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICarService
{
    IDataResult<List<Car>> GetAll();
    IDataResult<Car> Get(int id);
    IResult Add(Car car);
    IResult Update(Car car);
    IResult Delete(Car car);

    IDataResult<List<Car>> GetCarsByBrandId(int id);
    IDataResult<List<Car>> GetCarsByColorId(int id);

    IDataResult<List<CarDetailDto>> GetCarDetails();
}