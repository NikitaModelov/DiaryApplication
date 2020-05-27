using System.Threading.Tasks;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;

namespace DiaryApplication.User.SignIn.Data
{
    interface ISignInRepository
    {
        Task<IResponseWrapper> GetAllProfiles();
        
    }
}
