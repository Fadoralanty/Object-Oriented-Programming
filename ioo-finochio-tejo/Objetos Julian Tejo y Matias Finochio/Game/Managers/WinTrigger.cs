using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class WinTrigger:GameObject
    {
        private int winNumber = 3;
        private BoxCollider boxCollider;
        private List<Box> boxList = new List<Box>();
        private bool playerInTrigger=false;
        private Animation idle;
        private GameManager.State nextLevel;

        public BoxCollider BoxCollider { get => boxCollider; set => boxCollider = value; }

        public WinTrigger(Vector2 initialPosition, Vector2 initialScale, Vector2 initialRotation, GameManager.State nextLevel, int winNumber) : base(initialPosition, initialScale, initialRotation)
        {
            Transform.Position = initialPosition;
            Transform.Scale = initialScale;
            Transform.Rotation = initialRotation;
            CreateAnimations();
            this.Renderer.CurrentAnimation = idle;
            this.Renderer.CurrentAnimation.Play();
            this.nextLevel = nextLevel;
            this.winNumber = winNumber;
            Initialize();
        }

        public void Initialize()
        {
            boxCollider = new BoxCollider(Transform.Position, Renderer.size, false, "wintrigger");
            boxCollider.onCollisionEnter += OnCollisionEnterHandler;
            boxCollider.onCollisionExit += OnCollisionExitHandler;
            boxCollider.initialize();
        }
        public override void Update()
        {
            base.Update();
            boxCollider.Position = Transform.Position;
            if (boxList.Count >= winNumber && playerInTrigger != false)//Condicion de Victoria
            {
                // GANAR
                GameManager.Instance.ChangeState(nextLevel);
            }
        }

        private void OnCollisionEnterHandler(BoxCollider other)
        {
            if (other.Tag == "Player")//chequeo que el player no este adentro del trigger
            {
                playerInTrigger = true;
            }
            if (other.Tag == "box")
            {
                if (!boxList.Contains(other.BoxReference))
                {
                    boxList.Add(other.BoxReference);
                    Engine.Debug("entro una caja");
                }
            }
        }
        private void OnCollisionExitHandler(BoxCollider other)
        {
            if (other.Tag == "Player")
            {
                playerInTrigger = false;
            }
            if (other.Tag == "box")
            {
                if (boxList.Contains(other.BoxReference))
                {
                    boxList.Remove(other.BoxReference);
                }
            }
        }

        protected override void CreateAnimations()
        {
            List<Texture> texturesList = new List<Texture>();
            Texture texture = Engine.GetTexture("Textures/VariousTextures/DeliverBox.png");
            texturesList.Add(texture);
            idle = new Animation("idle", texturesList, 0.1f, true);
        }
    }
}
