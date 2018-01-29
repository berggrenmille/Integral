using System;
using OpenTK;

namespace IntegralEngine
{
    public class Transform : Component
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;

        public Vector3 Up()
        {
            return Vector3.Multiply(Vector3.UnitX, (float)-Math.Sin(rotation.X));
        }

        public Vector3 Forward()
        {
            return Vector3.Multiply(Vector3.Multiply(Vector3.UnitZ, (float) Math.Cos(rotation.X)),
                (float) Math.Cos(rotation.Y));
        }

        public Vector3 Right()
        {
            return Vector3.Multiply(Vector3.Multiply(Vector3.UnitZ, (float) Math.Sin(rotation.Y)),
                (float) Math.Cos(rotation.X));

        }
    }
}s