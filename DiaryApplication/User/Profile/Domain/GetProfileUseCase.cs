using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.User.Profile.Data;

namespace DiaryApplication.User.Profile.Domain
{
    public class GetProfileUseCase
    {
        private readonly IProfileRepository repository;

        public GetProfileUseCase()
        {
            repository = new ProfileRepository();
        }

        public async Task<IResponseWrapper> Get(int id)
        {
            return await Task.Run(() => repository.GetProfileById(id));
        }
    }
}
