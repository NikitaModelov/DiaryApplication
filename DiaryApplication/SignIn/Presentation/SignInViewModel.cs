using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using DiaryApplication.Core;
using DiaryApplication.Core.Model;
using DiaryApplication.SignIn.Domain;
using DiaryApplication.Utills;

namespace DiaryApplication.SignIn.Presentation
{
    public class SignInViewModel : BindableBase
    {
        private readonly GetProfilesUseCase getProfilesUseCase;
        private ObservableCollection<Profile> profiles;
        private bool visibleLoading;

        public bool VisibleLoading
        {
            get => visibleLoading;
            set
            {
                if (value != null)
                {
                    Set(ref visibleLoading, value);
                }
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
                //TODO: Что-то делает при ошибке
            }

        }

        private void ShowLoadingData(bool value)
        {
            VisibleLoading = value;
        }
    }
}
