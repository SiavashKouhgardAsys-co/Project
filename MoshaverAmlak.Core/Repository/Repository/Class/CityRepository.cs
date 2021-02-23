﻿using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class CityRepository : ICityRepository
    {
        private readonly IGenericRepository<City> _cityRepository;
        public CityRepository(IGenericRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public ReturnEntity_IQueryable<City> GetAllCities() => _cityRepository.GetAllEntity();
        public ReturnEntity<City> GetCityById(int cityId) => _cityRepository.GetEntityById(cityId);

        public async Task<Result> CreateCity(City city)
        {
            var entity = _cityRepository.AddEntity(city);
            if (entity.Status != (int)Result.Status.OK) return await entity;
            return await _cityRepository.SaveChangeAsync();
        }


        public async Task<Result> DeleteCity(int cityId)
        {
            var entity = _cityRepository.DeleteEntityById(cityId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _cityRepository.SaveChangeAsync();
        }

        public async Task<Result> EditCity(City city)
        {
            var entity = GetCityById(city.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = city.Name;
            var update_entity = _cityRepository.UpdateEntity(entity.Entity);
            if (update_entity.StatusResult != (int)Result.Status.OK) return update_entity;
            return await _cityRepository.SaveChangeAsync();
        }


        public void Dispose()
        {
            _cityRepository?.Dispose();
        }


    }
}
