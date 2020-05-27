using Windows.UI.Xaml.Controls;
using DiaryApplication.User.Profile.Presentation;


namespace DiaryApplication
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NavigationViewControl_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                // TODO: навигация на настройки
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                switch (navItemTag)
                {
                    case "Profile":
                        MainFrame.Navigate(typeof(ProfileScreen));
                        break;
                }
                
            }
        }
    }
}
