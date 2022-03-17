using Assets.Scripts.Weapon;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected RectTransform _transform;
        public Vector3 Direction => new Vector3(0, 1, 0);
        public float Speed { get; protected set; }
        public int RewardScore { get; protected set; }
        public bool IsInited { get; protected set; }

        public Action<Enemy> OnKilled;
        public Action<Enemy> OnBoundsCross;
        private void FixedUpdate()
        {
            if (!IsInited)
                return;
            Move();
        }
        public virtual void Init(Vector3 position, Vector3 rotation)
        {
            IsInited = true;
            gameObject.SetActive(true);
        }
        protected virtual void Die()
        {
            IsInited = false;
            OnKilled?.Invoke(this);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Spaceship>() == true)
            {
                collision.gameObject.GetComponent<Spaceship>().OnDamaged?.Invoke();
            }

            if (collision.gameObject.GetComponent<Bullet>() == true)
            {
                Die();
                collision.gameObject.GetComponent<Bullet>().OnDamage();

            }
        }

        protected abstract void Move();
    }
}
