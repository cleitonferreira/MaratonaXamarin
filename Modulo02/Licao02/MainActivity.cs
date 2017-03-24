﻿using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace Licao02
{
    [Activity(Label = "Licao02", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        double IngresosM, IngresosC, EgresosM, EgresosC, CapitalM, CapitalC;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button btnCalcular = FindViewById<Button>(Resource.Id.btncalcular);
            EditText txtIngresosM = FindViewById<EditText>(Resource.Id.txtingresosM);
            EditText txtIngresosC = FindViewById<EditText>(Resource.Id.txtingresosC);
            EditText txtEgresosM = FindViewById<EditText>(Resource.Id.txtegresosM);
            EditText txtEgresosC = FindViewById<EditText>(Resource.Id.txtegresosC);

            btnCalcular.Click += delegate
            {
                try
                {
                    IngresosM = double.Parse(txtIngresosM.Text);
                    IngresosC = double.Parse(txtIngresosC.Text);
                    EgresosM = double.Parse(txtEgresosM.Text);
                    EgresosC = double.Parse(txtEgresosC.Text);
                    CapitalM = IngresosM - EgresosM;
                    CapitalC = IngresosC - EgresosC;
                    Cargar();

                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                }
            };
            
        }

        public void Cargar()
        {
            Intent objIntent = new Intent(this, typeof(VistaCapital));
            objIntent.PutExtra("CapitalM", CapitalM);
            objIntent.PutExtra("CapitalC", CapitalC);
            StartActivity(objIntent);
        }
    }
}

