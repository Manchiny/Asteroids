using Assets.Scripts.Enemies;
using Assets.Scripts.Weapon;
using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class Game
    {
        private Spaceship _spaceship;
        private SpaceshipPresenter _spaceshipPresenter;
        private WeaponManager _weaponManager;
        private EnemyManager _enemyManager;

        public  Spaceship Spaceship => _spaceship;
        public WeaponManager WeaponManager => _weaponManager;
        public SpaceshipPresenter SpaceshipPresenter => _spaceshipPresenter;
        public EnemyManager EnemyManager => _enemyManager;

        private int _scores;
        public int Scores
        {
            get => _scores;
            private set
            {
                _scores = value;
                OnScoresChanged?.Invoke(_scores);
            }
        }

        public Action<int> OnScoresChanged;

        public Game(Spaceship spaceship, List<Bullet> bullets, EnemyPrefabs enemyPrefabs)
        {
            _spaceship = spaceship;

            _weaponManager = new WeaponManager(bullets);
            _spaceshipPresenter = new SpaceshipPresenter(Spaceship, _weaponManager);
            _enemyManager = new EnemyManager(enemyPrefabs);
        }
        public void OnEnemyKilled(Enemy enemy)
        {
            Scores += enemy.RewardScore;
        }
        public void StartGame()
        {
            Scores = 0;
            _spaceshipPresenter.StartGame();
        }
        public void RestartGame()
        {
            Scores = 0;
            _spaceshipPresenter.Restart();
            _enemyManager.Restart();
        }

        public void GameOver()
        {
            _weaponManager.OnGameOver();
            _spaceshipPresenter.OnGameOver();
            _enemyManager.OnGameOver();
        }

        public void OnExit()
        {
            _weaponManager.OnExit();
            _enemyManager.OnExit();
            _spaceshipPresenter.OnExit();
        }
    }
}
