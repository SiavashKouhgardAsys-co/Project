using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IOwnerService
    {
        ReturnEntity_IQueryable<Owner> GetAllOwners();
        ReturnEntity<Owner> GetOwnerById(int id);
        Task<Result> CreateOwner(Owner owner);
    }
}
