using Microsoft.AspNetCore.Identity;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IRoleService
    {
        Task<Result> AddRole(RoleViewmodel roleViewmodel);
        Task<Result> DeleteRoleByIdAsync(string roleId);
        Task<Result> UpdateRoleAsync(RoleViewmodel roleViewmodel);
        List<RoleViewmodel> GetAllRoles();
        Task<RoleViewmodel> GetRoleById(string roleId);
    }
}
