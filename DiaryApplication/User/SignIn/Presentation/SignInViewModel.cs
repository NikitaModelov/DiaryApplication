using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using DiaryApplication.Core;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.User.SignIn.Domain;
using DiaryApplication.Utills;
using DiaryApplication.Utills.Command;

namespace DiaryApplication.SignIn.Presentation
{
    public class SignInViewModel : BindableBase
    {
        private readonly GetProfilesUseCase getProfilesUseCase;
        private ObservableCollection<Profile> profiles;
        private bool visibleLoading;
        private DiaryCommand signInCommand;
        private Profile profile;

        public Profile Profile
        {
            get => profile;
            set
            {
                Set(ref profile, value);
            }
        }

        public DiaryCommand SignInCommand => signInCommand ??
                                                       (signInCommand = new DiaryCommand(() => SignIn(profile)));

        public bool VisibleLoading
        {
            get => visibleLoading;
            set
            {
                Set(ref visibleLoading, value);
            }
        }
        public ObservableCollection<Profile> Profiles
        {
            get => profiles;
            set
            {
                if (value != null)
                {
                    Set(ref profiles, value);
                }
            }
        }

        public SignInViewModel(GetProfilesUseCase getProfilesUseCase)
        {
            this.getProfilesUseCase = getProfilesUseCase;
            GetAllProfileAsync();
        }

        private async Task GetAllProfileAsync()
        {
            var response = await getProfilesUseCase.Get();
            if (response is Success<List<Profile>> responseWrapper)
            {
                Profiles = new ObservableCollection<Profile>(responseWrapper.Data);
            }
            else
            {
                var errorMessage = (response as Error).Message;
                Debug.WriteLine("[SignInViewModel.GetAllProfileAsync()] Error: " + errorMessage);
            }
        }

        private void SignIn(Profile profile)
        {
            Session.SetId(profile.Id);
        }

        private void ShowLoadingData(bool value)
        {
            VisibleLoading = value;
        }
    }
}
