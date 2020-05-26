using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.SignIn.Data.Local;
using DiaryApplication.Utills;

namespace DiaryApplication.SignIn.Data
{
    public class ProfilesRepository : IProfilesRepository
    {
        private readonly IProfilesDataSource localDataSource;

        public ProfilesRepository()
        {
            localDataSource = new ProfilesLocalDataSource();
        }
        public async Task<IResponseWrapper> GetAllProfiles()
        {
            try
            {
                var response = await localDataSource.GetAllProfiles();
                return new Success<List<Profile>>(response);
            }
            catch (Exception e)
            {
                Debug.WriteLine("[ProfilesRepository] Error: " + e.Message);
                return new Error(e.Message);
            }
        }

        public async Task<IResponseWrapper> SendProfile(Profile profile)
        {
            try
            {
                var response = await localDataSource.SendProfile(profile);
                return new Success<bool>(response);
            }
            catch (Exception e)
            {
                Debug.WriteLine("[ProfilesRepository] Error: " + e.Message);
                return new Error(e.Message);
            }
            
        }
    }
}
