using System;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Score
{
    public class ScoreByHeight : MonoBehaviour
    {
        private IScoreByHeightProvider _provider;

        private int _currentValue;
        private float _lastY;

        public int ScoreValue
        {
            get => _currentValue;
            private set
            {
                if (value != _currentValue)
                {
                    _currentValue = value;
                    
                    ScoreChanged?.Invoke();
                }
            }
        }

        public event Action ScoreChanged;

        [Inject]
        private void Construct(IScoreByHeightProvider provider) 
            => _provider = provider;

        private void Awake() 
            => _provider.SetScoreByHeight(this);

        private void Start()
        {
            ScoreValue = 0;
            _lastY = transform.position.y;
        }

        private void Update()
        {
            float currentY = transform.position.y;

            if (currentY > _lastY)
            {
                int diff = Mathf.RoundToInt(currentY - _lastY);
                
                if (diff > 0)
                {
                    ScoreValue += diff;
                    _lastY = currentY;
                }
            }
        }
    }
}