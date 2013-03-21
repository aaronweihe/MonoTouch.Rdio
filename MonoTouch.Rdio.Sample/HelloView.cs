using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Rdio;

namespace MonoTouch.Rdio.Sample
{
    public partial class HelloView : UIViewController
    {
        public bool IsLoggedIn = false;
        public Rdio MyRdio = new Rdio();

        public HelloView()
            : base("HelloView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            btnLogin.TouchDown += (sender, e) =>
            {
                var del = new MyRdioDelegate(this);
                //Initialize Rdio with your consumer key and secret
                MyRdio.InitWithConsumerKeyandSecretdelegate("", "", del);

                MyRdio.AuthorizeFromController(this);

            };

            btnPlay.TouchDown += (sender, e) =>
                {
                    if (IsLoggedIn) {
                        MyRdio.Player.PlaySource("t2742133");
                    }
                };
        }

    }

    class MyRdioDelegate : RdioDelegate
    {
        private readonly HelloView _view;

        public MyRdioDelegate(HelloView view)
        {
            _view = view;
        }

        public override void RdioAuthorizationCancelled()
        {
            _view.IsLoggedIn = false;
        }

        public override void RdioAuthorizationFailed(string error)
        {
            _view.IsLoggedIn = false;
        }

        public override void RdioDidAuthorizeUserwithAccessToken(NSDictionary user, string accessToken)
        {
            _view.IsLoggedIn = true;
        }
    }
}

