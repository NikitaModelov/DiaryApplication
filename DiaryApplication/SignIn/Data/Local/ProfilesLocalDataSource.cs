using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core;
using DiaryApplication.Core.Model;

namespace DiaryApplication.SignIn.Data.Local
{
    public class ProfilesLocalDataSource : IProfilesDataSource
    {
        private readonly DataBaseProfile dataBase;

        public ProfilesLocalDataSource()
        {
            dataBase = new DataBaseProfile();
        }
        public async Task<List<Profile>> GetAllProfiles()
        {
            return await dataBase.GetAllProfiles();
        }

        public void SendProfile(Profile profile)
        {
            dataBase.InsertProfile(profile);
        }
    }
}
