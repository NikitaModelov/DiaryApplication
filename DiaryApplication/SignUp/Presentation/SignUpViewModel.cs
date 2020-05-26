using DiaryApplication.Utills;
using System.Diagnostics;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.SignUp.Domain;
using DiaryApplication.Utills.Command;

namespace DiaryApplication.SignUp.Presentation
{
    public class SignUpViewModel : BindableBase
    {
        private readonly SendProfileUseCase sendProfileUseCase;

        private string firstName;
        private string secondName;

        private bool visibleLoading;

        public bool VisibleLoading
        {
            get => visibleLoading;
            set
            {
                Set(ref visibleLoading, value);
            }
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (value != "")
                {
                    Set(ref firstName, value);
                }
            }
        }

        public string SecondName
        {
            get => secondName;
            set
            {
                if (value != "")
                {
                    Set(ref secondName, value);
                }
            }
        }

        private DiaryCommandAsync createProfileCommand;

        public DiaryCommandAsync CreateProfileCommand => createProfileCommand ??
                                                         (createProfileCommand = new DiaryCommandAsync(() => CreateProfile()));

        public SignUpViewModel(SendProfileUseCase sendProfileUseCase)
        {
            this.sendProfileUseCase = sendProfileUseCase;
        }


        private async Task CreateProfile()
        {
            if (FirstName.Length != 0 && SecondName.Length != 0)
            {
                ShowLoadingData(true);
                var response = await sendProfileUseCase.SendProfile(new Profile(FirstName, SecondName));
                if (response is Success<bool> responseWrapper && responseWrapper.Data)
                {
                    ShowLoadingData(false);
                }
                else
                {
                    var errorMessage = (response as Error).Message;
                    Debug.WriteLine("[SignUpViewModel.CreateProfile()] Error: " + errorMessage);
                    //TODO: Что-то делает при ошибке
                }

            }
        }

        private void ShowLoadingData(bool value)
        {
            VisibleLoading = value;
        }
    }
}
