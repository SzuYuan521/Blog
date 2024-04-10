using Blog.ViewModels.Auth;

namespace Blog.Applications.Auth
{
    public interface IAuthService
    {
        Task<bool> LoginUserCheckPassword(LoginRequest loginRequest);
    }
}
