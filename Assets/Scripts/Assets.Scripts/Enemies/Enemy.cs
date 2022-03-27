using Assets.Scripts.Enemies;
using Assets.Scripts.Weapon;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected RectTransform _transform;
        public Vector3 Direction => new Vector3(0, 1, 0);
        public virtual float Speed { get; protected set; }
        public virtual int RewardScore { get; protected set; }
        public bool IsInited { get; protected set; }

        private EnemyManager _enemyManager;

        public Action<Enemy, Bullet> OnKilled;
        public Action<Enemy> OnBoundsCross;
        private void FixedUpdate()
        {
            if (!IsInited)
                return;
            Move();
        }
        public virtual void Init(Vector3 position, Vector3 rotation, EnemyManager enemyManager)
        {
            IsInited = true;
            _enemyManager = enemyManager;
            gameObject.SetActive(true);
        }
        protected virtual void Die(Bullet bullet)
        {
            IsInited = false;
            OnKilled?.Invoke(this, bullet);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Spaceship>() == true)
                _enemyManager.OnSpaceshipDamaged?.Invoke();

            if (collision.gameObject.GetComponent<Bullet>() == true)
                Die(collision.gameObject.GetComponent<Bullet>());
        }

        protected abstract void Move();
    }
}
