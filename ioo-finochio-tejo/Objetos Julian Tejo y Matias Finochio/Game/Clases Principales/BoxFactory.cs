using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Game
{
    public static class BoxFactory
    {
        public enum Boxes
        {
            SquareBox,
            RectangularBox,

        }
        public static Box CreateBox(Boxes newBox, Vector2 position)
        {
            switch (newBox)
            {
                case Boxes.SquareBox:
                    return new Box(position, new Vector2(1, 1), new Vector2(0, 0));
                case Boxes.RectangularBox:
                    return new Box(position, new Vector2(2f, 0.9f), new Vector2(0, 0));
                default:
                    return null;
            }
            
        }
    }
}