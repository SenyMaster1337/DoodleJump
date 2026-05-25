namespace Code.Core.LoadingCurtains
{
    public interface ILoadingCurtainProvider
    {
        LoadingCurtain LoadingCurtain { get; }
        void SetLoadingCurtain(LoadingCurtain loadingCurtain);
    }
}