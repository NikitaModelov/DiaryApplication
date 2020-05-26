using DiaryApplication.SignIn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;
using DiaryApplication.Utills;

namespace DiaryApplication.SignUp.Domain
{
    public class SendProfileUseCase
    {
        private readonly IProfilesRepository repository;

        public SendProfileUseCase()
        {
            repository = new ProfilesRepository();
        }

        public async Task<IResponseWrapper> SendProfile(Profile profile)
        {
            return await repository.SendProfile(profile);
        } 
    }
}
