using System;
using WpfSubViewExample.SearchEngine.Abstract;
using WpfSubViewExample.ViewModels.Abstract;

namespace WpfSubViewExample.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        // ViewModels of UserControls:
        private readonly ResultViewModel resultView;
        private readonly SingleLineSearchBarViewModel singleLineSearchBarViewModel;

        // BIZ - layer
        private readonly ISearchEngine searchEngine;

        public MainViewModel(SingleLineSearchBarViewModel singleLineSearchBarViewModel, ResultViewModel resultView, ISearchEngine searchEngine)
        {
            // initialize Sub-ViewModels
            this.resultView = resultView;
            this.singleLineSearchBarViewModel = singleLineSearchBarViewModel;
            singleLineSearchBarViewModel.OnSearchClicked += (_, searchText) =>
            {
                // call the BIZ-layer
                SearchTours(searchText);
            };
            
            //searchBar.SearchTextChanged += (_, searchText) =>
            //{
            //    SearchTours(searchText);
            //};

            // init ref to BIZ-Layer
            this.searchEngine = searchEngine;
        }

        private void SearchTours(string searchText)
        {
            var results = String.Join("\n", this.searchEngine.SearchFor(searchText));
            this.resultView.DisplayResults(results);
        }
    }
}
