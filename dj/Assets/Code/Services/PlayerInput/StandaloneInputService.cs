using UnityEngine;

namespace Code.Services.PlayerInput
{
    public class StandaloneInputService : InputService
    {
        public override float Horizontal => Input.GetAxis(HorizontalAxis);
        public override bool IsFirePressed => Input.GetButtonDown(FireButton);
    }
}