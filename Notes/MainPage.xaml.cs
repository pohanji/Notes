using Notes.Models;
using Notes.Pages;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Notes
{
    public partial class MainPage : ContentPage
    {
        public IList<Note> Notes { get; private set; }
        public MainPage()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "notes.db3");

            var db = new SQLiteConnection(dbPath);

            Notes = new List<Note>();
            db.CreateTable<Note>();
            if (db.Table<Note>().Count() > 0)
            {
                var table = db.Table<Note>();
                foreach (var s in table)
                {
                    Notes.Add(s);
                }
            }
            BindingContext = this;
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddNote());
        }

        async private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                await Navigation.PushModalAsync(new ViewNote
                {
                    BindingContext = e.Item as Note
                });
            }
        }
    }
}
