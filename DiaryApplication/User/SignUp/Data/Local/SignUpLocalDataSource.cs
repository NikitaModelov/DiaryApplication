using System.Threading.Tasks;
using DataBaseLib;
using DataBaseLib.Database;


namespace DiaryApplication.User.SignUp.Data.Local
{
    class SignUpLocalDataSource : ISignUpDataSource
    {
        private readonly IDataBaseProfile<ProfileDTO, bool> database;

        public SignUpLocalDataSource()
        {
            database = new DatabaseProfile();
        }

        public async Task<bool> SendProfile(ProfileDTO profile)
        {
            return await database.Create(profile);
        }
    }
}