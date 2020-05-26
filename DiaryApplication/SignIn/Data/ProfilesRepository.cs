using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core;
using DiaryApplication.Core.Model;
using DiaryApplication.SignIn.Data.Local;

namespace DiaryApplication.SignIn.Data
{
    public class ProfilesRepository : IProfilesRepository
    {
        private readonly IProfilesDataSource localDataSource;

        public ProfilesRepository()
        {
            localDataSource = new ProfilesLocalDataSource();
        }
        public Task<List<Profile>> GetAllProfiles()
        {
            return localDataSource.GetAllProfiles();
        }

        public void SendProfile(Profile profile)
        {
            localDataSource.SendProfile(profile);
        }
    }
}
