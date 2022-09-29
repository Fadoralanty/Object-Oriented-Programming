using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class TileFactory
    {
        public enum TileType 
        {
            Empty,
            Tiled,
            CornerWall,
            HorizontalWall,
            VerticalWall,
            ConveyorLeft,
            OrangeEmpty
        }
        public static Tile CreateTile(TileType newTile,Vector2 position)
        {
            switch (newTile)
            {
                case TileType.Empty:
                    return new Tile("Textures/Tiles/Empty.png", false, false, position, new Vector2(1f, 1f), Vector2.Zero);
                case TileType.Tiled:
                    return new Tile("Textures/Tiles/Tile3.png", false, false, position, new Vector2(1f, 1f), Vector2.Zero);
                case TileType.CornerWall:
                    return new Tile("Textures/WallTiles/CornerWall.png", true, false, position, new Vector2(1f, 1f), Vector2.Zero);
                case TileType.HorizontalWall:
                    return new Tile("Textures/WallTiles/VerticalWall.png", true, false, position, new Vector2(1f, 1f), Vector2.Zero);
                case TileType.VerticalWall:
                    return new Tile("Textures/WallTiles/HorizontalWall.png", true, false, position, new Vector2(1f, 1f), Vector2.Zero);
                case TileType.ConveyorLeft:
                    return new Tile("Textures/Tiles/Belt/Left/1.png", false, true, position, new Vector2(1f, 1f), Vector2.Zero);
                case TileType.OrangeEmpty:
                    return new Tile("Textures/Tiles/Orange.png", false, false, position, new Vector2(1f, 1f), Vector2.Zero);                    
                default:
                    return null;
            }

        }
    }
}