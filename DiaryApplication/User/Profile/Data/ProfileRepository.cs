using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.User.Profile.Data.Local;
using DiaryApplication.Utills;

namespace DiaryApplication.User.Profile.Data
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IProfileDataSource localDataSource;

        public ProfileRepository()
        {
            localDataSource = new ProfileLocalDataSource();
        }
        public async Task<IResponseWrapper> UpdateProfile(Core.Model.Profile profile)
        {
            try
            {
                var response = await localDataSource.UpdateProfile(ProfileMapper.ConvertToDto(profile));
                return new Success<bool>(response);
            }
            catch (Exception e)
            {
                Debug.WriteLine("[ProfileRepository.UpdateProfile()] Error: " + e.Message);
                return new Error(e.Message);
            }
        }

        public async Task<IResponseWrapper> GetProfileById(int id)
        {
            try
            {
                var response = await localDataSource.GetProfileById(id);
                return new Success<Core.Model.Profile>(ProfileMapper.ConvertFromDto(response));
            }
            catch (Exception e)
            {
                Debug.WriteLine("[ProfileRepository.GetProfileById()] Error: " + e.Message);
                return new Error(e.Message);
            }
        }
    }
}
