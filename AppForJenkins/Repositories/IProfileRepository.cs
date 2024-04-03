using AppForJenkins.Model;

namespace AppForJenkins.Repositories
{
    public interface IProfileRepository
    {
        Task<ProfileModel> LoginAsync(string email, string password);

    }
}