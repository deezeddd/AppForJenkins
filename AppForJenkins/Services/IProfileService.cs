using AppForJenkins.Model;

namespace AppForJenkins.Services
{
    public interface IProfileService
    {
       Task<ProfileModel> LoginAsync(string email, string password);

    }
}