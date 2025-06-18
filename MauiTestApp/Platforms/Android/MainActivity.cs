using Android.App;
using Android.Content.PM;
using Android.OS;
using Com.Stripe.Android;
using Com.Stripe.Android.Googlepaylauncher;
using CommunityToolkit.Mvvm.Messaging;

namespace MauiTestApp;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{

    GooglePayPaymentMethodLauncher googlePayLauncher;
    const string PUBLISHABLE_KEY = "pk_test_xxxxx";
    bool IsGooglePayReady;
    long amount = 1000;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        WeakReferenceMessenger.Default.Register<PayViaGooglePayMessage>(this, (recipient, message) =>
        {
            googlePayLauncher.Present("USD", amount);
        });

        var readyCallback = new GooglePayReadyCallback(OnGooglePayReady);
        var resultCallback = new GooglePayResultCallback(OnGooglePayResult);

        PaymentConfiguration.Init(this, PUBLISHABLE_KEY);

        googlePayLauncher = new GooglePayPaymentMethodLauncher(
            activity: this,
            config: new GooglePayPaymentMethodLauncher.Config(
                environment: GooglePayEnvironment.Test,
                merchantCountryCode: "US",
                merchantName: "merchantName"
            ),
            readyCallback: readyCallback,
            resultCallback: resultCallback
        );
    }

    private void OnGooglePayReady(bool isGooglePayReady)
    {
        IsGooglePayReady = isGooglePayReady;
    }

    private void OnGooglePayResult(GooglePayPaymentMethodLauncher.Result result)
    {
        if (result is GooglePayPaymentMethodLauncher.Result.Completed completed)
        {
            var token = completed.PaymentMethod.id_;
        }
         else if (result is GooglePayPaymentMethodLauncher.Result.Canceled)
        {
            // Handle cancellation
        }
        else if (result is GooglePayPaymentMethodLauncher.Result.Failed failedResult)
        {
            // Handle failure
        }
    }
}


public class GooglePayReadyCallback : Java.Lang.Object, GooglePayPaymentMethodLauncher.IReadyCallback
{
    private readonly Action<bool> _onReady;
    public GooglePayReadyCallback(Action<bool> onReady) =>  _onReady = onReady;
    public void OnReady(bool isReady) =>  _onReady?.Invoke(isReady);
}

public class GooglePayResultCallback : Java.Lang.Object, GooglePayPaymentMethodLauncher.IResultCallback
{
    private readonly Action<GooglePayPaymentMethodLauncher.Result> _onResult;
    public GooglePayResultCallback( Action<GooglePayPaymentMethodLauncher.Result> onResult) => _onResult = onResult;
    public void OnResult(GooglePayPaymentMethodLauncher.Result result) => _onResult(result);
}