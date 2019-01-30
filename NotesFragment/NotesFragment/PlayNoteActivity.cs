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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape)
                Finish();

            SetContentView(Resource.Layout.note_view);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar2);
            SetSupportActionBar(toolbar);
            var playId = Intent.Extras.GetInt("current_play_id", 0);

            var editText = FindViewById<EditText>(Resource.Id.contentEditText);
            editText.Text = DatabaseService.noteList[playId].Note;
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
                    break;
                default:
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}