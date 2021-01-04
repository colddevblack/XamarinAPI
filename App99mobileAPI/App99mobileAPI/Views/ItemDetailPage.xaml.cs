using App99mobileAPI.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace App99mobileAPI.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}