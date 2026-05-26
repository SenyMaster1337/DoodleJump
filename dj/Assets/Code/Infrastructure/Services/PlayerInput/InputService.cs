using Code.Core.Interfaces;

namespace Code.Infrastructure.Services.PlayerInput
{
    public abstract class InputService : IInputService
    {
        protected const string HorizontalAxis = "Horizontal";
        protected const string FireButton = "Fire1";

        public abstract float Horizontal { get; }
        public abstract bool IsFirePressed { get; }
    }
}