using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Profile> Profiles
        {
            get { return profiles; }
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
            var dataProfiles = new List<Profile>();
            dataProfiles = await getProfilesUseCase.Get();
            profiles = new ObservableCollection<Profile>(dataProfiles);
        }
    }
}
