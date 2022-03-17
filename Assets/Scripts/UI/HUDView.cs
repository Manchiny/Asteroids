using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class HUDView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _yPosition;
        [SerializeField] private TextMeshProUGUI _xPosition;
        [Space]
        [SerializeField] private TextMeshProUGUI _rotation;
        [SerializeField] private TextMeshProUGUI _speed;
        [Space]
        [SerializeField] private TextMeshProUGUI _laserCount;
        [SerializeField] private TextMeshProUGUI _laserCooldawn;
        [Space]
        [SerializeField] private TextMeshProUGUI _scores;
        [Space]
        [SerializeField] private RectTransform _windowHolder;
        [SerializeField] private GameOverWindow _gameOverWindow;
        public void SetCoordsText(float yPos, float xPos)
        {
            _yPosition.text = $"Y: {(float)Math.Round(yPos, 1)}";
            _xPosition.text = $"X: {(float)Math.Round(xPos, 1)}";
        }

        public void SetRotationText(float angle)
        {
            _rotation.text = $"Rotation: {(float)Math.Round(angle, 1)}";
        }

        public void SetSpeedText(float speed)
        {
            float roundedSpeed = (float)Math.Round(speed, 1);
            _speed.text = $"Speed: {roundedSpeed}";
        }

        public void SetLaserCountText(int count)
        {
            _laserCount.text = $"Laser: {count}";
        }

        public void SetLaserCooldawnText(int seconds)
        {
            _laserCooldawn.text = $"Cooldawn: {seconds} sec.";
        }

        public void SetScoresCount(int count)
        {
            _scores.text = count.ToString();
        }

        public void OnGameOver(int Scores, Action restartGame)
        {
            ShowGameOverWindow(Scores, restartGame);
        }

        private void ShowGameOverWindow(int Scores, Action restartGame)
        {
            var window = Instantiate(_gameOverWindow, _windowHolder).GetComponent<GameOverWindow>();
            window.Init(Scores, restartGame);
        }
    }
}

