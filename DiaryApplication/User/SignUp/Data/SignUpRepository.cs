using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.User.SignUp.Data.Local;
using DiaryApplication.Utills;

namespace DiaryApplication.User.SignUp.Data
{
    public class SignUpRepository : ISignUpRepository
    {
        private readonly ISignUpDataSource localDataSource;

        public SignUpRepository()
        {
            localDataSource = new SignUpLocalDataSource();
        }

        public async Task<IResponseWrapper> SendProfile(Core.Model.Profile profile)
        {
            try
            {
                var response = await localDataSource.SendProfile(ProfileMapper.ConvertToDto(profile));
                return new Success<bool>(response);
            }
            catch (Exception e)
            {
                Debug.WriteLine("[ProfilesRepository.SendProfile()] Error: " + e.Message);
                return new Error(e.Message);
            }

        }
    }
}
