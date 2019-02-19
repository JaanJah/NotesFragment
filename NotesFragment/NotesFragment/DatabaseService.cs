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
        public SQLiteConnection db;
        public static List<Notes> noteList { get; set; }
        public static DatabaseService dbConnection { get; set; }

        public DatabaseService()
        {
            CreateDatabase();
            CreateTableWithData();
            noteList = GetAllNotes().ToList();
        }

        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "notesDb.db3");
            db = new SQLiteConnection(dbPath);
        }

        public void AddNote(Notes note)
        {
            note.Title = "";
            note.Note = "";
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

        public void DeleteNote(int id)
        {
            var note = new Notes();
            note.Id = id;
            db.Delete(note);
        }

        public void CreateTableWithData()
        {
            db.CreateTable<Notes>();
            if (db.Table<Notes>().Count() == 0)
            {
                var newNotes = new Notes();
                newNotes.Title = "noteTitle1";
                newNotes.Note = "noteContent1";
                db.Insert(newNotes);
                newNotes.Title = "noteTitle2";
                newNotes.Note = "noteContent2";
                db.Insert(newNotes);
            }
        }
    }
}