using Code.Signals.RestartGameSignals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.RestartButtons
{
    public class RestartGameView : MonoBehaviour
    {
        [SerializeField] private Button _restartGameButton;
        
        private SignalBus _signalBus;

        [Inject]
        private void Construct(SignalBus signalBus) 
            => _signalBus = signalBus;

        private void Start()
            => _restartGameButton.onClick.AddListener(OnRestartGameClick);

        private void OnDestroy()
            => _restartGameButton.onClick.RemoveListener(OnRestartGameClick);

        private void OnRestartGameClick() 
            => _signalBus.Fire<RestartGameSignal>();
    }
}