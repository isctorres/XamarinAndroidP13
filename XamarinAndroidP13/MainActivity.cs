using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Animation;
using Android.Views.Animations;

namespace XamarinAndroidP13
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
          
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_practica, menu);

            IMenuItem item = menu.FindItem(Resource.Id.configuracion);
            View view = LayoutInflater.Inflate(Resource.Layout.layout_menu, null);
            item.SetActionView(view);
            var itemView = item.ActionView.JavaCast<Android.Widget.RelativeLayout>();

            /*ObjectAnimator objectAnimator = ObjectAnimator.OfInt(itemView, "width", 300, 250, 300);
            objectAnimator.SetDuration(3000);
            objectAnimator.SetInterpolator(new LinearInterpolator());
            objectAnimator.RepeatCount = 100;
            objectAnimator.Start();*/


            Animation rotation = AnimationUtils.LoadAnimation(ApplicationContext,
                                               Resource.Animator.rotate_refresh);
            rotation.RepeatCount = Animation.Infinite;
            itemView.StartAnimation(rotation);
            return base.OnCreateOptionsMenu(menu);
        }
    }
}