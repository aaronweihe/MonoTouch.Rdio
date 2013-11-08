// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace MonoTouch.Rdio.Sample
{
	[Register ("HelloView")]
	partial class HelloView
	{
		[Outlet]
		public MonoTouch.UIKit.UIButton btnPlay { get; private set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnPlay != null) {
				btnPlay.Dispose ();
				btnPlay = null;
			}
		}
	}
}
