using UnityEngine;

namespace Code.Infrastructure.Services.PlayerInput
{
    public class StandaloneInputService : InputService
    {
        public override float Horizontal => Input.GetAxis(HorizontalAxis);
        public override bool IsFirePressed => Input.GetButtonDown(FireButton);
    }
}