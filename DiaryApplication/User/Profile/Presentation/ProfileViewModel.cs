using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using DiaryApplication.Core;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.User.Profile.Domain;
using DiaryApplication.Utills;
using DiaryApplication.Utills.Command;

namespace DiaryApplication.User.Profile.Presentation
{
    public class ProfileViewModel : BindableBase
    {
        private UpdateProfileUseCase updateProfileUseCase;
        private GetProfileUseCase getProfileUseCase;

        private string firstName;
        private string secondName;
        private Core.Model.Profile profile;

        public string FirstName
        {
            get => firstName;
            set
            {
                Set(ref firstName, value);
            }
        }

        public string SecondName
        {
            get => secondName;
            set
            {
                Set(ref secondName, value);
            }
        }

        private DiaryCommandAsync updateDiaryCommandAsync;

        public DiaryCommandAsync UpdateDiaryCommand => updateDiaryCommandAsync ??
                                                       new DiaryCommandAsync(() => UpdateProfile());

        public ProfileViewModel(UpdateProfileUseCase updateProfileUseCase, GetProfileUseCase getProfileUseCase)
        {
            this.getProfileUseCase = getProfileUseCase;
            this.updateProfileUseCase = updateProfileUseCase;
            GetProfileById();
        }

        private async Task GetProfileById()
        {
            var response = await getProfileUseCase.Get(Session.IdProfile);
            if (response is Success<Core.Model.Profile> responseWrapper)
            {
                profile = responseWrapper.Data;
                FirstName = profile.FirstName;
                SecondName = profile.SecondName;
            }
            else
            {
                var errorMessage = (response as Error).Message;
                Debug.WriteLine("[ProfileViewModel.UpdateProfile()] Error: " + errorMessage);
                //TODO: Что-то делает при ошибке
            }
        }

        private async Task UpdateProfile()
        {
            if (FirstName != "" && SecondName != "")
            {
                var response = await updateProfileUseCase.UpdateProfile(Session.IdProfile, new Core.Model.Profile(FirstName, SecondName, null));
                if (response is Success<bool> responseWrapper)
                {
                    // TODO: Что-то сделать
                }
                else
                {
                    var errorMessage = (response as Error).Message;
                    Debug.WriteLine("[ProfileViewModel.UpdateProfile()] Error: " + errorMessage);
                    //TODO: Что-то делает при ошибке
                }
            }
            
        }
    }
}
