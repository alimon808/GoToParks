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
using GoToParks.Core;
using GoToParks.Core.Service;

namespace GoToParks.Droid.Fragments
{
    public class BaseFragment : Fragment
    {
        protected ListView listView;
        protected ParkDataService dataService;
        protected List<Park> parks;

        public BaseFragment()
        {
            dataService = new ParkDataService();
        }

        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }

        protected void FindViews()
        {
            listView = this.View.FindViewById<ListView>(Resource.Id.parkListView);
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var park = parks[e.Position];
            var intent = new Intent();
            intent.SetClass(this.Activity, typeof(ParkDetailActivity));
            intent.PutExtra("selectedParkId", park.Id);
            StartActivityForResult(intent, 100);
        }
    }
}