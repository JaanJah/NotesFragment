﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;

namespace NotesFragment
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //TODO: When showing note's content, it should also show title.
        //TODO: Toolbar button for adding a note.
        //TODO: Toolbar button for deleteing a note.
        //TODO: Toolbar button for editing a note.
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            DatabaseService dbService = new DatabaseService();
            dbService.CreateTableWithData();

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Notebook";
        }
    }
}