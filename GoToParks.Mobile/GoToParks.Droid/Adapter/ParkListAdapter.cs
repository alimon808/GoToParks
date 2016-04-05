using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using GoToParks.Core;

namespace GoToParks.Droid.Adapter
{
    public class ParkListAdapter : BaseAdapter<Park>
    {
        List<Park> items;
        Activity context;

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override Park this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public ParkListAdapter(Activity context, List<Park> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.ParkListRowView, null);
            }
            convertView.FindViewById<TextView>(Resource.Id.parkNameTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.parkHoursTextView).Text = item.Hours;
            return convertView;
        }
    }
}