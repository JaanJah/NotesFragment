using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace NotesFragment
{
    public class TitlesFragment : ListFragment
    {
        int selectedPlayId;
        bool showingTwoFragments;
        DatabaseService dbService;
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            var noteContainer = Activity.FindViewById(Resource.Id.playnote_container);
            showingTwoFragments = noteContainer != null && noteContainer.Visibility == ViewStates.Visible;
            if (showingTwoFragments)
            {
                ListView.ChoiceMode = ChoiceMode.Single;
                ShowPlayNote(selectedPlayId);
            }

            var notes = dbService.GetAllNotes();
            var arrayLength = notes.Count();
            string[] titles = new string[arrayLength];
            foreach (var item in notes)
            {
                titles.Append(item.Title);
            }

            ListAdapter = new ArrayAdapter<string>(Activity,
                Android.Resource.Layout.SimpleListItemActivated1,
                titles);

            if (savedInstanceState != null)
                selectedPlayId = savedInstanceState.GetInt("current_play_id", 0);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        private void ShowPlayNote(int playId)
        {

        }
    }
}