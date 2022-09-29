using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public struct Vector2
    {
        public float X { get => x; set => x = value; }
        private float x;
        public float Y { get => y; set => y = value; }
        private float y;
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        //---------------------------OPERATORS-----------------------------------
        public static Vector2 operator + (Vector2 vectorA, Vector2 vectorB)
        {
            return new Vector2(vectorA.X + vectorB.X, vectorA.Y + vectorB.Y);
        }
        public static Vector2 operator ++ (Vector2 vectorA)
        {
            return new Vector2(vectorA.X++, vectorA.Y++);
        }
        public static Vector2 operator - (Vector2 vectorA, Vector2 vectorB)
        {
            return new Vector2(vectorA.X - vectorB.X, vectorA.Y - vectorB.Y);
        }
        public static Vector2 operator -- (Vector2 vectorA)
        {
            return new Vector2(vectorA.X--, vectorA.Y--);
        }
        public static Vector2 operator * (Vector2 vectorA, float numberA)
        {
            return new Vector2(vectorA.X * numberA, vectorA.Y * numberA);
        }
        public static Vector2 operator / (Vector2 vectorA, float numberA)
        {
            return new Vector2(vectorA.X / numberA, vectorA.Y / numberA);
        }
        public static bool operator == (Vector2 vectorA, Vector2 vectorB)
        {
            return vectorA.X == vectorB.X && vectorA.Y == vectorB.Y;
        }
        public static bool operator != (Vector2 vectorA, Vector2 vectorB)
        {
            return vectorA.X != vectorB.X || vectorA.Y != vectorB.Y;
        }
        //--------Versores-------------
        public static Vector2 Up => new Vector2(0, -1);
        public static Vector2 Down => new Vector2(0, 1);
        public static Vector2 Left => new Vector2(-1, 0);
        public static Vector2 Rignt => new Vector2(1,0);
        public static Vector2 Zero => new Vector2(0, 0);
        public static float Magnitude(Vector2 vectorA)
        {
            return (float)Math.Sqrt(vectorA.X * vectorA.X + vectorA.Y * vectorA.Y);
        }
        public static float DistanceMag(Vector2 vectorA, Vector2 vectorB)
        {
            return Magnitude(vectorA - vectorB);
        }
        public static float DistanceX(Vector2 vectorA, Vector2 vectorB)
        {
            return Math.Abs(vectorA.X - vectorB.X);
        }
        public static float DistanceY(Vector2 vectorA, Vector2 vectorB)
        {
            return Math.Abs(vectorA.Y - vectorB.Y);
        }
        public Vector2 Normalized()
        {
            return new Vector2(x / Magnitude(this), y / Magnitude(this));
        }
        public void Normalize()
        {
            x = x / Magnitude(this);
            y = y / Magnitude(this);
        }
        public override string ToString()
        {
            return $"Vector2({x},{y})";
        }

        public override bool Equals(object obj)
        {
            return obj is Vector2 vector &&
                   X == vector.X &&
                   x == vector.x &&
                   Y == vector.Y &&
                   y == vector.y;
        }

        public override int GetHashCode()
        {
            int hashCode = -250348082;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }
    }
}
