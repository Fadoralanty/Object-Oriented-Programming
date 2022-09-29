using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Tile : GameObject
    {
        private Animation idle;
        private string texturePath;
        private BoxCollider boxCollider;
        public Tile(string texturePath, bool isWall, bool isConveyor ,Vector2 initialPosition, Vector2 initialScale, Vector2 initialRotation) : base(initialPosition, initialScale, initialRotation)
        {
            this.texturePath = texturePath;
            CreateAnimations();
            Renderer.CurrentAnimation = idle;
            Renderer.CurrentAnimation.Play();
            if (isWall)
            {
                boxCollider = new BoxCollider(initialPosition, Renderer.size, false, "wall");
                boxCollider.IsEnabled = isWall;
            }
            else if(isConveyor)
            {
                boxCollider = new BoxCollider(initialPosition, Renderer.size, false, "conveyor");
                boxCollider.IsEnabled = isConveyor;
            }
            else
            {
                boxCollider = new BoxCollider(initialPosition, Renderer.size, false, "");
                boxCollider.IsEnabled = false;
            }
                   
            boxCollider.initialize();
        }


        public BoxCollider BoxCollider { get => boxCollider; set => boxCollider = value; }

        protected override void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            Texture texture = Engine.GetTexture(this.texturePath);
            idleTextures.Add(texture);
            idle = new Animation("idle", idleTextures, 1);
            //List<Texture> conveyorTextures = new List<Texture>();
        }
        public override void Render()
        {
            base.Render();
            boxCollider.Render();
        }
    }
}
