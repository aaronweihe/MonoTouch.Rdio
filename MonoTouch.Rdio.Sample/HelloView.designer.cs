// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace MonoTouch.Rdio.Sample
{
	[Register ("HelloView")]
	partial class HelloView
	{
		[Outlet]
		public MonoTouch.UIKit.UIButton btnPlay { get; set; }

		[Outlet]
		public MonoTouch.UIKit.UIButton btnLogin { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnPlay != null) {
				btnPlay.Dispose ();
				btnPlay = null;
			}

			if (btnLogin != null) {
				btnLogin.Dispose ();
				btnLogin = null;
			}
		}
	}
}
