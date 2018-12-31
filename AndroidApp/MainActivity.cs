using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidApp
{
	[Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);

			button.Click += delegate { button.Text = $"{count++} clicks!"; };

			var Helper = new SharedProject.MySharedCode();
			new AlertDialog.Builder(this).SetMessage(Helper.GetFilePath("demo.dat")).Show();
			Validate();
		}
		private async void Validate()
		{
			var ServiceClient = new SALLab03.ServiceClient();
			string StudentEmail = "francisco_renan-dt@hotmail.com";
			string Password = "zxxzpa6413";
			string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver,Android.Provider.Settings.Secure.AndroidId);
			var Result = await ServiceClient.ValidateAsync(StudentEmail,Password,myDevice);
			Android.App.AlertDialog.Builder Builder = new AlertDialog.Builder(this);
			AlertDialog Alert = Builder.Create();
			Alert.SetTitle("Resultado de verificacion");
			//Alert.SetIcon(Resource.Drawable.notification_template_icon_bg);
			Alert.SetMessage($"{Result.Status}\n{Result.Fullname})\n{Result.Token}");
			Alert.SetButton("OK", (s, ev) => { });
			Alert.Show();
		}
	}
}

