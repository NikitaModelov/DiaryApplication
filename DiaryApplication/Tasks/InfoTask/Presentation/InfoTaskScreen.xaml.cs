using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using DiaryApplication.Tasks.InfoTask.Domain;

namespace DiaryApplication.Tasks.InfoTask.Presentation
{
    public sealed partial class InfoTaskScreen : Page
    {
        public InfoTaskViewModel ViewModel;
        public InfoTaskScreen()
        {
            this.InitializeComponent();
            DateToday.MaxYear = DateTimeOffset.Now;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
                ViewModel = new InfoTaskViewModel(
                    (int)e.Parameter, 
                    new GetTaskByIdUseCase(), 
                    new AddIntervalUseCase(), 
                    new DeleteIntervalUseCase(),
                    new UpdateTaskUseCase(),
                    new CloseTaskUseCase());
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonSaveEdit.Visibility = Visibility.Visible;

            TitleLavel.Visibility = Visibility.Collapsed;
            TitleTextBox.Visibility = Visibility.Visible;

            InfoSubTitle.Visibility = Visibility.Collapsed;
            InfoSubTextBox.Visibility = Visibility.Visible;

            DescriptionTextBox.Visibility = Visibility.Visible;
            DescriptionLabel.Visibility = Visibility.Collapsed;
        }

        private void SaveEditButton_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonSaveEdit.Visibility = Visibility.Collapsed;


            TitleLavel.Visibility = Visibility.Visible;
            TitleTextBox.Visibility = Visibility.Collapsed;

            InfoSubTitle.Visibility = Visibility.Visible;
            InfoSubTextBox.Visibility = Visibility.Collapsed;

            DescriptionTextBox.Visibility = Visibility.Collapsed;
            DescriptionLabel.Visibility = Visibility.Visible;
        }

        private async void CloseTask_OnClick(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Потверждение действия",
                Content = "Вы действительно хотитите закрыть эту задачу?",
                PrimaryButtonText = "Да",
                PrimaryButtonCommand = ViewModel.CloseTaskCommand,
                SecondaryButtonText = "Нет"
            };

            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
            {
                this.Frame.Navigate(typeof(TaskScreen));
            }
        }
    }
}
