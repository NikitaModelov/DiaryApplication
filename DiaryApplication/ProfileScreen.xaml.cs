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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DiaryApplication
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ProfileScreen : Page
    {
        public ProfileScreen()
        {
            this.InitializeComponent();
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
