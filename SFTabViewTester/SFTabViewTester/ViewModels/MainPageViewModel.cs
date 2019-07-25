using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SFTabViewTester.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand OverviewSelectionCommand => new AsyncCommand(() => Navigate());

        private async Task Navigate()
        {
        }

        public ObservableCollection<object> LandItems { get; set; }
        public ObservableCollection<object> OceanItems { get; set; }

        public MainPageViewModel()
        {
            this.LandItems = new ObservableCollection<object>();
            this.OceanItems = new ObservableCollection<object>();
        }

        public async override Task InitializeAsync()
        {
            await base.InitializeAsync();

            await LoadLandMenu();
            await LoadOceanMenu();
        }

        private async Task LoadLandMenu()
        {
            this.LandItems.Clear();
            this.LandItems.Add(new CatObject());
            this.LandItems.Add(new DogObject());
        }
        private async Task LoadOceanMenu()
        {
            this.OceanItems.Clear();
            this.OceanItems.Add(new WhaleObject());
            this.OceanItems.Add(new SharkObject());
        }
    }
}