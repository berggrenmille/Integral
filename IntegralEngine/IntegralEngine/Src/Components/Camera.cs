using System;
using OpenTK;

namespace IntegralEngine
{
    public class Camera : Component
    {
        private static Camera current;

        public const float FOV = 80;
        public const float NEAR_PLANE = 0.1f;
        public const float FAR_PLANE = 1000.0f;

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
            float yScale = (1 / (float)Math.Tan(MathHelper.DegreesToRadians(FOV / 2))) * aspectRatio;
            float xScale = yScale / aspectRatio;
            float frustrumLength = FAR_PLANE - NEAR_PLANE;

            Matrix4 projectionMatrix = new Matrix4();
            projectionMatrix[0, 0] = xScale;
            projectionMatrix.M11 = yScale;
            projectionMatrix.M22 = -((FAR_PLANE + NEAR_PLANE) / frustrumLength);
            projectionMatrix.M23 = -1;
            projectionMatrix.M32 = -((2 * NEAR_PLANE + FAR_PLANE) / frustrumLength);
            projectionMatrix.M33 = 0;
            projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(FOV /aspectRatio), aspectRatio, NEAR_PLANE, FAR_PLANE);
            return projectionMatrix;
        }

        public override void CleanupComponent()
        {
            current = null;
            base.CleanupComponent();
        }
    }
}