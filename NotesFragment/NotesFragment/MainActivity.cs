using Android.App;
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
        //TODO: When showing note's content, it should also show title.
        //TODO: Toolbar in singlefragment view
        //TODO: Toolbar button for adding a note.
        //TODO: Toolbar button for deleteing a note.
        //TODO: Toolbar button for editing a note.
        //TODO: Color solution for project.
        //TODO: Icon for project.
        //TODO: Splash screen for project.
        //TODO: Upload to appcenter
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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            switch (item.ItemId)
            {
                //Add
                case 2131230900:
                    break;
                //Edit
                case 2131230901:
                    break;
                //Delete
                case 2131230902:
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
                //Delete note
            });
            alert.SetButton2("Cancel", (c, ev) =>
            {
                //Cancel
            });
            alert.Show();
        }

    }
}