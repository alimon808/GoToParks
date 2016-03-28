using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace GoToParks.Droid
{
    [Activity(Label = "GoToParks", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private GoogleMap googleMap;
        private FrameLayout mapFrameLayout;
        private MapFragment mapFragment;
        private LatLng seattleLocation;
        private Button externalMapButton;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            seattleLocation = new LatLng(47.636477, -122.294835);
            SetContentView(Resource.Layout.Main);

            FindViews();
            HandleEvents();
            //Android.Net.Uri seattleLocationUri = Android.Net.Uri.Parse("geo:47.636477,-122.294835");

            //Intent mapIntent = new Intent(Intent.ActionView, seattleLocationUri);
            
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
                    .InvokeMapType(GoogleMap.MapTypeSatellite)
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
            mapReadyCallback.MapReady += (sender, args) =>
            {
                googleMap = (sender as LocalMapReady).Map;
                if (googleMap != null)
                {
                    MarkerOptions markerOptions = new MarkerOptions();
                    markerOptions.SetPosition(seattleLocation);
                    markerOptions.SetTitle("Seattle");
                    googleMap.AddMarker(markerOptions);

                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(seattleLocation, 15);
                    googleMap.MoveCamera(cameraUpdate);
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
    }
}

