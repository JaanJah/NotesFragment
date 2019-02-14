using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace NotesFragment
{
    [Activity(Label = "", Theme = "@style/AppTheme.NoActionBar")]
    public class PlayNoteActivity : AppCompatActivity
    {
        private int PlayId { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape)
                Finish();

            DatabaseService.dbConnection = new DatabaseService();
            SetContentView(Resource.Layout.note_view);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar2);
            SetSupportActionBar(toolbar);
            PlayId = Intent.Extras.GetInt("current_play_id", 0);

            var titleText = FindViewById<EditText>(Resource.Id.titleEditText);
            titleText.Text = DatabaseService.noteList[PlayId].Title;

            var contentText = FindViewById<EditText>(Resource.Id.contentEditText);
            contentText.Text = DatabaseService.noteList[PlayId].Note;
            //var detailsFrag = PlayNoteFragment.NewInstance(playId);
            //FragmentManager.BeginTransaction()
            //    .Add(Android.Resource.Id.Content, detailsFrag)
            //    .Commit();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return true;
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
                DatabaseService.dbConnection.DeleteNote(DatabaseService.noteList[PlayId].Id);
                DatabaseService.noteList.RemoveAt(PlayId);
                MainActivity._mainActivity.Recreate();
                Finish();
            });
            alert.SetButton2("Cancel", (c, ev) =>
            {
                return;
            });
            alert.Show();
        }

    }
}