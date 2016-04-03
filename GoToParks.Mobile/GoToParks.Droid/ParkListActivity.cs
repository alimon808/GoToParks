using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GoToParks.Core;
using GoToParks.Core.Service;
using GoToParks.Droid.Adapter;

namespace GoToParks.Droid
{

    [Activity(Label = "Seattle Parks", MainLauncher = true)]
    public class ParkListActivity : Activity
    {
        private ListView parkListView;
        private List<Park> allParks;
        private ParkDataService parkDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ParkListView);
            parkListView = FindViewById<ListView>(Resource.Id.parkListView);
            parkDataService = new ParkDataService();
            allParks = parkDataService.GetAllParks();
            parkListView.Adapter = new ParkListAdapter(this, allParks);
            parkListView.FastScrollEnabled = true;
        }
    }
}