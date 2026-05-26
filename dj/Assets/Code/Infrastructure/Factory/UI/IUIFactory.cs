using Code.UI.ScoreShowers;
using UnityEngine;

namespace Code.Infrastructure.Factory.UI
{
    public interface IUIFactory
    {
        GameObject CreateUIRoot();
        GameObject CreateStartButton();
        GameObject CreateHud();
        GameObject CreateRestartWindow();
        ScoreShowerView GetScoreShowerView();
        GameObject CreateControlsInstruction();
    }
}