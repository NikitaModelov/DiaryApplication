using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DiaryApplication.Tasks.AddTask.Domain;


namespace DiaryApplication.Tasks.AddTask.Presentation
{

    public sealed partial class AddTaskScreen : Page
    {
        public AddTaskViewModel ViewModel { get; private set; }

        public AddTaskScreen()
        {
            this.InitializeComponent();
            ViewModel = new AddTaskViewModel(new SendTaskUseCase(), new GetTypeUseCase());
        }

        private void NavigateToInfoTask_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void SelectItems_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SetSelectedTypes(MyGridView.SelectedItems.ToList());
        }
    }
}
