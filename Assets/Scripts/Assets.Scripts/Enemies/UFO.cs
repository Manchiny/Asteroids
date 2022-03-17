using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class UFO : Enemy
    {
        private RectTransform _shipTransform;
        public override void Init(Vector3 position, Vector3 rotation)
        {
            Speed = 120f;
            RewardScore = 1;
            _transform.anchoredPosition = position;

            _shipTransform = Game.Spaceship.ShipTransform;

            base.Init(position, rotation);
        }

        protected override void Move()
        {
            _transform.position += (_shipTransform.position - _transform.position).normalized * Speed * Time.deltaTime;
        }
    }
}
