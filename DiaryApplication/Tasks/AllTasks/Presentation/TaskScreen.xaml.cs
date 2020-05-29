using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DiaryApplication.Tasks.AddTask.Presentation;
using DiaryApplication.Tasks.Domain;
using DiaryApplication.Tasks.Presentation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DiaryApplication.Tasks
{
    public sealed partial class TaskScreen : Page
    {
        public TaskViewModel ViewModel;
        public TaskScreen()
        {
            this.InitializeComponent();
            ViewModel = new TaskViewModel(new GetTasksUseCase());
        }

        private void AddTask_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddTaskScreen));
        }
    }
}
