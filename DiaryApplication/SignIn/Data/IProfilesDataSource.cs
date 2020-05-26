using System.Collections.Generic;
using System.Threading.Tasks;
using DiaryApplication.Core;
using DiaryApplication.Core.Model;

namespace DiaryApplication.SignIn.Data
{
    interface IProfilesDataSource
    {
        Task<List<Profile>> GetAllProfiles();
        Task<bool> SendProfile(Profile profile);
    }
}
