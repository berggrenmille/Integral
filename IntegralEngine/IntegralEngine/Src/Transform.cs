using System;
using System.Data;
using IntegralEngine.Messaging;
using OpenTK;

namespace IntegralEngine
{
    public class Transform : Component
    {
        public Vector3 position = Vector3.Zero;
        public Quaternion rotation = Quaternion.Identity;
        public Vector3 eulerRotation = Vector3.Zero;
        public Vector3 scale = Vector3.One;

        private Matrix4 transformMatrix = new Matrix4();

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

        public Matrix4 GetTransformMatrix()
        {
            Matrix4 translationMatrix;
            Matrix4 rotationMatrix;
            Matrix4 scaleMatrix;

            Matrix4.CreateTranslation(ref position, out translationMatrix);

            rotation = Quaternion.FromEulerAngles(eulerRotation);
            Matrix4.CreateFromQuaternion(ref rotation, out rotationMatrix);

            Matrix4.CreateScale(ref scale, out scaleMatrix);

            transformMatrix = Matrix4.Identity;
            transformMatrix *= translationMatrix * rotationMatrix * scaleMatrix;
            return transformMatrix;
        }



    }
}   