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
using Entities;
using Newtonsoft.Json;
using Square.Picasso;

namespace IGDB_demo_client
{
    [Activity(Label = "GameDetailActivity")]
    public class GameDetailActivity : Activity
    {
        List<GameDetailInfo> lista = new List<GameDetailInfo>();
        TextView gamename;
        TextView summary;
        ImageView img;
        Button buttonvideo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.game_detail);
            gamename = FindViewById<TextView>(Resource.Id.textViewGameTitle);
            summary = FindViewById<TextView>(Resource.Id.textViewSummary);
            img = FindViewById<ImageView>(Resource.Id.imageViewGameCover);
            buttonvideo = FindViewById<Button>(Resource.Id.buttonVideo);

            lista = JsonConvert.DeserializeObject<List<GameDetailInfo>>(Intent.GetStringExtra("detailgame"));

            gamename.Text = lista[0].name;
            summary.Text = lista[0].summary;

            buttonvideo.Enabled = false;

            buttonvideo.Click += delegate
            {
                StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse(string.Format("http://www.youtube.com/watch?v={0}", lista[0].videos[0].video_id))));

            };

            if (lista[0].cover != null)
            {
                Picasso.With(this).Load(string.Format("https://images.igdb.com/igdb/image/upload/t_cover_big/{0}.jpg", lista[0].cover.cloudinary_id)).Into(img);
            }
            else
            {
                Picasso.With(this).Load("https://lh3.googleusercontent.com/XO8m2QiuEU3hHIHcWlS29XxUhnMXj3fU_hU8WbR100-57ypK5A_6RNIXPOdYu-EyNVRS").Into(img);

            }

            if(lista[0].videos != null)
            {
                buttonvideo.Enabled = true;
            }



        }
    }
}