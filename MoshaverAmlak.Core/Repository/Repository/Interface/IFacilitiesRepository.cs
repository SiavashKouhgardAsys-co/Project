﻿using System;
using System.Threading.Tasks;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IFacilitiesRepository : IDisposable
    {
        ReturnEntity_IQueryable<Facilities> GetAllFacilities();
        ReturnEntity<Facilities> GetFacilityById(int facilityId);
        Task<Result> CreateFacility(Facilities facilities);
        Task<Result> DeleteFacilityById(int facilityId);
        Task<Result> EditFacility(Facilities facilities);
    }
}
