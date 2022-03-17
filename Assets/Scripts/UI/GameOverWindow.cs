using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class GameOverWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scores;
        [SerializeField] private Button _restartButton;

        public void Init(int scores, Action onRestartButtonClick)
        {
            _scores.text = $"{scores} очков";
            _restartButton.onClick.AddListener(() => onRestartButtonClick?.Invoke());
            _restartButton.onClick.AddListener(Close);
        }

        private void Close()
        {
            _restartButton.onClick.RemoveAllListeners();
            Destroy(gameObject);
        }
    }
}