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

namespace GoToParks.Droid
{
    [Activity(Label = "Park Detail", MainLauncher = false)]
    public class ParkDetailActivity : Activity
    {
        private TextView parkNameTextView;
        private Park selectedPark;
        private ParkDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ParkDetailView);

            dataService = new ParkDataService();
            var selectedParkId = Intent.Extras.GetInt("selectedParkId");
            selectedPark = dataService.GetParkById(selectedParkId);

            FindViews();
            BindData();
        }

        private void BindData()
        {
            parkNameTextView.Text = selectedPark.Name;
        }

        private void FindViews()
        {
            parkNameTextView = FindViewById<TextView>(Resource.Id.parkNameTextView);
        }
    }
}