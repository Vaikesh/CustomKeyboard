using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Views.InputMethods;
using Android.Widget;
using Android.InputMethodServices;
using Android.Util;
using Java.Lang;

namespace CustomKeyboard
{
	public class CustomKeyboardView: KeyboardView
	{
		public CustomKeyboardView(Context context,IAttributeSet attrs): base(context,attrs)
		{
		}
		
		public void ShowWithAnimation(Animation animation)
        {
            animation.AnimationEnd += (sender, e) => {
                Console.WriteLine("Set visibility!");
                Visibility = ViewStates.Visible;
            };

            Animation = animation;
		}
		
		
	}
}

