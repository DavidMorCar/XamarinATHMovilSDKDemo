
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
using Com.Evertecinc.Athmovil.Sdk.Checkout.Interfaces;
using Com.Evertecinc.Athmovil.Sdk.Checkout.Objects;
using Java.Util;

namespace XamarinSDKDemo
{
    [Activity(Name = "com.evertecinc.xamarinsdkdemo.ResponseActivity")]
    public partial class ResponseActivity : Activity, IPaymentResponseListener
    {
        TextView tvTransactionStatus = null;
        TextView tvTransactionData = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_response);
            this.tvTransactionStatus = FindViewById<TextView>(Resource.Id.tvTransactionStatus);
            this.tvTransactionData = FindViewById<TextView>(Resource.Id.tvTransactionData);
        }

        public void OnCancelledPayment(Date date, string referenceNumber, string dailyTransactionID,
                                   string name, string phoneNumber, string email,
                                   Java.Lang.Double total, Java.Lang.Double tax, Java.Lang.Double subtotal, Java.Lang.Double fee, Java.Lang.Double netAmount,
                                   String metadata1, String metadata2, IList<Items> items)
        {
            tvTransactionStatus.Text="ATHM_CANCELLED_STATUS";
        }

        public void OnCompletedPayment(Date date, string referenceNumber, string dailyTransactionID,
                                   string name, string phoneNumber, string email,
                                   Java.Lang.Double total, Java.Lang.Double tax, Java.Lang.Double subtotal, Java.Lang.Double fee, Java.Lang.Double netAmount,
                                   String metadata1, String metadata2, IList<Items> items)
        {
            tvTransactionStatus.Text = "ATHM_COMPLETED_STATUS";
        }

        public void OnExpiredPayment(Date date, string referenceNumber, string dailyTransactionID,
                                   string name, string phoneNumber, string email,
                                   Java.Lang.Double total, Java.Lang.Double tax, Java.Lang.Double subtotal, Java.Lang.Double fee, Java.Lang.Double netAmount,
                                   String metadata1, String metadata2, IList<Items> items)
        {
            tvTransactionStatus.Text = "ATHM_EXPIRED_STATUS";
        }

        public void OnPaymentException(string error, string description)
        {
            Toast.MakeText(this, description, ToastLength.Long).Show();
        }
    }
}
