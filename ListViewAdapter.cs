using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace LearnXhosaApp
{
    public class ListViewAdapter : BaseAdapter<Person>
    {
        private List<Person> mItems;
        private Context mContext;

        public ListViewAdapter(Context context, List<Person> list)
        {
            mItems = list;
            mContext = context;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.ListView_row, null, false);
            }

            var txtName = row.FindViewById<TextView>(Resource.Id.txtName);
            txtName.Text = mItems[position].Name;

            var txtSurname = row.FindViewById<TextView>(Resource.Id.txtSurname);
            txtSurname.Text = mItems[position].Surname;

            var txtAge = row.FindViewById<TextView>(Resource.Id.txtAge);
            txtAge.Text = mItems[position].Age;

            var txtGender = row.FindViewById<TextView>(Resource.Id.txtGender);
            txtGender.Text = mItems[position].Gender;

            return row;
        }

        public override int Count => mItems.Count;

        public override Person this[int position] => mItems[position];
    }
}