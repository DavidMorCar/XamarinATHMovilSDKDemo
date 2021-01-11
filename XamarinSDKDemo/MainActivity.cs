using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Evertecinc.Athmovil.Sdk.Checkout;
using Com.Evertecinc.Athmovil.Sdk.Checkout.Objects;

namespace XamarinSDKDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.AppCompatImageButton button = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.btnATHMCheckout);
            button.Click += (sender, e) => {
                onClickPayButton();
            };
            items.Add(new Items("Ssd", "(8oz)        ", (Java.Lang.Double)1.0, (Java.Lang.Long)2L, null));
            items.Add(new Items("Coca Cola", "(68oz)", (Java.Lang.Double)0.75, (Java.Lang.Long)1L, "expiration 0820"));
        }

        List<Items> items = new List<Items>();

        // Production functionality, provide correct data...
        public void onClickPayButton()
        {
            ATHMPayment payment = new ATHMPayment(this);
            payment.PublicToken= "933OH0Y08SFD7QEN2QJH6YD4RSKZZS7YAL0IUY0F";
            payment.Total = 6;
            payment.Metadata1 = "test";
            payment.Metadata2 = "test2";
            payment.CallbackSchema = "com.evertecinc.xamarinsdkdemo.ResponseActivity";
            payment.Items = items;
            payment.Subtotal = 5;
            payment.Tax = 1;
            payment.Timeout = 600;
            payment.BuildType = ".qa";

            sendData(payment);
        }

        private void sendData(ATHMPayment ATHMPayment)
        {
            try
            {
                OpenATHM.ValidateData(ATHMPayment);

            }
            catch (Exception e)
            {
                Toast.MakeText(this, e.Message, ToastLength.Long).Show();
            }
        }
    }
}
