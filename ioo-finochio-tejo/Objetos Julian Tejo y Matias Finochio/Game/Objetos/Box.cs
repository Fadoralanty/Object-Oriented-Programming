using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Box : GameObject, IBox
    {
        public BoxCollider boxCollider { get; private set; }
        public bool Isgrabbed { get => isgrabbed; set => isgrabbed = value; }

        public bool isStop = false;
        private Animation idle;
        private Vector2 lastFramePosition;
        private bool isgrabbed;

        public Box(Vector2 initialPosition, Vector2 initialScale, Vector2 initialRotation) : base(initialPosition, initialScale, initialRotation)
        {
            CreateAnimations();
            this.Renderer.CurrentAnimation = idle;
            this.Renderer.CurrentAnimation.Play();
            InitializeCollider();
        }
        public void InitializeCollider()
        {
            boxCollider = new BoxCollider(Transform.Position, Renderer.size, false, "box");
            boxCollider.BoxReference = this;
            boxCollider.onCollisionEnter += OnCollisionEnterHandler;
            boxCollider.onCollisionStay += OnCollisionStayHandler;
            boxCollider.onCollisionExit += onCollisionExitHandler;
            boxCollider.initialize();
        }
        protected override void CreateAnimations()
        {
            List<Texture> texturesList = new List<Texture>();
            Texture texture = Engine.GetTexture("Textures/Tiles/Box.png");
            texturesList.Add(texture);
            idle = new Animation("idle", texturesList, 0.1f, true);
        }

        public override void Update()
        {
            lastFramePosition = Transform.Position;
            base.Update();
            EdgeScreenLoop();
            boxCollider.Position = this.Transform.Position;

        }
        public override void Render()
        {
            base.Render();
            boxCollider.Render();
        }
        public void SetGrab(bool isGrabbed)
        {
            isgrabbed = isGrabbed;
            //boxCollider.IsEnabled = !isGrabbed;
        }
        public void EdgeScreenLoop()
        {
            Vector2 pos = Transform.Position;
            if(pos.X + Renderer.RealWidth / 2 > Program.SCREEN_WIDTH)
            {
                pos.X = 0 + Renderer.RealWidth/2;
            }
            if(pos.X - Renderer.RealWidth / 2 < 0)
            {
                pos.X = Program.SCREEN_WIDTH - Renderer.RealWidth / 2;
            }
            if(pos.Y - Renderer.RealHeight / 2 < 0)
            {
                pos.Y = Program.SCREEN_HEIGHT - Renderer.RealHeight / 2;
            }
            if(pos.Y + Renderer.RealHeight / 2 > Program.SCREEN_HEIGHT)
            {
                pos.Y = 0 + Renderer.RealHeight / 2;
            }
            Transform.Position = pos;
        }
        public void OnCollisionEnterHandler(BoxCollider other)
        {
            if (other.Tag == "wall")
            {
                isStop = true;
                Transform.Position = lastFramePosition;
                boxCollider.Position = lastFramePosition;
            }
        }
        public void OnCollisionStayHandler(BoxCollider other)
        {
            if (other.Tag == "wall")
            {
                isStop = true;

            }
            if (other.Tag == "conveyor")
            {
                Transform.Position += Vector2.Left;

            }
        }
        public void onCollisionExitHandler(BoxCollider other)
        {
            if (other.Tag == "wall")
            {
                isStop = false;
            }
        }
    }
}