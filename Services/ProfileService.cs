using System.Threading.Tasks;
using AppForJenkins.Model;
using AppForJenkins.Repositories;

namespace AppForJenkins.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<ProfileModel> LoginAsync(string email, string password)
        {
             return await _profileRepository.LoginAsync(email, password);
            
        }
    }
}
