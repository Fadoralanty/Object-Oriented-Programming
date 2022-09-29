using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Transform
    {
        private Vector2 position;
        private Vector2 rotation;
        private Vector2 scale;
        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Rotation { get => rotation; set => rotation = value; }
        public Vector2 Scale { get => scale; set => scale = value; }
        public Transform(Vector2 initialPos ,Vector2 initialRotation, Vector2 InitialScale)
        {
            position = initialPos;
            rotation = initialRotation;
            scale = InitialScale;
        }

        public Transform()
        {

        }
    }
}
