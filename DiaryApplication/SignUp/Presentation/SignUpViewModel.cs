using DiaryApplication.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DiaryApplication.Core.Model;
using DiaryApplication.SignUp.Domain;
using DiaryApplication.Utills.Command;

namespace DiaryApplication.SignUp.Presentation
{
    public class SignUpViewModel : BindableBase
    {
        private SendProfileUseCase sendProfileUseCase;

        private string firstName;
        private string secondName;

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
                sendProfileUseCase.SendProfile(new Profile(FirstName, SecondName));
            }
        }
    }
}
