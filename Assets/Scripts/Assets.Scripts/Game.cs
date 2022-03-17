using Assets.Scripts.Core;
using Assets.Scripts.Enemies;
using Assets.Scripts.UI;
using Assets.Scripts.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private PlayField _playField;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private HUDView _hudView;        
        [SerializeField] private List<Bullet> _bullets;

        private WeaponManager _weaponManager;
        public static Game Instance { get; private set; }
        public static PlayField PlayField => Instance._playField;
        private Spaceship _spaceship;
        public static Spaceship Spaceship => Instance._spaceship;
        public static EnemySpawner EnemySpawner => Instance._enemySpawner;

        private SpaceshipPresenter _spaceshipPresenter;

        private int _scores;
        public int Scores
        {
            get => _scores;
            private set
            {
                _scores = value;
                _hudView.SetScoresCount(Scores);
            }
        }
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
            _weaponManager = new WeaponManager(_bullets);
            _spaceshipPresenter = new SpaceshipPresenter(Spaceship, _hudView, _weaponManager);

            _spaceship.OnPositionChanged += _hudView.SetCoordsText;
            _spaceship.OnRotationChanged += _hudView.SetRotationText;
            _spaceship.OnSpeedChanged += _hudView.SetSpeedText;

            _weaponManager.OnLaserCooldawnUpdated += _hudView.SetLaserCooldawnText;
            _weaponManager.OnLaserBulletsChanged += _hudView.SetLaserCountText;

            StartGame();
        }

        private void StartGame()
        {
            Scores = 0;
            _spaceshipPresenter.StartGame();
            StartCoroutine(LaserCooldawnTimer());
        }
        public void OnEnemyKilled(Enemy enemy)
        {
            Scores += enemy.RewardScore;
        }
        public void OnShipDied()
        {
            StopAllCoroutines();

            _hudView.OnGameOver(Scores, RestartGame);
            _spaceshipPresenter.OnGameOver();
            _enemySpawner.OnGameOver();
        }
        private void RestartGame()
        {
            Scores = 0;
            _spaceshipPresenter.Restart();
            _enemySpawner.Restart();

            StartCoroutine(LaserCooldawnTimer());
        }
        private IEnumerator LaserCooldawnTimer()
        {
            yield return new WaitForSeconds(1f);
            _weaponManager.DecreaseCooldawnTimer();
            StartCoroutine(LaserCooldawnTimer());
        }
    }
}




