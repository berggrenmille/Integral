using System;
using OpenTK;
using OpenTK.Input;

namespace IntegralEngine.TestScripts
{
    public class Move : LogicScript
    {
        private Transform transform;

        protected override void Update()
        {
            if (Input.GetKeyHold(Key.D))
                transform.position.X += 1 * (float)Time.deltaTime;
            if (Input.GetKeyHold(Key.A))
                transform.position.X -= 1 * (float)Time.deltaTime;
            if (Input.GetKeyHold(Key.W))
                transform.position.Y += 1 * (float)Time.deltaTime;
            if (Input.GetKeyHold(Key.S))
                transform.position.Y -= 1 * (float)Time.deltaTime;
            if (Input.GetKeyHold(Key.Up))
                transform.position.Z += 1 * (float)Time.deltaTime;
            if (Input.GetKeyHold(Key.Down))
                transform.position.Z -= 1 * (float)Time.deltaTime;

            if (Input.GetKeyDown(Key.Right))
                transform.scale *= 1.1f;
            if (Input.GetKeyDown(Key.Left))
                transform.scale *= 0.9f;

            if (Input.GetKeyHold(Key.E))
                transform.eulerRotation.Y += (float)(10 * Time.deltaTime);
            if (Input.GetKeyHold(Key.Q))
                transform.eulerRotation.Y -= (float)(10 * Time.deltaTime);
        }

        public override void InitializeComponent()
        {
            transform = entity.GetComponent<Transform>();
        }
    }
}