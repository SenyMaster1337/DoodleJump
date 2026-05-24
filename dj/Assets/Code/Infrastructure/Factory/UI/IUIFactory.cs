using Code.UI.ScoreShowers;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory.UI
{
    public interface IUIFactory
    {
        GameObject CreateUIRoot();
        GameObject CreateStartButton();
        GameObject CreateHud();
        GameObject CreateRestartWindow();
        void SetSceneInstantiator(IInstantiator instantiator);
        ScoreShowerView GetScoreShowerView();
        GameObject CreateControlsInstruction();
    }
}