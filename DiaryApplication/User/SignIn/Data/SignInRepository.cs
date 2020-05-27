using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.User.SignIn.Data.Local;
using DiaryApplication.Utills;

namespace DiaryApplication.User.SignIn.Data
{
    public class SignInRepository : ISignInRepository
    {
        private readonly ISignInDataSource localDataSource;

        public SignInRepository()
        {
            localDataSource = new SignInLocalDataSource();
        }
        public async Task<IResponseWrapper> GetAllProfiles()
        {
            try
            {
                var response = await localDataSource.GetAllProfiles();
                var list = ProfileMapper.ConvertFromProfilesDTO(response).ToList();
                return new Success<List<Core.Model.Profile>>(list);
            }
            catch (Exception e)
            {
                Debug.WriteLine("[SignInRepository.GetAllProfiles()] Error: " + e.Message);
                return new Error(e.Message);
            }
        }
    }
}
