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
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
                ViewModel = new InfoTaskViewModel((int)e.Parameter, new GetTaskByIdUseCase());
        }
    }
}
