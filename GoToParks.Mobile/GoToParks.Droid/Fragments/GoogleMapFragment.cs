using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using GoToParks.Core;
using GoToParks.Core.Service;

namespace GoToParks.Droid.Fragments
{
    public class GoogleMapFragment : BaseFragment
    {
        private GoogleMap googleMap;
        private MapFragment mapFragment;
        private LatLng seattleLocation;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            seattleLocation = new LatLng(47.636477, -122.294835);
            parks = dataService.GetAllParks();
            CreateMapFragment();
            UpdateMapView();
        }

        private void CreateMapFragment()
        {
            mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
            if (mapFragment == null)
            {
                var googleMapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeNormal)
                    .InvokeZoomControlsEnabled(true)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
                mapFragment = MapFragment.NewInstance(googleMapOptions);
                fragmentTransaction.Add(Resource.Id.mapFrameLayout, mapFragment, "map");
                fragmentTransaction.Commit();
            }
        }

        private void UpdateMapView()
        {
            var mapReadyCallback = new LocalMapReady();
            List<Park> parks = dataService.GetAllParks();
            mapReadyCallback.MapReady += (sender, args) =>
            {
                googleMap = (sender as LocalMapReady).Map;
                if (googleMap != null)
                {
                    foreach (var park in parks)
                    {
                        LatLng location = new LatLng(park.Lat, park.Long);
                        MarkerOptions markerOptions = new MarkerOptions();
                        markerOptions.SetPosition(location)
                                     .SetTitle(park.Id.ToString())
                                     .SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.tree16));

                        googleMap.AddMarker(markerOptions);
                    }

                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(seattleLocation, 12);
                    googleMap.MoveCamera(cameraUpdate);
                    googleMap.MarkerClick += MapOnMarkerClick;
                }
            };

            mapFragment.GetMapAsync(mapReadyCallback);
        }

        private class LocalMapReady : Java.Lang.Object, IOnMapReadyCallback
        {
            public GoogleMap Map { get; private set; }
            public event EventHandler MapReady;
            public void OnMapReady(GoogleMap googleMap)
            {
                Map = googleMap;
                var handler = MapReady;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
        private void MapOnMarkerClick(object sender, GoogleMap.MarkerClickEventArgs markerClickEventArgs)
        {
            markerClickEventArgs.Handled = false;
            Marker marker = markerClickEventArgs.Marker;
            googleMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(marker.Position, 15));

            InfoWindow infoWindow = new InfoWindow(Activity.LayoutInflater);
            googleMap.SetInfoWindowAdapter(infoWindow);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.GoogleMapFragment, container, false);
        }
    }
}