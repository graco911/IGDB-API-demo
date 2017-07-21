using Android.App;
using Android.Widget;
using Android.OS;
using SAL;
using System.Collections.Generic;
using Entities;
using CustomAdapter;
using Android.Content;
using Newtonsoft.Json;

namespace IGDB_demo_client
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ServiceClient serviceclient = new ServiceClient();
        List<Game> listajuegos;
        GamesAdapter adapter;
        ProgressDialog progress;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            Button buscarjuego = FindViewById<Button>(Resource.Id.buttonBuscar);
            EditText nombrejuego = FindViewById<EditText>(Resource.Id.editTextGame);
            ListView lista = FindViewById<ListView>(Resource.Id.listViewGames);

            progress = new Android.App.ProgressDialog(this);
            progress.Indeterminate = true;
            progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);
            progress.SetMessage("Espere...");
            progress.SetCancelable(false);

            buscarjuego.Click += async delegate 
            {
                progress.Show();
                listajuegos = await serviceclient.GetGamesAsync(nombrejuego.Text);
                if (listajuegos.Count > 0)
                {
                    adapter = new GamesAdapter(this, listajuegos, Resource.Layout.listview_item, Resource.Id.textViewGameName, Resource.Id.textViewIdGame, Resource.Id.imageViewGame);
                    lista.Adapter = adapter;
                    progress.Hide();
                }
                else
                {
                    Toast.MakeText(this, "Error", ToastLength.Long).Show();
                    progress.Hide();
                }

            };

            lista.ItemClick += Lista_ItemClick;
        }

        private async void Lista_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            progress.Show();
            var detailgame = await serviceclient.GetGameDetailAsync(listajuegos[e.Position].id);
            var intent = new Intent(this, typeof(GameDetailActivity));

            if (detailgame != null)
            {
                intent.PutExtra("detailgame", JsonConvert.SerializeObject(detailgame));
                progress.Hide();
                StartActivity(intent);
            }
        }
    }
}

