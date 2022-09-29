using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Renderer
    {
        private Transform transform;
        private Animation currentAnimation;
        public float RealHeight => CurrentAnimation.CurrentTexture.Height * Transform.Scale.Y;
        public float RealWidth => CurrentAnimation.CurrentTexture.Width * Transform.Scale.X;
        public float Radius => RealHeight > RealWidth ? RealHeight / 2 : RealWidth / 2;
        public Vector2 size => new Vector2(RealWidth, RealHeight);
        public Vector2 CenterPosition => new Vector2(Transform.Position.X + RealWidth / 2, Transform.Position.Y + RealHeight / 2);
        public Transform Transform { get => transform; set => transform = value; }
        public Animation CurrentAnimation { get => currentAnimation; set => currentAnimation = value; }

        public Renderer(Transform InitialTransform)
        {
            Transform = InitialTransform;
        }

        public Renderer() { }
        public void DrawImage()
        {
            Engine.Draw(CurrentAnimation.CurrentTexture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y,
                Transform.Rotation.X, RealWidth / 2, RealHeight / 2);
        }
    }
}