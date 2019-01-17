using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace NotesFragment
{
    public class DatabaseService
    {
        SQLiteConnection db;

        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "notesDb.db3");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Notes>();
        }

        public void AddNote(Notes note)
        {
            db.Insert(note);
        }

        public void UpdateNote(Notes note)
        {
            db.Update(note);
        }

        public List<Notes> GetAllNotes()
        {
            var table = db.Table<Notes>();
            return table.ToList();
        }

        public void DeleteNote(Notes note)
        {
            db.Delete(note);
        }
    }
}