using TMPro;
using UnityEngine;

namespace Code.UI.ScoreShowers
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CurrentScoreText : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshPro;

        private void Awake() 
            => _textMeshPro = GetComponent<TextMeshProUGUI>();

        public void SetValue(int value) 
            => _textMeshPro.text = value.ToString();
    }
}