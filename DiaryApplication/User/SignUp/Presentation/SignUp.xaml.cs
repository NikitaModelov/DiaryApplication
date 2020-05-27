using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DiaryApplication.User.SignUp.Domain;

namespace DiaryApplication.User.SignUp.Presentation
{
    public sealed partial class SignUp : Page
    {
        public SignUpViewModel ViewModel { get; private set; }

        public SignUp()
        {
            this.InitializeComponent();
            ViewModel = new SignUpViewModel(new SendProfileUseCase());
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(User.SignIn.Presentation.SignIn));
        }
    }
}