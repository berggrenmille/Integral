using System;
using System.Collections.Generic;
using IntegralEngine.Messaging;
using OpenTK;

namespace IntegralEngine
{
    public class Camera : Component
    {
        private static Camera current;
        public delegate void m_OnRender(Camera cam);

        public delegate void m_OnChange(Camera cam);

        public static m_OnRender OnRender;
        public static m_OnChange OnChange;


        public const float FOV = 80;
        public const float NEAR_PLANE = 0.1f;
        public const float FAR_PLANE = 1000.0f;

        public void Render()
        {
            MessageBus.SendMessage(new Message(MessageType.RENDER));
            if(OnRender.GetInvocationList().Length != 0)
                OnRender.Invoke(this);
        }

        public void Change()
        {
            if(OnChange.GetInvocationList().Length != 0)
                OnChange.Invoke(this);
        }

        public static Camera GetCurrentCamera()
        {
            return current;
        }

        public Camera()
        {
            if (current != null)
            {
                enabled = false;
                Console.WriteLine("There is already an active camera!");
            }
            else
            {
                current = this;
                enabled = true;
            }

        }
        public Matrix4 GetProjectionMatrix()
        {
            float aspectRatio = Window.width / Window.height;
            Matrix4 projectionMatrix = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI * (FOV / 180f), aspectRatio, NEAR_PLANE, FAR_PLANE);
            return projectionMatrix;
        }

        public Matrix4 GetViewMatrix()
        {
            Matrix4 viewMatrix = Matrix4.Identity;
            Matrix4 viewRotationMatrix;
            Matrix4 viewTranslationMatrix;

            Quaternion rotation = Quaternion.FromEulerAngles(entity.transform.eulerRotation);
            Matrix4.CreateFromQuaternion(ref rotation, out viewRotationMatrix);
            Vector3 negativePosition = new Vector3(-entity.transform.position.X, -entity.transform.position.Y, -entity.transform.position.Z);
            Matrix4.CreateTranslation(ref negativePosition, out viewTranslationMatrix);

            viewMatrix = viewTranslationMatrix*viewRotationMatrix ;
            return viewMatrix;
        }

        public override void CleanupComponent()
        {
            current = null;
            base.CleanupComponent();
        }
    }
}