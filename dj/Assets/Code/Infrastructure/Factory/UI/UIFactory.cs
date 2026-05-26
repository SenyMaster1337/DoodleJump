using System;
using Code.Infrastructure.AssetManagement;
using Code.UI.ScoreShowers;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory.UI
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        private GameObject _uiRoot;

        public UIFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public GameObject CreateUIRoot()
        {
            var uiRootPrefab = _assetProvider.Load(AssetPath.UIRootPath);

            _uiRoot = _instantiator.InstantiatePrefab(uiRootPrefab);

            return _uiRoot;
        }

        public GameObject CreateHud()
        {
            var hudPrefab = _assetProvider.Load(AssetPath.HudPath);

            return _instantiator.InstantiatePrefab(hudPrefab, _uiRoot.transform);
        }

        public GameObject CreateControlsInstruction()
        {
            var instructionPrefab = _assetProvider.Load(AssetPath.ControlsInstructionPath);

            return _instantiator.InstantiatePrefab(instructionPrefab, _uiRoot.transform);
        }

        public GameObject CreateStartButton()
        {
            var buttonPrefab = _assetProvider.Load(AssetPath.StartButtonPath);

            return _instantiator.InstantiatePrefab(buttonPrefab, _uiRoot.transform);
        }

        public GameObject CreateRestartWindow()
        {
            var restartWindow = _assetProvider.Load(AssetPath.RestartWindowPath);

            return _instantiator.InstantiatePrefab(restartWindow, _uiRoot.transform);
        }

        public ScoreShowerView GetScoreShowerView()
            => FindExistingView<ScoreShowerView>();

        private TView FindExistingView<TView>() where TView : MonoBehaviour
        {
            TView view = _uiRoot.GetComponentInChildren<TView>(true);

            if (view == null)
                throw new NullReferenceException($"View {typeof(TView).Name} not found in UI root");

            return view;
        }
    }
}