using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core;
using DiaryApplication.Core.Model;
using DiaryApplication.SignIn.Data;
using DiaryApplication.Utills;

namespace DiaryApplication.SignIn.Domain
{
    public class GetProfilesUseCase
    {
        private readonly IProfilesRepository repository;

        public GetProfilesUseCase()
        {
            repository = new ProfilesRepository();
        }

        public async Task<IResponseWrapper> Get()
        {
            return await repository.GetAllProfiles();
        }
    }
}
