using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DiaryApplication.User.Profile.Domain;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DiaryApplication.User.Profile.Presentation
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ProfileScreen : Page
    {
        public ProfileViewModel ViewModel { get; }

        public ProfileScreen()
        {
            this.InitializeComponent();
            ViewModel = new ProfileViewModel(new UpdateProfileUseCase(),
                                             new GetProfileUseCase());
        }

        private void EditProfile_OnClick(object sender, RoutedEventArgs e)
        {
            InfoSubTitle.Visibility = Visibility.Collapsed;
            EditSubtitle.Visibility = Visibility.Visible;
            FirstNameBox.IsReadOnly = false;
            SecondNameBox.IsReadOnly = false;
            EditButton.Visibility = Visibility.Visible;
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            InfoSubTitle.Visibility = Visibility.Visible;
            EditSubtitle.Visibility = Visibility.Collapsed;
            FirstNameBox.IsReadOnly = true;
            SecondNameBox.IsReadOnly = true;
            EditButton.Visibility = Visibility.Collapsed;
        }
    }
}
