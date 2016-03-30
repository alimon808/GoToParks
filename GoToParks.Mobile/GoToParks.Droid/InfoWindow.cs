using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Views;
using Android.Widget;
using GoToParks.Core;

namespace GoToParks.Droid
{
    public class InfoWindow : Java.Lang.Object, GoogleMap.IInfoWindowAdapter
    {
        LayoutInflater inflater = null;
        ParkRepository parkRepository = null;
        public InfoWindow(LayoutInflater inflater)
        {
            this.inflater = inflater;
            this.parkRepository = new ParkRepository();
        }

        public View GetInfoContents(Marker marker)
        {
            Park park = parkRepository.GetParkById(Int32.Parse(marker.Title));
            View popup = inflater.Inflate(Resource.Layout.InfoWindow, null);
            TextView title = popup.FindViewById<TextView>(Resource.Id.titleTextView);
            title.Text = park.Name;

            TextView address = popup.FindViewById<TextView>(Resource.Id.addressTextView);
            address.Text = park.Address;


            TextView hours = popup.FindViewById<TextView>(Resource.Id.hoursTextView);
            hours.Text = park.Hours;

            return popup;
        }

        public View GetInfoWindow(Marker marker)
        {
            return null;
        }
    }
}