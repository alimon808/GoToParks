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
        private ParkDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ParkListView);
            parkListView = FindViewById<ListView>(Resource.Id.parkListView);
            dataService = new ParkDataService();
            allParks = dataService.GetAllParks();
            parkListView.Adapter = new ParkListAdapter(this, allParks);
            parkListView.FastScrollEnabled = true;

            parkListView.ItemClick += ParkListView_ItemClick;
        }

        private void ParkListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var park = allParks[e.Position];
            var intent = new Intent();
            intent.SetClass(this, typeof(ParkDetailActivity));
            intent.PutExtra("selectedParkId", park.Id);
            StartActivityForResult(intent, 100);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok && requestCode == 100)
            {
                var selectedPark = dataService.GetParkById(data.GetIntExtra("selectedParkId", 0));
                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Confirmation");
                dialog.SetMessage(string.Format("You've selected {0}", selectedPark.Name));
                dialog.Show();
            }
        }
    }
}