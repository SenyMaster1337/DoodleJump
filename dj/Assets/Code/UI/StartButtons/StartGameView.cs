using Code.Signals.StartGameSignals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.StartButtons
{
    public class StartGameView : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;

        private SignalBus _signalBus;

        [Inject]
        private void Construct(SignalBus signalBus)
            => _signalBus = signalBus;

        private void Start()
            => _startGameButton.onClick.AddListener(OnStartGameClick);

        private void OnDestroy()
            => _startGameButton.onClick.RemoveListener(OnStartGameClick);

        private void OnStartGameClick()
            => _signalBus.Fire<StartGameSignal>();
    }
}