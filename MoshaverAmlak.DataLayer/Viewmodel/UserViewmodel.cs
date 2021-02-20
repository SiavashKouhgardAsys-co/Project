using System.ComponentModel.DataAnnotations;

namespace MoshaverAmlak.DataLayer.Viewmodel
{
    public class UserViewmodel_Register
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
    public class UserViewmodel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class UserViewmodel_Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
        public string Captcha { get; set; }
    }
}
