namespace Code.Logic.LoadingCurtains
{
    public class LoadingCurtainProvider : ILoadingCurtainProvider
    {
        public LoadingCurtain LoadingCurtain { get; private set; }

        public void SetLoadingCurtain(LoadingCurtain loadingCurtain) 
            => LoadingCurtain = loadingCurtain;
    }
}