using Notes.Models;
using SQLite;
using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNote : ContentPage
    {
        private int _id = 0;
        public AddNote()
        {
            InitializeComponent();
        }
        public AddNote(int id)
        {
            InitializeComponent();
            _id = id;
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            var note = new Note();
            note.Name = Name.Text;
            note.NoteBody = Body.Text;
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "notes.db3");
            var db = new SQLiteConnection(dbPath);

            if (_id > 0)
            {
                note.CreatedAt = DateTime.Now;

                db.Insert(note);
            }
            else
            {
                note.Id = _id;
                note.EditedAt = DateTime.Now;
                db.Update(note);
            }

            await Navigation.PopModalAsync();
        }
    }
}