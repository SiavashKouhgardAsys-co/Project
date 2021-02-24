using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Viewmodel;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IUserService
    {
        Task<Result> AddUserAsync(UserViewmodel_Register user, List<string> roles);
        Task<Result> DeleteUserByIdAsync(string userId);
        Task<Result> UpdateUserAsync(UserViewmodel user);
        Task<Result> Login(UserViewmodel_Login login);
        Task<UserViewmodel> GetAllUserById(string userId);
        IQueryable<UserViewmodel> GetAllUsers();
        Task LogOut();
    }
}
