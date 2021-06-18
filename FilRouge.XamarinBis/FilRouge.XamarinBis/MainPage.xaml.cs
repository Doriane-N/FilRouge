using FilRouge.XamarinBis.Models;
using FilRouge.XamarinBis.Services;
using FilRouge.XamarinBis.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace FilRouge.XamarinBis
{
    public partial class MainPage : ContentPage
    {
        private readonly IFilRougeService filRougeService;

        public MainPage()
        {
            InitializeComponent();
            this.filRougeService = new FilRougeService();
            var list = this.filRougeService.GetAllAsync();
            this.listAgents.ItemsSource = list.Result.ToList();
        }

        public async void Connection_Clicked(object sender, EventArgs e)
        {
            var mylogin = this.login.Text;
            var mypassword = this.password.Text;

            if(filRougeService.Authenticate(mylogin, mypassword))
            {
                await Navigation.PushAsync(new QuizzList());
            }
        }
    }
}
