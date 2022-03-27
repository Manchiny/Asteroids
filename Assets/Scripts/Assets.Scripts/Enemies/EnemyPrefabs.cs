using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class EnemyPrefabs : MonoBehaviour
    {
        [SerializeField] private List<Enemy> _enemyPrefabs;
        [SerializeField] private Asteroid _asteroidPrefab;
        [SerializeField] private UFO _ufoPrefab;
        [SerializeField] private MiniAsteroid _miniAsteroidPrefab;

        public List<Enemy> EnemiesPrefabs => _enemyPrefabs;
        public Asteroid AsteroidPrefab => _asteroidPrefab;
        public UFO UFOPrefab => _ufoPrefab;
        public MiniAsteroid MiniAsteroidPrefab => _miniAsteroidPrefab;
    }
}
