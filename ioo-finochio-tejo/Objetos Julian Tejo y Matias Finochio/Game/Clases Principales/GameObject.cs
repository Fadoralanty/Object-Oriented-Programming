using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class GameObject
    {
        private Renderer renderer = new Renderer();
        private Transform transform = new Transform();
        public Transform Transform { get => transform; set => transform = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }

        public GameObject(Vector2 initialPosition, Vector2 initialScale, Vector2 initialRotation)
        { 
            Transform.Position = initialPosition;
            Transform.Scale = initialScale;
            Transform.Rotation = initialRotation;
            Renderer.Transform = this.transform;
        }
        protected abstract void CreateAnimations();
        public virtual void Update()
        {
            Renderer.CurrentAnimation.Update();
        }
        public virtual void Render()
        {
            Renderer.DrawImage();
        }
        public virtual void Destroy()
        {
             
        }
    }
}