using DiaryApplication.SignIn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;

namespace DiaryApplication.SignUp.Domain
{
    public class SendProfileUseCase
    {
        private readonly IProfilesRepository repository;

        public SendProfileUseCase()
        {
            repository = new ProfilesRepository();
        }

        public async void SendProfile(Profile profile)
        {
            repository.SendProfile(profile);
        } 
    }
}
