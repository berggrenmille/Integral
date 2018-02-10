using System;
using IntegralEngine.Messaging;
using OpenTK;

namespace IntegralEngine
{
    public class SphereRayTracer : Component
    {
        public float radius = 1, radius2 = 1;
        Vector3 surfaceColor, emissionColor;      /// surface color and emission (light) 
        float transparency, reflection;         /// surface transparency and reflectivity 
        private const float INFINITY = float.PositiveInfinity;

        private static float tNear;

        public bool Intersect(Vector3 rayOrigin, Vector3 rayDir, out float t0, out float t1)
        {
            t0 = 0;
            t1 = 0;
            Vector3 length = entity.transform.position - rayOrigin;
            float tca = Vector3.Dot(length, rayDir);
            if (tca < 0) return false;
            float d2 = 1 - tca * tca;
            if (d2 > radius2) return false;
            float thc = (float)Math.Sqrt(radius2 - d2);
            t0 = tca - thc;
            t1 = tca + thc;

            return true;
        }

        float Mix(float a, float b, float mix)
        {
            return b* mix + a* (1 - mix);
        }

        private Vector3 RayTrace(Vector3 rayorig,
                                Vector3 raydir,
        const std::vector<Sphere> &spheres,
        const int &depth)
        {
            
        }


        private void Render()
        {
            
        }

        public override void OnMessage(Message message)
        {
            if (message.type == MessageType.UPDATE && tNear != INFINITY)
                tNear = INFINITY;
            if (message.type == MessageType.RENDER)
                Render();
        }
    }
}