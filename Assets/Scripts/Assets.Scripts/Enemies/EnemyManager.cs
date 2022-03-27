using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Core;
using Assets.Scripts.Weapon;

namespace Assets.Scripts.Enemies
{
    public class EnemyManager
    {
        private const float SPAWN_TIME = 1.5f;
        private const int ASTEROID_PARTS_COUNT = 3;
        private const int POOL_COUNT = 20;

        private EnemyPrefabs _enemyPrefabs;

        private Vector3 _bottomLeftSpawnRotation = new(0, 0, -45f);
        private Vector3 _upperRightSpawnRotation = new(0, 0, 135f);

        private PlayField _playField;

        private Queue<Enemy> _asteroids;
        private Queue<Enemy> _ufos;
        private Queue<Enemy> _miniAsteroids;

        private Dictionary<Type, Queue<Enemy>> _enemiesPool;
        private List<Enemy> _enemiesOnPlayField;

        public Action<Enemy> OnEnemyDied;
        public Action OnSpaceshipDamaged;

        CancellationTokenSource cancelTimerTokenSource;
        CancellationToken cancelTimerToken;

        public EnemyManager(EnemyPrefabs enemyPrefabs)
        {
            _enemyPrefabs = enemyPrefabs;
            Init();
        }
        private void Init()
        {
            _playField = GamePresenter.PlayField;
            _enemiesOnPlayField = new List<Enemy>();

            _asteroids = new Queue<Enemy>();
            _ufos = new Queue<Enemy>();
            _miniAsteroids = new Queue<Enemy>();

            _enemiesPool = new Dictionary<Type, Queue<Enemy>>();

            _enemiesPool.Add(_enemyPrefabs.AsteroidPrefab.GetType(), _asteroids);
            _enemiesPool.Add(_enemyPrefabs.UFOPrefab.GetType(), _ufos);
            _enemiesPool.Add(_enemyPrefabs.MiniAsteroidPrefab.GetType(), _miniAsteroids);

            foreach (var prefab in _enemyPrefabs.EnemiesPrefabs)
            {
                for (int i = 0; i < POOL_COUNT; i++)
                {
                    var newEnemy = UnityEngine.Object.Instantiate(prefab, _playField.Rect).GetComponent<Enemy>();
                    _enemiesPool[newEnemy.GetType()].Enqueue(newEnemy);
                    newEnemy.gameObject.SetActive(false);
                }
            }

            Restart();
        }

        private void OnEnemyKilled(Enemy enemy, Bullet bullet)
        {
            bullet.OnDamage();
            PutInPool(enemy);
            if (enemy is Asteroid)
            {
                SpawnMiniAstroids((RectTransform)enemy.transform);
            }
            OnEnemyDied?.Invoke(enemy);
        }
        private void OnEnemyBoundCross(Enemy enemy)
        {
            PutInPool(enemy);
        }
        public void PutInPool(Enemy enemy)
        {
            enemy.OnKilled -= OnEnemyKilled;
            enemy.OnBoundsCross -= OnEnemyBoundCross;

            _enemiesPool[enemy.GetType()].Enqueue(enemy);
            enemy.gameObject.SetActive(false);

            _enemiesOnPlayField.Remove(enemy);
        }
        public void Spawn(Enemy enemy, Vector3 position, Vector3 rotation)
        {
            Enemy createdEnemy = _enemiesPool[enemy.GetType()].Count > 0
                ? _enemiesPool[enemy.GetType()].Dequeue()
                : UnityEngine.Object.Instantiate(enemy, _playField.Rect);

            createdEnemy.transform.rotation = Quaternion.identity;
            createdEnemy.Init(position, rotation, this);

            _enemiesOnPlayField.Add(createdEnemy);

            createdEnemy.OnKilled += OnEnemyKilled;
            enemy.OnBoundsCross += OnEnemyBoundCross;
        }

        private (Vector3 position, Vector3 rotation) GetRandomSpawnPoint()
        {
            int random = UnityEngine.Random.Range(0, 2);
            Vector3 position = Vector3.zero;
            Vector3 rotation = Vector3.zero;
            if (random == 0) // то создаем с боков
            {
                random = UnityEngine.Random.Range(0, 2);

                if (random == 0) // создаем слева
                {
                    position.x = _playField.MinX;
                    position.y = UnityEngine.Random.Range(_playField.MinY, 0);
                    rotation = _bottomLeftSpawnRotation;
                }
                else //создаем справа
                {
                    position.x = _playField.MaxX;
                    position.y = UnityEngine.Random.Range(0, _playField.MaxY);
                    rotation = _upperRightSpawnRotation;
                }
            }
            else // создаем сверху/снизу
            {
                random = UnityEngine.Random.Range(0, 2);
                if (random == 0) // создаем снизу
                {
                    position.y = _playField.MinY;
                    position.x = UnityEngine.Random.Range(_playField.MinX, 0);
                    rotation = _bottomLeftSpawnRotation;
                }
                else //создаем сверху
                {
                    position.y = _playField.MaxY;
                    position.x = UnityEngine.Random.Range(0, _playField.MaxX);
                    rotation = _upperRightSpawnRotation;
                }
            }

            return (position: position, rotation: rotation);
        }

        public void SpawnMiniAstroids(RectTransform parentAsteroid)
        {
            for (int i = 0; i < ASTEROID_PARTS_COUNT; i++)
            {
                SpawnMiniAsteroid(parentAsteroid);
            }
        }

        private void SpawnMiniAsteroid(RectTransform parentAsteroid)
        {
            int radius = 75;
            Vector2 randomVectorInside = UnityEngine.Random.insideUnitCircle.normalized * radius;
            Vector2 randomPosition = (Vector2)parentAsteroid.anchoredPosition + randomVectorInside;

            var rotation = parentAsteroid.rotation.eulerAngles;
            float randomAngel = UnityEngine.Random.Range(rotation.z - 30, rotation.z + 30);
            rotation.z = randomAngel;

            Spawn(_enemyPrefabs.MiniAsteroidPrefab, randomPosition, rotation);
        }

        public void OnGameOver()
        {
            cancelTimerTokenSource?.Cancel();
            cancelTimerTokenSource?.Dispose();
            for (int i = _enemiesOnPlayField.Count - 1; i >= 0; i--)
            {
                var enemy = _enemiesOnPlayField[i];
                PutInPool(enemy);
            }
        }

        public void Restart()
        {
            cancelTimerTokenSource = new CancellationTokenSource();
            cancelTimerToken = cancelTimerTokenSource.Token;
            RunPeriodicallyAsync(SpawnTimer, new TimeSpan(0, 0, (int)SPAWN_TIME), cancelTimerToken);
        }

        public async void RunPeriodicallyAsync(Func<Task> func, TimeSpan interval, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(interval, cancellationToken);
                    await func();
                }
                catch (OperationCanceledException)
                {
                    return;
                }
            }
        }
        private Task SpawnTimer()
        {
            int random = UnityEngine.Random.Range(0, 10);
            Enemy enemy = random < 7 ? _enemyPrefabs.AsteroidPrefab : _enemyPrefabs.UFOPrefab;

            var spawnPoint = GetRandomSpawnPoint();
            Spawn(enemy, spawnPoint.position, spawnPoint.rotation);

            return Task.CompletedTask;
        }

        public void OnExit()
        {
            if (cancelTimerTokenSource != null && cancelTimerTokenSource.IsCancellationRequested == false)
            {
                cancelTimerTokenSource?.Cancel();
                cancelTimerTokenSource?.Dispose();
            }
        }
    }
}
