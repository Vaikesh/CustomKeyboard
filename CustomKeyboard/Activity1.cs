using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Android.OS;
using Android.InputMethodServices;
using Android.Webkit;
using Java.Lang;
using Android.Util;

namespace CustomKeyboard
{
	[Activity (Label = "CustomKeyboard", MainLauncher = true)]
	public class Activity1 : Activity
	{
		public CustomKeyboardView mKeyboardView;
		public View mTargetView;
		public Keyboard mKeyboard;
		protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mKeyboard = new Keyboard(this, Resource.Xml.keyboard2);
            mTargetView = (EditText)FindViewById(Resource.Id.target);

            mKeyboardView = (CustomKeyboardView)FindViewById(Resource.Id.keyboard_view);
            mKeyboardView.Keyboard = mKeyboard;

            mTargetView.Touch += (sender, e) => {
                Log.Info("onTouch", "true");
                ShowKeyboardWithAnimation();
                e.Handled = true;
            };

            mKeyboardView.Key += (sender, e) => {
                long eventTime = JavaSystem.CurrentTimeMillis();
                KeyEvent ev = new KeyEvent(eventTime, eventTime, KeyEventActions.Down, e.PrimaryCode, 0, 0, 0, 0, KeyEventFlags.SoftKeyboard | KeyEventFlags.KeepTouchMode);
        
                this.DispatchKeyEvent(ev);
            };
		}
		
		public void ShowKeyboardWithAnimation()
        {
            Log.Info("keyboardState", mKeyboardView.Visibility.ToString());
            if (mKeyboardView.Visibility == ViewStates.Gone)
            {
                Animation animation = AnimationUtils.LoadAnimation(
                    this,
                    Resource.Animation.slide_in_bottom
                );
                mKeyboardView.ShowWithAnimation(animation);
			}
		}
	}
}


