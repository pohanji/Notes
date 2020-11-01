using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewNote : ContentPage
    {
        public ViewNote()
        {
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async private void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddNote((BindingContext as Note).Id));
        }
    }
}