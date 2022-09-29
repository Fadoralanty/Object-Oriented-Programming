using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum T//** Tilemap Tiles **
    {
        E, //empty tile
        T, //tiled tile
        C, //corner Wall
        H, //Horizontal Wall
        V, //Vertical Wall
        L,
        O
    }
    public class Tilemap
    {
        private Tile[,] tiles;
        private int tileSize;

        public Tile[,] Tiles { get => tiles; set => tiles = value; }

        public Tilemap(T[,] grid, int tileSize)
        {
            this.tileSize = tileSize;
            tiles = new Tile[grid.GetLength(0), grid.GetLength(1)];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int posX = j * tileSize + tileSize / 2;
                    int posY = i * tileSize + tileSize / 2;
                    Tile newTile=null;
                    //TODO cambiar por factory
                    switch (grid[i, j])
                    {
                        case T.E:
                            newTile = TileFactory.CreateTile(TileFactory.TileType.Empty, new Vector2(posX, posY));
                            break;
                        case T.T:
                            newTile = TileFactory.CreateTile(TileFactory.TileType.Tiled, new Vector2(posX, posY));
                            break;
                        case T.C:
                            newTile = TileFactory.CreateTile(TileFactory.TileType.CornerWall, new Vector2(posX, posY));
                            break;
                        case T.H:
                            newTile = TileFactory.CreateTile(TileFactory.TileType.HorizontalWall, new Vector2(posX, posY));
                            break;
                        case T.V:
                            newTile = TileFactory.CreateTile(TileFactory.TileType.VerticalWall, new Vector2(posX, posY));
                            break;
                        case T.L:
                            newTile = TileFactory.CreateTile(TileFactory.TileType.ConveyorLeft, new Vector2(posX, posY));
                            break;
                        case T.O:
                            newTile = TileFactory.CreateTile(TileFactory.TileType.OrangeEmpty, new Vector2(posX, posY));
                            break;
                    }
                    tiles[i, j] = newTile;
                }
            }
        }
        public void Render()
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    Tile currentTile = tiles[i, j];
                    currentTile.Render();
                }
            }
        }
        public void Update()
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    Tile currentTile = tiles[i, j];
                    currentTile.Update();
                }
            }
        }

        public Tile GetTileByPosition(Vector2 position)
        {
            int row = (int)Math.Floor(position.Y / tileSize);
            int column= (int)Math.Floor(position.X / tileSize);
            if(row>= tiles.GetLength(0)|| column >= tiles.GetLength(1))
            {
                return null;
            }
            return tiles[row, column];


        }
    }
}
