using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BoxCollider
    {
        private Vector2 position;
        private Vector2 size;
        private string texturePath = "Textures/BoxColiderDebug.png";
        private Texture debugBox;
        private float angle;
        private bool isDebuging;
        private bool isEnabled = true;
        private Box boxReference;
        public Action <BoxCollider> onCollisionEnter;
        public Action <BoxCollider> onCollisionExit;
        public Action <BoxCollider> onCollisionStay;
        private List <BoxCollider> collidingColliders = new List<BoxCollider>();
        public string Tag { get; private set; }
        public Vector2 Position { get => position; set => position = value; }
        public Box BoxReference { get => boxReference; set => boxReference = value; }
        public bool IsEnabled { get => isEnabled; set => isEnabled = value; }
        public bool IsDebuging { get => isDebuging; set => isDebuging = value; }

        public BoxCollider(Vector2 position, Vector2 size, bool isDebuging = false, string tag = "Default")
        {
            this.Position = position;
            this.isDebuging = isDebuging;
            this.size = size;
            this.Tag = tag;
        }
        public void initialize()
        {
            debugBox = Engine.GetTexture(texturePath);
            //Engine.Debug($"{size.X} : {size.Y}");
            //Engine.Debug($"{debugBox.Width} : {debugBox.Height}");  
        }
        public void Update()
        {
            
        }
        public bool CheckBoxColliding(BoxCollider other)
        {
            if (!IsEnabled || !other.isEnabled) return false;
            float distanceX = Vector2.DistanceX(this.position, other.position);
            float distanceY = Vector2.DistanceY(this.position, other.position);

            float sumHalfWidths = this.size.X / 2 + other.size.X / 2;
            float sumHalfHeight = this.size.Y / 2 + other.size.Y / 2;
            bool isColliding = distanceX <= sumHalfWidths && distanceY <= sumHalfHeight;

            if (isColliding)
            {
                if (!collidingColliders.Contains(other))
                {
                    collidingColliders.Add(other);
                    onCollisionEnter?.Invoke(other);
                    other.onCollisionEnter?.Invoke(this);
                }
                onCollisionStay?.Invoke(other);
                other.onCollisionStay?.Invoke(this);
            }
            else
            {
                if (collidingColliders.Contains(other))
                {
                    collidingColliders.Remove(other);
                    onCollisionExit?.Invoke(other);
                    other.onCollisionExit?.Invoke(this);
                }
            }

            return isColliding;
        }
        public void OnCollision(BoxCollider other)
        {
 
        }
        public void Render()
        {
            Vector2 scale = new Vector2(size.X /debugBox.Width , size.Y/debugBox.Height);
            if (isDebuging) { Engine.Draw(texturePath, Position.X, Position.Y, scale.X, scale.Y, 0, size.X / 2, size.Y / 2); }
        }
    }
}
