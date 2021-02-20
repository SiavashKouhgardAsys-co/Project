using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;

namespace MoshaverAmlak.Core.Repository.Service.Class
{
    public class UserService : UserManager<RealEstate_User>, IUserService
    {
        private readonly IdentityErrorDescriber _error;
        private readonly ILookupNormalizer _KeyNormalizer;
        private readonly ILogger<UserService> _logger;
        private readonly IOptions<IdentityOptions> _options;
        private readonly IPasswordHasher<RealEstate_User> _passwordHasher;
        private readonly IEnumerable<IPasswordValidator<RealEstate_User>> _passwordValidators;
        private readonly IServiceProvider _service;
        private readonly IUserStore<RealEstate_User> _userStore;
        private readonly IEnumerable<IUserValidator<RealEstate_User>> _userValidators;
        private readonly SignInManager<RealEstate_User> _signInManager;

        public UserService(
              IdentityErrorDescriber error,
              ILookupNormalizer KeyNormalizer,
              ILogger<UserService> logger,
              IOptions<IdentityOptions> options,
              IPasswordHasher<RealEstate_User> passwordHasher,
              IEnumerable<IPasswordValidator<RealEstate_User>> passwordValidators,
              IServiceProvider service,
              IUserStore<RealEstate_User> userStore,
              IEnumerable<IUserValidator<RealEstate_User>> userValidators,
              SignInManager<RealEstate_User> signInManager
            ) : base(userStore, options, passwordHasher, userValidators, passwordValidators, KeyNormalizer, error, service, logger)
        {
            _error = error;
            _KeyNormalizer = KeyNormalizer;
            _logger = logger;
            _options = options;
            _passwordHasher = passwordHasher;
            _passwordValidators = passwordValidators;
            _service = service;
            _userStore = userStore;
            _userValidators = userValidators;
            _signInManager = signInManager;
        }

        public async Task<Result> AddUserAsync(UserViewmodel_Register user, List<string> roles)
        {
            RealEstate_User realEstate_User = new RealEstate_User()
            {
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.Phone,
                UserName = user.Phone
            };

            var createUser = await CreateAsync(realEstate_User, user.Password);
            if (createUser.Succeeded)
            {
                var addRoleUser = await AddToRolesAsync(realEstate_User, roles);
                if (addRoleUser.Succeeded)
                    return Result.GenerateResult(Result.Status.OK);
                else
                    return Result.GenerateResult(Result.Status.NotRecognizedRole);
            }
            else
                return Result.GenerateResult(Result.Status.NotRecognizedUser);
        }
        public async Task<Result> DeleteUserByIdAsync(string userId)
        {
            var user = await FindByIdAsync(userId);
            var deleteUser = await DeleteAsync(user);
            if (deleteUser.Succeeded)
                return Result.GenerateResult(Result.Status.OK);
            else
                return Result.GenerateResult(Result.Status.Failed);
        }
        public async Task<Result> UpdateUserAsync(UserViewmodel user)
        {
            var findUser = await FindByIdAsync(user.UserId);
            findUser.Email = user.Email;
            findUser.PhoneNumber = user.Phone;
            findUser.FullName = user.FullName;

            var userUpdate = await UpdateAsync(findUser);
            if (userUpdate.Succeeded)
                return Result.GenerateResult(Result.Status.OK);
            else
                return Result.GenerateResult(Result.Status.Failed);
        }
        public async Task<Result> Login(UserViewmodel_Login login)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(login.Username, login.Password, login.IsPersistent, false);
            if (loginResult.Succeeded)
                return Result.GenerateResult(Result.Status.LoginOk);
            else
                return Result.GenerateResult(Result.Status.LoginFailed);
        }
        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
