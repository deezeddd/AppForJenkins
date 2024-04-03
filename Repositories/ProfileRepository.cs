using AppForJenkins.Model;

namespace AppForJenkins.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly List<ProfileModel> _users;

        public ProfileRepository()
        {
            // Initialize with some sample users (for demonstration)
            _users = new List<ProfileModel>
            {
                new ProfileModel {Email = "user1@example.com", Password = "password1" },
                new ProfileModel { Email = "user2@example.com", Password = "password2" }
            };
        }
        public async Task<ProfileModel> LoginAsync(string email, string password)
        {
           var user = _users.FirstOrDefault(u => u.Email == email && u.Password == password);

           return user;
        }
    }
}

