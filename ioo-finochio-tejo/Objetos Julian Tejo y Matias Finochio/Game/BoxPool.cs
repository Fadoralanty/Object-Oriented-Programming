using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BoxPool
    {
        public List<Box> inUse = new List<Box>();
        public List<Box> available = new List<Box>();
        public Box GetBox()
        {
            Box boxToReturn = null;
            if (available.Count > 0)
            {
                boxToReturn = available[0];
                available.RemoveAt(0);
                inUse.Add(boxToReturn);
                return boxToReturn;
            }
            else
            {
               boxToReturn = BoxFactory.CreateBox(BoxFactory.Boxes.SquareBox, Vector2.Zero);
               inUse.Add(boxToReturn);
               return boxToReturn;
            }
            
        }
        public void RecycleBox(Box box)
        {
            if (inUse.Contains(box))
            {
                inUse.Remove(box);
                available.Add(box);
            }
        }
    }
}
