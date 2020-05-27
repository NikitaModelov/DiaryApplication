using System.Threading.Tasks;
using DataBaseLib;

namespace DiaryApplication.User.SignUp.Data.Local
{
    class SignUpLocalDataSource : ISignUpDataSource
    {
        private readonly IDatabase<ProfileDTO, bool> database;

        public SignUpLocalDataSource()
        {
            database = new DataBaseProfile();
        }

        public async Task<bool> SendProfile(ProfileDTO profile)
        {
            return await database.Create(profile);
        }
    }
}