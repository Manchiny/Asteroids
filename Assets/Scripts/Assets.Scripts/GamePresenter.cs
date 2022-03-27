using Assets.Scripts.Core;
using Assets.Scripts.Enemies;
using Assets.Scripts.UI;
using Assets.Scripts.Weapon;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GamePresenter : MonoBehaviour
    {
        [SerializeField] private PlayField _playField;     
        [SerializeField] private HUDView _hudView;        
        [SerializeField] private List<Bullet> _bullets;
        [SerializeField] private EnemyPrefabs _enemyPrefabs;

        private Game _game;
        private Spaceship _spaceship;

        public static PlayField PlayField => Instance._playField;
        public static Spaceship Spaceship => Instance._spaceship;
        public static GamePresenter Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                _spaceship = FindObjectOfType<Spaceship>();
                return;
            }
            Destroy(this);
        }
        private void Start()
        {
            _game = new Game(_spaceship, _bullets, _enemyPrefabs);

            _game.Spaceship.OnPositionChanged += _hudView.SetCoordsText;
            _game.Spaceship.OnRotationChanged += _hudView.SetRotationText;
            _game.Spaceship.OnSpeedChanged += _hudView.SetSpeedText;

            _game.WeaponManager.OnLaserCooldawnUpdated += _hudView.SetLaserCooldawnText;
            _game.WeaponManager.OnLaserBulletsChanged += _hudView.SetLaserCountText;

            _game.OnScoresChanged += _hudView.SetScoresCount;

            _game.SpaceshipPresenter.OnShipDied += _game.GameOver;
            _game.SpaceshipPresenter.OnShipDied += (()=>_hudView.OnGameOver(_game.Scores, _game.RestartGame));

            _game.EnemyManager.OnEnemyDied += _game.OnEnemyKilled;
            _game.EnemyManager.OnSpaceshipDamaged += _game.SpaceshipPresenter.OnSpaceshipDamaged;

            _game.StartGame();
        }

        private void OnDisable()
        {
            _game.OnExit();

            _game.Spaceship.OnPositionChanged -= _hudView.SetCoordsText;
            _game.Spaceship.OnRotationChanged -= _hudView.SetRotationText;
            _game.Spaceship.OnSpeedChanged -= _hudView.SetSpeedText;

            _game.WeaponManager.OnLaserCooldawnUpdated -= _hudView.SetLaserCooldawnText;
            _game.WeaponManager.OnLaserBulletsChanged -= _hudView.SetLaserCountText;

            _game.OnScoresChanged -= _hudView.SetScoresCount;

            _game.SpaceshipPresenter.OnShipDied -= _game.GameOver;
            _game.SpaceshipPresenter.OnShipDied -= (() => _hudView.OnGameOver(_game.Scores, _game.RestartGame));

            _game.EnemyManager.OnEnemyDied -= _game.OnEnemyKilled;
            _game.EnemyManager.OnSpaceshipDamaged -= _game.SpaceshipPresenter.OnSpaceshipDamaged;
        }
    }
}




