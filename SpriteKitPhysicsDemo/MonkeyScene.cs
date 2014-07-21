using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.SpriteKit;
using MonoTouch.UIKit;

namespace SpriteKitPhysicsDemo
{
    public sealed class MonkeyScene : SKScene
    {
        SKSpriteNode monkey;
        SKSpriteNode banana;

        public MonkeyScene (SizeF size) : base (size)
        {
            monkey = SKSpriteNode.FromImageNamed ("monkey");
            monkey.PhysicsBody = SKPhysicsBody.Create (monkey.Texture, monkey.Size);
            monkey.Position = new PointF (Size.Width / 2, Size.Height / 2);
            AddChild (monkey);

            banana = SKSpriteNode.FromImageNamed ("Banana");
            banana.PhysicsBody = SKPhysicsBody.Create (banana.Texture, banana.Size);

            // Setting an alpha threshold when creating a physics body
            // banana.PhysicsBody = SKPhysicsBody.Create (banana.Texture, 0.7f, banana.Size);
  
            banana.Position = new PointF (Size.Width / 2, Size.Height - banana.Size.Height / 2);
            AddChild (banana);

            PhysicsBody = SKPhysicsBody.CreateEdgeLoop (Frame);

            #region Uncomment for physics field code
           
            // Node placed at location of physics field node for illustration
            //
            // SKNode n = SKSpriteNode.FromColor (UIColor.Red, new SizeF (20, 20));
            // n.Position = new PointF (Size.Width / 2, Size.Height / 2);
            // AddChild (n);

            // Spring field
            //
            // SKFieldNode fieldNode = SKFieldNode.CreateSpringField ();
            // fieldNode.Enabled = true;
            // fieldNode.Position = new PointF (Size.Width / 2, Size.Height / 2);
            // fieldNode.Strength = 0.5f;

            // Radial gravity field
            //
            // SKFieldNode fieldNode = SKFieldNode.CreateRadialGravityField ();
            // fieldNode.Enabled = true;
            // fieldNode.Position = new PointF (Size.Width / 2, Size.Height / 2);
            // fieldNode.Strength = 10.0f;
            // fieldNode.Falloff = 1.0f;

            // Adding field node to the scene
            //
            // fieldNode.Region = new SKRegion (Frame.Size);
            // AddChild (fieldNode);

            #endregion
        }

        public override void TouchesBegan (NSSet touches, UIEvent evt)
        {
            var touch = touches.AnyObject as UITouch;
            var pt = touch.LocationInNode (this);

            var node = SKSpriteNode.FromImageNamed ("TinyBanana");
            node.PhysicsBody = SKPhysicsBody.Create (node.Texture, node.Size);
            node.PhysicsBody.AffectedByGravity = false;
            node.PhysicsBody.AllowsRotation = true;
            node.PhysicsBody.Mass = 0.03f;

            node.Position = pt;
            AddChild (node);
        }
    }
}