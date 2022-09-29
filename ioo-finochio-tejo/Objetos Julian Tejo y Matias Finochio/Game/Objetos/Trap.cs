using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BoxTrap : GameObject
    {
        public BoxCollider boxCollider { get; private set; }
        private Animation idle;

        public Action<int> onReset;

        public BoxTrap(Vector2 initialPosition, Vector2 initialScale, Vector2 initialRotation) : base(initialPosition, initialScale, initialRotation)
        {
            CreateAnimations();
            Renderer.CurrentAnimation = idle;
            Renderer.CurrentAnimation.Play();
            InitializeCollider();
        }

        public void InitializeCollider()
        {
            boxCollider = new BoxCollider(Transform.Position, Renderer.size, false, "trap");
            boxCollider.onCollisionEnter += OnCollisionEnterHandler;
            boxCollider.initialize();
        }

        protected override void CreateAnimations()
        {
            List<Texture> texturesList = new List<Texture>();
            Texture texture = Engine.GetTexture("Textures/Trap.png");
            texturesList.Add(texture);
            idle = new Animation("idle", texturesList, 0.1f, true);
        }

        public void OnCollisionEnterHandler(BoxCollider other)
        {
            if (other.Tag == "Player")
            {
                onReset?.Invoke(0);
            }
            if (other.Tag == "box")
            {
                Engine.Debug("Caja");
                onReset?.Invoke(1);
            }
        }

    }
}
