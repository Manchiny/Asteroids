using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public abstract class Bullet : MonoBehaviour, IPlayFieldBoundsCheckable
    {
        [SerializeField] private RectTransform _transform;
        protected float _speed = 500f;
        private Vector3 _direction = new Vector3(0, 1, 0);

        public void OnBoundCross()
        {
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            Move();
        }
        private void Move()
        {
            _transform.Translate(_direction * _speed * Time.deltaTime);
        }

        public virtual void OnDamage()
        {

        }
    }
}
