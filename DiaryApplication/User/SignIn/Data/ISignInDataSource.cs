using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLib;

namespace DiaryApplication.User.SignIn.Data
{
    interface ISignInDataSource
    {
        Task<List<ProfileDTO>> GetAllProfiles();
        
    }
}
