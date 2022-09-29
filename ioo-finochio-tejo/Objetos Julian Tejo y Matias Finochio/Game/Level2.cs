using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level2
    {
        private PlayerController player;
        private Box isaBox;
        private Box isaBox2;
        private Box isaBox3;
        private BoxTrap trap;
        private BoxTrap trap2;
        private BoxTrap trap3;
        private BoxTrap trap4;
        private Tilemap tilemap;
        private static List<BoxCollider> colliders = new List<BoxCollider>();
        private List<GameObject> levelObjects = new List<GameObject>();
        private WinTrigger winTrigger;
        private float currentTime = 0f;
        private float timeToGameOver = 100f;
        private T[,] level2Tiles = new T[15, 20]
        {
            { T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E},
            { T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E},
            { T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E},
            { T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E},
            { T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E},
            { T.E, T.E, T.E, T.E, T.E, T.E, T.H, T.H, T.H, T.H, T.H, T.H, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E},
            { T.E, T.E, T.E, T.E, T.E, T.E, T.V, T.E, T.E, T.E, T.E, T.V, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E},
            { T.E, T.E, T.E, T.E, T.E, T.E, T.V, T.E, T.E, T.E, T.E, T.V, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E},
            { T.E, T.E, T.E, T.E, T.E, T.E, T.V, T.E, T.E, T.E, T.E, T.V, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E},
            { T.E, T.E, T.E, T.E, T.E, T.E, T.V, T.E, T.E, T.E, T.E, T.V, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E},
            { T.E, T.E, T.E, T.E, T.E, T.E, T.H, T.H, T.E, T.E, T.H, T.C, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E},
            { T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E},
            { T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E},
            { T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E},
            { T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E, T.E}
        };
        public Level2()
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
            trap = new BoxTrap(new Vector2(455, 845), new Vector2(1f, 1f), Vector2.Zero);
            levelObjects.Add(trap);
            RegisterCollider(trap.boxCollider);
            trap.onReset += OnResetHandler;

            trap2 = new BoxTrap(new Vector2(724, 845), new Vector2(1f, 1f), Vector2.Zero);
            levelObjects.Add(trap2);
            RegisterCollider(trap2.boxCollider);
            trap2.onReset += OnResetHandler;

            trap3 = new BoxTrap(new Vector2(724, 910), new Vector2(1f, 1f), Vector2.Zero);
            levelObjects.Add(trap3);
            RegisterCollider(trap3.boxCollider);
            trap3.onReset += OnResetHandler;

            trap4 = new BoxTrap(new Vector2(455, 910), new Vector2(1f, 1f), Vector2.Zero);
            levelObjects.Add(trap4);
            RegisterCollider(trap4.boxCollider);
            trap4.onReset += OnResetHandler;

            isaBox = BoxFactory.CreateBox(BoxFactory.Boxes.SquareBox, new Vector2(200, 310));
            levelObjects.Add(isaBox);
            RegisterCollider(isaBox.boxCollider);
            isaBox2 = BoxFactory.CreateBox(BoxFactory.Boxes.SquareBox, new Vector2(200, 410));
            levelObjects.Add(isaBox2);
            RegisterCollider(isaBox2.boxCollider);
            isaBox3 = BoxFactory.CreateBox(BoxFactory.Boxes.SquareBox, new Vector2(200, 510));
            levelObjects.Add(isaBox3);
            RegisterCollider(isaBox3.boxCollider);
            winTrigger = new WinTrigger(new Vector2(576, 512), new Vector2(0.5f, 0.5f), Vector2.Zero, GameManager.State.Level3, 3);
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
                GameManager.Instance.ChangeState(GameManager.State.GameOver);
            }
            player.Update();
            CheckCollisions();
            for (int i = 0; i < levelObjects.Count; i++)
            {
                levelObjects[i].Update();
            }

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
            isaBox.Transform.Position = new Vector2(200, 310);
            isaBox2.Transform.Position = new Vector2(200, 410);
            isaBox3.Transform.Position = new Vector2(200, 510);
        }
        public void ResetLevel()
        {
            player.Transform.Position = new Vector2(200, 200);
            player.DropItem();
            isaBox.Transform.Position = new Vector2(200, 310);
            isaBox2.Transform.Position = new Vector2(200, 410);
            isaBox3.Transform.Position = new Vector2(200, 510);
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
