using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace spisok_pokupok_1
{

    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            var mainViewModel = new ViewModel();
            BindingContext = mainViewModel;
        }

    }
}
