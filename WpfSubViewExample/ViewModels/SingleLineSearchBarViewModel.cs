using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfSubViewExample.ViewModels.Abstract;

namespace WpfSubViewExample.ViewModels
{
    public class SingleLineSearchBarViewModel : BaseViewModel
    {
        private string _searchText = "";
        public string SearchText { 
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get;  }

        public event EventHandler<string> OnSearchClicked;

        public SingleLineSearchBarViewModel()
        {
            this.SearchCommand = new SearchCommand((_) => {
                Console.WriteLine("Button clicked");
                this.OnSearchClicked?.Invoke(this, SearchText);
            });
        }
    }
}
