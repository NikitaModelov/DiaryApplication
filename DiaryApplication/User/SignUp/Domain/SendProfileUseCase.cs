using System.Threading.Tasks;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.User.SignIn.Data;
using DiaryApplication.User.SignUp.Data;

namespace DiaryApplication.User.SignUp.Domain
{
    public class SendProfileUseCase
    {
        private readonly ISignUpRepository repository;

        public SendProfileUseCase()
        {
            repository = new SignUpRepository();
        }

        public async Task<IResponseWrapper> SendProfile(Core.Model.Profile profile)
        {
            return await Task.Run(() => repository.SendProfile(profile));
        } 
    }
}
