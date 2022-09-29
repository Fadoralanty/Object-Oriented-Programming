using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level3
    {
        private PlayerController player;
        private Box[] boxes;
        private Tilemap tilemap;
        private static List<BoxCollider> colliders = new List<BoxCollider>();
        private List<GameObject> levelObjects = new List<GameObject>();
        private BoxPool boxPool = new BoxPool();
        private WinTrigger winTrigger;
        private BoxTrap trap;
        private BoxTrap trap2;
        private float currentTime = 0f;
        private float timeToGameOver = 100f;
        private T[,] level2Tiles = new T[15, 20]
        {
            { T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O},
            { T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O},
            { T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O},
            { T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O},
            { T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O},
            { T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O},
            { T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O},
            { T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O},
            { T.H, T.H, T.H, T.H, T.H, T.H, T.H, T.H, T.H, T.O, T.O, T.O, T.H, T.H, T.H, T.H, T.H, T.H, T.H, T.H},
            { T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O},
            { T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O},
            { T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O},
            { T.L, T.L, T.L, T.L, T.L, T.L, T.L, T.L, T.L, T.L, T.L, T.L, T.L, T.L, T.L, T.L, T.L, T.L, T.L, T.L},
            { T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O},
            { T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O, T.O}

        };
        public Level3()
        {
            Initialize();
        }
        public void Initialize()
        {
            tilemap = new Tilemap(level2Tiles, 64);
            player = new PlayerController(new Vector2(200, 200), new Vector2(0.5f, 0.5f), new Vector2(0, 0), new Vector2(250, 250));
            RegisterCollider(player.BoxCollider);
            for (int i = 0; i < tilemap.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tilemap.Tiles.GetLength(1); j++)
                {
                    RegisterCollider(tilemap.Tiles[i, j].BoxCollider);
                }
            }
            boxes = new Box[7];
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i] = BoxFactory.CreateBox(BoxFactory.Boxes.SquareBox, new Vector2(75 * i, 800));
                RegisterCollider(boxes[i].boxCollider);
                boxPool.available.Add(boxes[i]);
            }
            levelObjects.Add(boxPool.GetBox());
            levelObjects.Add(boxPool.GetBox());
            levelObjects.Add(boxPool.GetBox());
            levelObjects.Add(boxPool.GetBox());
            levelObjects.Add(boxPool.GetBox());
            levelObjects.Add(boxPool.GetBox());
            levelObjects.Add(boxPool.GetBox());
            trap = new BoxTrap(new Vector2(530, 640), new Vector2(1f, 1f), Vector2.Zero);
            levelObjects.Add(trap);
            RegisterCollider(trap.boxCollider);
            trap.onReset += OnResetHandler;

            trap2 = new BoxTrap(new Vector2(800, 640), new Vector2(1f, 1f), Vector2.Zero);
            levelObjects.Add(trap2);
            RegisterCollider(trap2.boxCollider);
            trap2.onReset += OnResetHandler;

            winTrigger = new WinTrigger(new Vector2(680, 320), new Vector2(0.5f, 0.5f), Vector2.Zero, GameManager.State.WinScreen, 7);
            levelObjects.Add(winTrigger);
            RegisterCollider(winTrigger.BoxCollider);
        }
        public void Update()
        {
            currentTime += Time.DeltaTime;
            if (currentTime >= timeToGameOver)
            {
                currentTime = 0f;
                GameManager.Instance.ChangeState(GameManager.State.GameOver);
            }
            CheckCollisions();
            for (int i = 0; i < levelObjects.Count; i++)
            {
                levelObjects[i].Update();
            }
            player.Update();
        }
        public void Render()
        {
            tilemap.Render();
            for (int i = 0; i < levelObjects.Count; i++)
            {
                levelObjects[i].Render();
            }
            player.Render();
        }
        public static void RegisterCollider(BoxCollider boxCollider)
        {
            if (colliders.Contains(boxCollider))
            {
                return;
            }
            colliders.Add(boxCollider);
        }
        public void OnResetHandler(int i)
        {
            if (i == 0)
            {
                ResetLevel();
            }
            if (i == 1)
            {
                ResetBoxes();
            }

        }
        public void ResetBoxes()
        {
            player.DropItem();
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Transform.Position = new Vector2(75 * i, 800);
            }
        }
        public void ResetLevel()
        {
            player.Transform.Position = new Vector2(200, 200);
            player.DropItem();
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Transform.Position = new Vector2(75 * i, 800);
            }
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
    }
}
