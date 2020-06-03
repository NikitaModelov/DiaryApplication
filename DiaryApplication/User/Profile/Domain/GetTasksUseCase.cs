using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.User.Profile.Data;

namespace DiaryApplication.User.Profile.Domain
{
    public class GetTasksUseCase
    {
        private readonly IProfileRepository repository;

        public GetTasksUseCase()
        {
            repository = new ProfileRepository();
        }
        public async Task<IResponseWrapper> GetProfileTasks(int id)
        {
            return await Task.Run(() => repository.GetProfileTasks(id));
        }
    }
}
