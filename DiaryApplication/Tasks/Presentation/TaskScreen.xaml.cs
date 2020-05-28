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
    }
}
