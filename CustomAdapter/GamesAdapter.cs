using System.Collections.Generic;
using Entities;
using Android.App;
using Android.Views;
using Android.Widget;
using Square.Picasso;

namespace CustomAdapter
{
    public class GamesAdapter : BaseAdapter<Game>
    {
        List<Game> GamesList;
        Activity Context;
        int ItemLayoutTemplate;
        int GameTitle;
        int GamePlatform;
        int GamePreview;

        public GamesAdapter(Activity context, List<Game> list, int itemLayoutTemplate, int gametitle, int gameplatform, int imgpreview)
        {
            this.Context = context;
            this.GamesList = list;
            this.ItemLayoutTemplate = itemLayoutTemplate;
            this.GameTitle = gametitle;
            this.GamePlatform = gameplatform;
            this.GamePreview= imgpreview;
        }

        public override Game this[int position]
        {
            get
            {
                return GamesList[position];
            }
        }

        public override int Count
        {
            get
            {
                return GamesList.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return GamesList[position].id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var Item = GamesList[position];
            View ItemView;
            if (convertView == null)
            {
                ItemView = Context.LayoutInflater.Inflate(ItemLayoutTemplate, null);

            }
            else
            {
                ItemView = convertView;
            }

            ItemView.FindViewById<TextView>(GameTitle).Text = Item.name;
            ItemView.FindViewById<TextView>(GamePlatform).Text = Item.id.ToString();
            if (Item.cover != null)
            {
                Picasso.With(Context).Load(string.Format("https://images.igdb.com/igdb/image/upload/t_thumb/{0}.jpg", Item.cover.cloudinary_id)).Into(ItemView.FindViewById<ImageView>(GamePreview));
            }
            else
            {
                Picasso.With(Context).Load("https://lh3.googleusercontent.com/XO8m2QiuEU3hHIHcWlS29XxUhnMXj3fU_hU8WbR100-57ypK5A_6RNIXPOdYu-EyNVRS").Into(ItemView.FindViewById<ImageView>(GamePreview));

            }
            return ItemView;
        }
    }
}