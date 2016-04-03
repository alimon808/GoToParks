using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using GoToParks.Core.Service;
using GoToParks.Core;
using System.Collections.Generic;
using static Android.Gms.Maps.GoogleMap;

namespace GoToParks.Droid
{
    [Activity(Label = "GoToParks", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private GoogleMap googleMap;
        private FrameLayout mapFrameLayout;
        private MapFragment mapFragment;
        private LatLng seattleLocation;
        private Button externalMapButton;
        private ParkDataService parkDataService;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            seattleLocation = new LatLng(47.636477, -122.294835);
            SetContentView(Resource.Layout.Main);
            parkDataService = new ParkDataService();
            FindViews();
            HandleEvents();
            CreateMapFragment();
            UpdateMapView();
        }

        private void HandleEvents()
        {
            externalMapButton.Click += ExternalMapButton_Click;
        }

        private void FindViews()
        {
            externalMapButton = FindViewById<Button>(Resource.Id.externalMapButton);
        }
        private void ExternalMapButton_Click(object sender, EventArgs e)
        {
            Android.Net.Uri rayLocationUri = Android.Net.Uri.Parse("geo:50.846704,4.352446");
            Intent mapIntent = new Intent(Intent.ActionView, rayLocationUri);
            StartActivity(mapIntent);
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
            List<Park> parks = parkDataService.GetAllParks();
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
                    googleMap.MarkerClick += MapOnMarkerClick; ;
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

            InfoWindow infoWindow = new InfoWindow(LayoutInflater);
            googleMap.SetInfoWindowAdapter(infoWindow);
        }
    }
}

