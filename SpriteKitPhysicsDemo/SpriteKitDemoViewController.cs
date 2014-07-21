using MonoTouch.SpriteKit;
using MonoTouch.UIKit;

namespace SpriteKitPhysicsDemo
{
	public partial class SpriteKitDemoViewController : UIViewController
	{
		public override void LoadView ()
		{
			base.LoadView ();

			View = new SKView {
				ShowsFPS = false,
				ShowsNodeCount = false,
				ShowsDrawCount = false
			};
		}

		public override void ViewWillLayoutSubviews ()
		{
			base.ViewWillLayoutSubviews ();

			var view = (SKView)View;

			if (view.Scene == null) {
				var scene = new MonkeyScene (View.Bounds.Size);
				scene.ScaleMode = SKSceneScaleMode.AspectFill;
				view.PresentScene (scene);
			}
		}

		public override bool PrefersStatusBarHidden ()
		{
			return true;
		}
	}
}

