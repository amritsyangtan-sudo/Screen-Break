using ScreenBreak.Views;

namespace ScreenBreak.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public object CurrentView { get; set; }

        public MainWindowViewModel()
        {
            CurrentView = new DashboardView();
        }

        public void ShowDashboard()
        {
            CurrentView = new DashboardView();
        }

        public void ShowSettings()
        {
            CurrentView = new SettingsView();
        }
    }
}
