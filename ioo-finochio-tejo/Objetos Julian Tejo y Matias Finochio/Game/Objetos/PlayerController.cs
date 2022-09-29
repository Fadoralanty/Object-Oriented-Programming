using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PlayerController : GameObject, ICollisionHandler
    {
        private Vector2 lastFramePosition;
        private Vector2 speed;
        private BoxCollider boxCollider;
        private Box myBox;
        private Animation idle;
        private Animation run;
        private Vector2 pos;
        private enum MyBoxDirections{ Right, Down, Left, Up }
        private MyBoxDirections myBoxDirections = MyBoxDirections.Right;
        private int boxDirCount = System.Enum.GetValues(typeof(MyBoxDirections)).Length;
        private Dictionary<Keys, bool> IskeyPressedDic=new Dictionary<Keys, bool>();
        public Vector2 Speed { get => speed; set => speed = value; }
        public BoxCollider BoxCollider { get => boxCollider; set => boxCollider = value; }

        public PlayerController(Vector2 initialPosition, Vector2 initialScale, Vector2 initialRotation, Vector2 InitialSpeed) :base(initialPosition, initialScale, initialRotation)
        {
            Transform.Position = initialPosition;
            Transform.Scale = initialScale;
            Transform.Rotation = initialRotation;
            Renderer.Transform = this.Transform;
            Speed = InitialSpeed;
            lastFramePosition = Transform.Position;
            CreateAnimations();
            this.Renderer.CurrentAnimation = idle;
            this.Renderer.CurrentAnimation.Play();
            boxCollider = new BoxCollider(Transform.Position, Renderer.size, false, "Player");
            boxCollider.onCollisionEnter += OnCollisionEnterHandler;
            boxCollider.onCollisionStay += OnCollisionStayHandler;
            boxCollider.initialize();
            pos = Transform.Position;
            IskeyPressedDic.Add(Keys.E, false);
            IskeyPressedDic.Add(Keys.Q, false);
        }
        protected override void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 0; i <= 5; i++)
            {
                Texture currentTexture = Engine.GetTexture($"Textures/player/idle/{i}.png" );
                idleTextures.Add(currentTexture);
            }
            idle = new Animation("idle", idleTextures, 0.1f,true);
            List<Texture> runTextures = new List<Texture>();
            for (int i = 0; i <= 5; i++)
            {
                Texture currentTexture = Engine.GetTexture($"Textures/player/run/{i}.png");
                runTextures.Add(currentTexture);
            }
            run = new Animation("run", runTextures, 0.1f,true);
        }
        public override void Update()
        {
            base.Update();

            Input();
            boxCollider.Position = this.Transform.Position;
            if (myBox != null)
            {
               foreach(KeyValuePair<Keys,bool> key in IskeyPressedDic.ToList())
               {
                    if (key.Value == true)
                    {
                        if (!Engine.GetKey(key.Key)) { IskeyPressedDic[key.Key] = false; }
                    
                    }
               }
               if (myBox.isStop)
               {
                    Transform.Position = lastFramePosition;
               }
                MyBoxPosition();
            }
        }

        public override void Render()
        {
            base.Render();
            boxCollider.Render();
        }
        public void Input()
        {
            lastFramePosition = Transform.Position;
            pos = Transform.Position;
            if (Engine.GetKey(Keys.D))//Moverse a la derecha
            {
                pos.X += Speed.X * Time.DeltaTime;
                if (pos.X + Renderer.RealWidth / 2 > Program.SCREEN_WIDTH)
                {
                    pos.X -= Speed.X * Time.DeltaTime;
                }
                Renderer.CurrentAnimation = run;
                //TODO arrreglar    que la animacion ande 
            }
            else if (Engine.GetKey(Keys.A))//moverse a la izquierda
            {
                pos.X -= Speed.X * Time.DeltaTime;
                if (pos.X - Renderer.RealWidth / 2 < 0)
                {
                    pos.X += speed.X * Time.DeltaTime;
                }
                Renderer.CurrentAnimation = run;
            }
            else if (Engine.GetKey(Keys.W))//moverse a arriba
            {
                pos.Y -= Speed.Y * Time.DeltaTime;
                if (pos.Y - Renderer.RealHeight / 2 < 0)
                {
                    pos.Y += speed.Y * Time.DeltaTime;
                }
                Renderer.CurrentAnimation = run;
            }
            else if (Engine.GetKey(Keys.S))//moverse a abajo
            {
                pos.Y += Speed.Y * Time.DeltaTime;
                if ((pos.Y + Renderer.RealHeight / 2 > Program.SCREEN_HEIGHT))
                {
                    pos.Y -= speed.Y * Time.DeltaTime;
                }
                Renderer.CurrentAnimation = run;
            }
            else
            {
                Renderer.CurrentAnimation = idle;
            }
            //-----Soltar Una Caja-------
            if (Engine.GetKey(Keys.SPACE))
            {
                DropItem();
            }
            //Rotar caja a la derecha
            if (Engine.GetKey(Keys.E) && IskeyPressedDic[Keys.E]!=true)
            {
                IskeyPressedDic[Keys.E] = true;
                int boxdir = (int)myBoxDirections;
                boxdir++;
                if (boxdir == boxDirCount) { boxdir = 0; }
                myBoxDirections = (MyBoxDirections)boxdir;
            }
            //rotar caja a la izquierda
            if (Engine.GetKey(Keys.Q) && IskeyPressedDic[Keys.Q] != true)
            {               
                IskeyPressedDic[Keys.Q] = true;
                int boxdir = (int)myBoxDirections;
                boxdir--;
                if (boxdir == -1) { boxdir= boxDirCount-1; }
                myBoxDirections = (MyBoxDirections)boxdir;
            }
            Transform.Position = pos;
            Renderer.Transform.Position = pos;
        }

        public void GrabItem(Box otherBox)
        {
            if (myBox == null)
            {
                myBox = otherBox;
                otherBox.SetGrab(true);
            }
        }
        public void DropItem()
        {
            if (myBox != null)
            {
                myBox.SetGrab(false);
                myBox.Isgrabbed = false;
                myBox.Transform.Position++;
                myBox = null;
            }
        }
        public void MyBoxPosition()
        {
            switch (myBoxDirections)
            {
                case MyBoxDirections.Left:
                    myBox.Transform.Position = this.Transform.Position + new Vector2(-Renderer.RealWidth / 2 -  myBox.Renderer.RealWidth / 2, 0);
                    break;
                case MyBoxDirections.Up:
                    myBox.Transform.Position = this.Transform.Position + new Vector2(0, -Renderer.RealHeight / 2 - myBox.Renderer.RealHeight / 2);
                    break;
                case MyBoxDirections.Down:
                    myBox.Transform.Position = this.Transform.Position + new Vector2(0, Renderer.RealHeight / 2 + myBox.Renderer.RealHeight / 2);
                    break;
                case MyBoxDirections.Right:
                    myBox.Transform.Position = this.Transform.Position + new Vector2(Renderer.RealWidth / 2 + myBox.Renderer.RealWidth / 2, 0);//la rotacion se trabaja aqui
                    break;
            }
        }
        public void OnCollisionEnterHandler(BoxCollider other)
        {
            Engine.Debug("Entro a la colision");
            if (other.Tag == "box")
            {
                GrabItem(other.BoxReference);
            }
            if (other.Tag == "wall")
            {
                Transform.Position = lastFramePosition;
            }
        }

        public void OnCollisionStayHandler(BoxCollider other)
        {
            //Engine.Debug("sigue dentro");
            if (other.Tag == "wall")
            {
                Transform.Position = lastFramePosition;
                boxCollider.Position = lastFramePosition;
            }
            if (other.Tag == "conveyor")
            {
                Transform.Position+= Vector2.Left;

            }

        }

    }
}