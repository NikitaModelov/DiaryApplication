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

        
        private string secondName;
        private Core.Model.Profile profile;

        private bool showErrorFirstName = false;
        public bool ShowErrorFirstName
        {
            get => showErrorFirstName;
            set
            {
                Set(ref showErrorFirstName, value);
            }
        }

        private bool showErrorSecondName = false;
        public bool ShowErrorSecondName
        {
            get => showErrorSecondName;
            set => Set(ref showErrorSecondName, value);
        }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                if (Validator.ValidateTextField(value, LengthText.NameLength))
                {
                    ShowErrorFirstName = false;
                    Set(ref firstName, value);
                }
                else
                {
                    ShowErrorFirstName = true;
                }
            }
        }

        public string SecondName
        {
            get => secondName;
            set
            {
                if (Validator.ValidateTextField(value, LengthText.NameLength))
                {
                    showErrorSecondName = false;
                    Set(ref secondName, value);
                }
                else
                {
                    showErrorSecondName = true;
                }
                    
            }
        }

        private DiaryCommand updateDiaryCommandAsync;

        public DiaryCommand UpdateDiaryCommand => updateDiaryCommandAsync ??
                                                       new DiaryCommand(() => UpdateProfile());

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
                var response = await updateProfileUseCase.UpdateProfile(new Core.Model.Profile(Session.IdProfile, FirstName, SecondName, null));
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
