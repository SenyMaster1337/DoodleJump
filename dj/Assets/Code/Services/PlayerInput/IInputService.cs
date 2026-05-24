namespace Code.Services.PlayerInput
{
    public interface IInputService
    {
        float Horizontal { get; }
        bool IsFirePressed { get; }
    }
}