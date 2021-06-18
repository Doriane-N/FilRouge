using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FilRouge.XamarinBis
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void Connection_Clicked(object sender, EventArgs e)
        {
            var mylogin = this.login.Text;
            var mypassword = this.password.Text;
        }
    }
}
