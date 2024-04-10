using Blog.Applications.Auth;
using Blog.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _auth;
        public LoginController(IAuthService auth)
        {
            _auth = auth;
        }

        public async Task<IActionResult> Index(LoginRequest loginRequest)
        {
            if(await _auth.LoginUserCheckPassword(loginRequest))
            {
            }
            return View();
        }
    }
}
