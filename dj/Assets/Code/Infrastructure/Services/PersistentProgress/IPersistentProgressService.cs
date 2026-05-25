using Code.Data;

namespace Code.Infrastructure.Services.PersistentProgress
{
    public interface IPersistentProgressService
    {
        PlayerProgress Progress { get; set; }
    }
}