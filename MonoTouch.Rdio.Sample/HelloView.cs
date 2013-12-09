using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Rdio;

namespace MonoTouch.Rdio.Sample
{
	public partial class HelloView : UIViewController
	{
		Rdio rdio;
		
		public HelloView()
			: base("HelloView", null)
		{
			rdio = new Rdio ("", "", null);
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			btnPlay.TouchDown += (sender, e) => {
				var player =rdio.Player;
				player.PlaySource ("a997982");
			};
		}
	}
}

