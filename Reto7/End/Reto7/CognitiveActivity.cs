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
using Emotions;
using System.IO;
using Plugin.Media.Abstractions;


namespace Reto6
{
    [Activity(Label = "Cognitive Services")]
    public class CognitiveActivity : Activity
    {

        ItemManager manager;
        static Stream streamCopy;
        string ResultadoEmociones = "Reto6 + MX + Luis: ";
        TextView txtResultado;
        Button btnRegistraResultados;
        Button btnAnalizaFoto;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            manager = ItemManager.DefaultManager;
            SetContentView(Resource.Layout.Cognitive);

            Button btnCamara = FindViewById<Button>(Resource.Id.btnCamara);
            btnAnalizaFoto = FindViewById<Button>(Resource.Id.btnAnalizaFoto);
            btnRegistraResultados = FindViewById<Button>(Resource.Id.btnRegistraResultados);
            txtResultado = FindViewById<TextView>(Resource.Id.txtOutput);

            btnRegistraResultados.Visibility = ViewStates.Invisible;
            btnAnalizaFoto.Visibility = ViewStates.Invisible;
            btnCamara.Click += BtnCamara_Click;
            btnAnalizaFoto.Click += BtnAnalizaFoto_Click;
            btnRegistraResultados.Click += BtnRegistraResultados_Click;
        }

        private async void BtnRegistraResultados_Click(object sender, EventArgs e)
        {
            btnRegistraResultados.Visibility = ViewStates.Invisible;
            Toast.MakeText(this, "Registrando tus resultados", ToastLength.Short).Show();
            TorneoItem registro = new TorneoItem();
            registro.DeviceId = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            registro.Email = "lruval@microsoft.com";
            registro.Reto = ResultadoEmociones;
            await manager.SaveTaskAsync(registro);
        }
        private async void BtnAnalizaFoto_Click(object sender, EventArgs e)
        {
            if (streamCopy != null)
            {
                btnAnalizaFoto.Visibility = ViewStates.Invisible;
                Toast.MakeText(this, "Analizando imagen utilizando Cognitive Services", ToastLength.Short).Show();
                Dictionary<string, float> emotions = null;
                try
                {
                    streamCopy.Seek(0, SeekOrigin.Begin);

                  //  emotions = await ServiceEmotions.GetEmotions(streamCopy);
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, "Se ha presentado un error al conectar con los servicios", ToastLength.Short).Show();
                    return;
                }
                StringBuilder sb = new StringBuilder();

                if (emotions != null)
                {
                    txtResultado.Text = "---Análisis de Emociones---";
                    sb.AppendLine();
                    foreach (var item in emotions)
                    {
                        string toAdd = item.Key + " : " + item.Value + " ";
                        sb.Append(toAdd);
                    }
                    txtResultado.Text += sb.ToString();
                    btnRegistraResultados.Visibility = ViewStates.Visible;
                }
                else txtResultado.Text = "---No se detectó una cara---";
                ResultadoEmociones += sb.ToString();
            }
            else txtResultado.Text = "---No has seleccionado una imagen---";
        }

        private async void BtnCamara_Click(object sender, EventArgs e)
        {
            MediaFile file = null;
            try
            {
                file = await ServiceImage.TakePicture(true);
            }
            catch (Android.OS.OperationCanceledException)
            {
            }
            SetImageToControl(file);
            btnAnalizaFoto.Visibility = ViewStates.Visible;
        }

        private void SetImageToControl(MediaFile file)
        {
            if (file == null)
            {
                return;
            }
            ImageView imgImage = FindViewById<ImageView>(Resource.Id.imageViewFoto);
            imgImage.SetImageURI(Android.Net.Uri.Parse(file.Path));
            var stream = file.GetStream();
            streamCopy = new MemoryStream();
            stream.CopyTo(streamCopy);
            stream.Seek(0, SeekOrigin.Begin);
            file.Dispose();
        }


    }
}