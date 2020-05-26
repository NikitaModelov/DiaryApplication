using Windows.UI.Xaml;
using DiaryApplication.Utills;
using Windows.UI.Xaml.Controls;
using DiaryApplication.SignIn.Domain;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DiaryApplication.SignIn.Presentation
{
    
    public sealed partial class SignIn : Page
    {
        public SignInViewModel ViewModel;
        public SignIn()
        {
            this.InitializeComponent();
            ViewModel = new SignInViewModel(new GetProfilesUseCase());
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SignUp.Presentation.SignUp));
        }
    }
}
