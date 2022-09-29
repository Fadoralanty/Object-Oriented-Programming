using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    public class Level1:Ilevel
    {
        private  PlayerController player;
        private static List<BoxCollider> colliders = new List<BoxCollider>();
        private List<GameObject> levelObjects = new List<GameObject>();
        private  SoundPlayer music;
        private  Box isaBox;
        private  Box isaBox2;
        private  Box isaBox3;
        private  WinTrigger winTrigger;
        private float currentTime = 0f;
        private float timeToGameOver = 100f;
        private string texturePath = "Textures/Screens/Level1.png";
        public PlayerController Player { get => player; set => player = value; }
        public SoundPlayer Music { get => music; set => music = value; }
        public Box IsaBox { get => isaBox; set => isaBox = value; }
        public Box IsaBox2 { get => isaBox2; set => isaBox2 = value; }
        public Box IsaBox3 { get => isaBox3; set => isaBox3 = value; }
        public Level1()
        {
            StartLevel();
        }

        public void Initialize()
        {
            player = new PlayerController(new Vector2(200, 200), new Vector2(0.5f, 0.5f), new Vector2(0, 0), new Vector2(250, 250));
            levelObjects.Add(player);
            RegisterCollider(player.BoxCollider);
            music = new SoundPlayer("Music/level1.wav");
            music.Play();
            // FACTORY
            isaBox = BoxFactory.CreateBox(BoxFactory.Boxes.SquareBox, new Vector2(400, 310));
            levelObjects.Add(isaBox);
            RegisterCollider(isaBox.boxCollider);
            isaBox2 = BoxFactory.CreateBox(BoxFactory.Boxes.SquareBox, new Vector2(400, 410));
            levelObjects.Add(isaBox2);
            RegisterCollider(isaBox2.boxCollider);
            isaBox3 = BoxFactory.CreateBox(BoxFactory.Boxes.SquareBox, new Vector2(400, 510));
            levelObjects.Add(isaBox3);
            RegisterCollider(isaBox3.boxCollider);
            winTrigger = new WinTrigger(new Vector2(700, 400), new Vector2(0.5f, 0.5f), Vector2.Zero,GameManager.State.Level2,3);
            levelObjects.Add(winTrigger);
            RegisterCollider(winTrigger.BoxCollider);
            currentTime = 0f;
        }

        public void Update()
        {
            currentTime += Time.DeltaTime;
            if (currentTime >= timeToGameOver)
            {
                currentTime = 0f;
                ResetPosition();
                GameManager.Instance.ChangeState(GameManager.State.GameOver);
            }

            CheckCollisions();
            for (int i = 0; i < levelObjects.Count; i++)
            {
                levelObjects[i].Update();
            }
        }

        public void Render()
        {
            Engine.Draw(texturePath);
            for (int i = 0; i < levelObjects.Count; i++)
            {
                levelObjects[i].Render();
            }

        }
        public void RegisterCollider(BoxCollider boxCollider)
        {
            if (colliders.Contains(boxCollider))
            {
                return;
            }
            colliders.Add(boxCollider);
        }
        public void UnRegisterColliders()
        {
            colliders.Clear();
        }
        private static void CheckCollisions()
        {
            for (int i = 0; i < colliders.Count; i++)
            {
                BoxCollider A = colliders[i];
                for (int j = i + 1; j < colliders.Count; j++)
                {
                    BoxCollider B = colliders[j];
                    A.CheckBoxColliding(B);
                }
            }
        }

        public void ResetPosition()
        {
            player.Transform.Position = new Vector2(200, 200);
            isaBox.Transform.Position = new Vector2(400, 310);
        }

        public void StartLevel()
        {
            Initialize();
        }

        public void EndLevel()
        {
            UnRegisterColliders();
        }
    }
}