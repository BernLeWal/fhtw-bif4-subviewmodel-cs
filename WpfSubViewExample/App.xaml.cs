using System.Windows;
using WpfSubViewExample.SearchEngine;
using WpfSubViewExample.ViewModels;

namespace WpfSubViewExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            // BIZ-layer
            var searchEngine = new StandardSearchEngine();

            // MVVM:
            //var searchBarViewModel = new SearchBarViewModel();
            var singleLineSearchBarViewModel = new SingleLineSearchBarViewModel();
            var resultViewModel = new ResultViewModel();

            var wnd = new MainWindow
            {
                DataContext = new MainViewModel(singleLineSearchBarViewModel, resultViewModel, searchEngine),
                SingleLineSearchBar = { DataContext = singleLineSearchBarViewModel },
                //SearchBar = { DataContext = searchBarViewModel },
                ResultView = { DataContext = resultViewModel }
            };

            wnd.Show();
        }
    }
}
