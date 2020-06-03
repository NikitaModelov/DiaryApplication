using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLib;
using DataBaseLib.Database;

namespace DiaryApplication.User.SignIn.Data.Local
{
    public class SignInLocalDataSource : ISignInDataSource
    {
        private readonly IDataBaseProfile<ProfileDTO, bool> dataBase;

        public SignInLocalDataSource()
        {
            dataBase = new DatabaseProfile();
        }
        public async Task<List<ProfileDTO>> GetAllProfiles()
        {
            return await dataBase.SelectAll();
        }
    }
}
