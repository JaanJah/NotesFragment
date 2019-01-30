﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using System;

namespace NotesFragment
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public Bundle _savedInstanceState { get; set; }
        public static MainActivity _mainActivity { get; set; }
        //TODO: When showing note's content, it should also show title.
        //TODO: Toolbar button for adding a note.
        //TODO: Toolbar button for editing a note.
        //TODO: Color solution for project.
        //TODO: Icon for project.
        //TODO: Splash screen for project.
        //TODO: Upload to appcenter
        protected override void OnCreate(Bundle savedInstanceState)
        {
            _mainActivity = this;
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            DatabaseService.dbConnection = new DatabaseService();

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Notebook";
            _mainActivity = this;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                //Add
                case Resource.Id.menu_add:
                    break;
                //Edit
                case Resource.Id.menu_edit:
                    break;
                //Delete
                case Resource.Id.menu_delete:
                    DeleteDialog();
                    break;
                default:
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        public void DeleteDialog()
        {
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Warning");
            alert.SetMessage("Are you sure you want to delete this note?");
            alert.SetButton("Delete", (c, ev) =>
            {
                DatabaseService.dbConnection.DeleteNote(DatabaseService.noteList[PlayNoteFragment.StaticPlayId].Id);
                DatabaseService.noteList.RemoveAt(PlayNoteFragment.StaticPlayId);
                this.Recreate();
            });
            alert.SetButton2("Cancel", (c, ev) =>
            {
                return;
            });
            alert.Show();
        }

    }
}