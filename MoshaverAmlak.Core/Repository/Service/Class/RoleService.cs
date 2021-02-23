using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Class
{
    public class RoleService : RoleManager<IdentityRole> , IRoleService
    {
        private readonly IdentityErrorDescriber _errors;
        private readonly ILookupNormalizer _keyNormalize;
        private readonly ILogger<RoleService> _logger;
        private readonly IEnumerable<IRoleValidator<IdentityRole>> _roleValidators;
        private readonly IRoleStore<IdentityRole> _store;

        public RoleService(IRoleStore<IdentityRole> store, ILookupNormalizer keyNormalize, ILogger<RoleService> logger, IEnumerable<IRoleValidator<IdentityRole>> roleValidators, IdentityErrorDescriber errors)
            : base(store, roleValidators, keyNormalize, errors, logger)
        {
            _store = store;
            _roleValidators = roleValidators;
            _keyNormalize = keyNormalize;
            _errors = errors;
            _logger = logger;
        }

        public async Task<Result> AddRole(RoleViewmodel roleViewmodel)
        {
            IdentityRole identityRole = new IdentityRole()
            {
                Name = roleViewmodel.Name
            };
            var role = await CreateAsync(identityRole);
            if (role.Succeeded)
                return Result.GenerateResult(Result.Status.OK);
            else
                return Result.GenerateResult(Result.Status.Failed);
        }
        public async Task<Result> DeleteRoleByIdAsync(string roleId)
        {
            var role = await FindByIdAsync(roleId);
            var deleteRole = await DeleteAsync(role);
            if (deleteRole.Succeeded)
                return Result.GenerateResult(Result.Status.OK);
            else
                return Result.GenerateResult(Result.Status.Failed);
        }
        public async Task<Result> UpdateRoleAsync(RoleViewmodel roleViewmodel)
        {
            var findRole = await FindByIdAsync(roleViewmodel.Id);
            findRole.Id = roleViewmodel.Id;
            findRole.Name = roleViewmodel.Name;

            var updateRole = await UpdateAsync(findRole);
            if (updateRole.Succeeded)
                return Result.GenerateResult(Result.Status.OK);
            else
                return Result.GenerateResult(Result.Status.Failed);
        }
        public List<RoleViewmodel> GetAllRoles() => Roles.Select(x => new RoleViewmodel()
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
        public async Task<RoleViewmodel> GetRoleById(string roleId)
        {
            var role = await FindByIdAsync(roleId);
            return new RoleViewmodel()
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
