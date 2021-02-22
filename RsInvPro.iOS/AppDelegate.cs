
using Foundation;
using Syncfusion.SfDataGrid.XForms.iOS;
using Syncfusion.XForms.iOS.DataForm;
using Syncfusion.XForms.iOS.TabView;
using UIKit;

namespace RsInvPro.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzk5Njc2QDMxMzgyZTM0MmUzMGVKYy9WMUNnYlF4MWc5T0FWTG0vcVFydmplcXcxSW1KNkRVb2x3bFVTbFE9");

            //SQLitePCL.Batteries_V2.Init();
            global::Xamarin.Forms.Forms.Init();
            SfDataGridRenderer.Init();
            SfTabViewRenderer.Init();
            SfDataFormRenderer.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
