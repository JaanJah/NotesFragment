﻿using System;
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
    public class PlayNoteFragment : Fragment
    {
        public int PlayId => Arguments.GetInt("current_play_id", 0);

        public static int StaticPlayId { get; set; }

        DatabaseService dbService;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            dbService = new DatabaseService();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                return null;
            }
            var notes = DatabaseService.dbConnection.GetAllNotes();
            StaticPlayId = PlayId;
            List<string> titlesList = DatabaseService.noteList.Select(x => x.Title).ToList();
            List<string> notesList = DatabaseService.noteList.Select(x => x.Note).ToList();
            var titleTextView = new TextView(Activity);
            var contentTextView = new TextView(Activity);
            var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));

            titleTextView.SetPadding(padding, padding, padding, padding);
            titleTextView.TextSize = 24;

            contentTextView.SetPadding(padding, padding, padding, padding);
            contentTextView.TextSize = 24;
            try
            {
                titleTextView.Text = titlesList[PlayId];
                contentTextView.Text = notesList[PlayId];
            }
            catch
            {
                titleTextView.Text = titlesList[0];
                contentTextView.Text = notesList[0];
            }

            var linearLayout = new LinearLayout(Activity);
            linearLayout.Orientation = Orientation.Vertical;
            linearLayout.AddView(titleTextView);
            linearLayout.AddView(contentTextView);

            var scroller = new ScrollView(Activity);
            scroller.AddView(linearLayout);

            return scroller;
        }

        public static PlayNoteFragment NewInstance(int playId)
        {
            var bundle = new Bundle();
            bundle.PutInt("current_play_id", playId);
            return new PlayNoteFragment { Arguments = bundle };
        }
    }
}