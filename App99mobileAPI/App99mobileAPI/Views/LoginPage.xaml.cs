using App99mobileAPI.API;
using App99mobileAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cadastroweb.Models;

namespace App99mobileAPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        List<LoginModel> listlogins;
        public LoginPage()
        {
            InitializeComponent();
            //this.BindingContext = new LoginViewModel();
            listlogins = new List<LoginModel>();
            
        }
        public async void Logar()
        {

            listlogins = await APIService.ObterLogin();
           var login = listlogins.Where(x => x.email == txtEmail.Text && x.senha == txtSenha.Text).ToList();
            //if (login.Count > 0)
            //{
            //    await Navigation.PushAsync(new Home());
            //}
        }

        private void btnlogin_Clicked(object sender, EventArgs e)
        {
            Logar();
        }
    }
}