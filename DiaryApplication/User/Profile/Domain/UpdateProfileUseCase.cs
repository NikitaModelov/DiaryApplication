using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.User.Profile.Data;

namespace DiaryApplication.User.Profile.Domain
{
    public class UpdateProfileUseCase
    {
        private readonly IProfileRepository repository;

        public UpdateProfileUseCase()
        {
            repository = new ProfileRepository();
        }

        public async Task<IResponseWrapper> UpdateProfile(int id, Core.Model.Profile profile)
        {
            return await repository.UpdateProfile(id, profile);
        }
    }
}
