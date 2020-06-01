using System.Diagnostics;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.User.SignUp.Domain;
using DiaryApplication.Utills;
using DiaryApplication.Utills.Command;

namespace DiaryApplication.User.SignUp.Presentation
{
    public class SignUpViewModel : BindableBase
    {
        private readonly SendProfileUseCase sendProfileUseCase;

        private string firstName = "";
        private string secondName = "";

        private bool showError = false;

        public bool ShowError
        {
            get => showError;
            set
            {
                Set(ref showError, value);
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

        private DiaryCommand createProfileCommand;

        public DiaryCommand CreateProfileCommand => createProfileCommand ??
                                                         (createProfileCommand = new DiaryCommand(() => CreateProfile()));

        public SignUpViewModel(SendProfileUseCase sendProfileUseCase)
        {
            this.sendProfileUseCase = sendProfileUseCase;
        }


        private async Task CreateProfile()
        {
            if (FirstName.Length != 0 && SecondName.Length != 0)
            {
                var response = await sendProfileUseCase.SendProfile(new Core.Model.Profile(FirstName, SecondName, null));
                if (response is Success<bool> responseWrapper && responseWrapper.Data)
                {
                    ShowError = false;
                }
                else
                {
                    var errorMessage = (response as Error).Message;
                    
                    Debug.WriteLine("[SignUpViewModel.CreateProfile()] Error: " + errorMessage);
                    
                }

            }
            else
            {
                ShowError = true;
            }
        }
    }
}