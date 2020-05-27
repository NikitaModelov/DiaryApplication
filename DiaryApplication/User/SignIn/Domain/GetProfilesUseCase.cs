using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.User.SignIn.Data;

namespace DiaryApplication.User.SignIn.Domain
{
    public class GetProfilesUseCase
    {
        private readonly ISignInRepository repository;

        public GetProfilesUseCase()
        {
            repository = new SignInRepository();
        }

        public async Task<IResponseWrapper> Get()
        {
            return await repository.GetAllProfiles();
        }
    }
}
