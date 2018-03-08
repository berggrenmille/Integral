using System;
using System.Collections.Generic;
using IntegralEngine.Messaging;
using OpenTK;

namespace IntegralEngine
{
    public class Camera : Component
    {
        private static Camera current;

        public const float FOV = 80;
        public const float NEAR_PLANE = 0.1f;
        public const float FAR_PLANE = 1000.0f;

        private static readonly List<ICameraObserver> observerList = new List<ICameraObserver>();
        public static void Subscribe(ICameraObserver obs)
        {
            observerList.Add(obs);
        }

        public static void Unsubscribe(ICameraObserver obs)
        {
            observerList.Remove(obs);
        }

        public static void Render()
        {
            if(current == null)
                return;
            for (int i = 0; i < observerList.Count; i++)
            {
                observerList[i].OnCameraRender();
            }
        }

        public static void Change()
        {
            if (current == null)
                return;
            for (int i = 0; i < observerList.Count; i++)
            {
                observerList[i].OnCameraChange();
            }
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