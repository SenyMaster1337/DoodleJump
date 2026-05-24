namespace Code.Logic.LoadingCurtains
{
    public interface ILoadingCurtainProvider
    {
        LoadingCurtain LoadingCurtain { get; }
        void SetLoadingCurtain(LoadingCurtain loadingCurtain);
    }
}