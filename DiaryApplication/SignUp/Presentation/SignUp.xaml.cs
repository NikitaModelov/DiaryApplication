using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DiaryApplication.SignUp.Domain;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DiaryApplication.SignUp.Presentation
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
            this.Frame.Navigate(typeof(SignIn.Presentation.SignIn));
        }
    }
}
