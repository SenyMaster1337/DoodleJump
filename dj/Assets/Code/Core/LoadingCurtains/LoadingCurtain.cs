using System.Collections;
using UnityEngine;
using Zenject;

namespace Code.Core.LoadingCurtains
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        private const float FadeInDurationValue = 0.03f;

        private ILoadingCurtainProvider _loadingCurtainProvider;
        private Coroutine _fadeCoroutine;

        [Inject]
        private void Construct(ILoadingCurtainProvider loadingCurtainProvider)
        {
            _loadingCurtainProvider = loadingCurtainProvider;
        }

        private void Awake()
        {
            _loadingCurtainProvider.SetLoadingCurtain(this);
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            if (_fadeCoroutine != null)
                StopCoroutine(_fadeCoroutine);

            _fadeCoroutine = StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= FadeInDurationValue;
                yield return new WaitForSeconds(FadeInDurationValue);
            }

            gameObject.SetActive(false);
            _fadeCoroutine = null;
        }
    }
}