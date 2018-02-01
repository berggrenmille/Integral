using System;
using OpenTK;

namespace IntegralEngine
{
    public class Transform : Component
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 eulerRotation;
        public Vector3 scale;

        public Vector3 Up()
        {
            return rotation * Vector3.UnitY;
        }

        public Vector3 Forward()
        {
            return rotation * Vector3.UnitZ;
        }

        public Vector3 Right()
        {
            return rotation * Vector3.UnitX;
        }
    }
}   