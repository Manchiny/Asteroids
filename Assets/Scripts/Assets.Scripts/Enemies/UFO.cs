using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class UFO : Enemy
    {
        private RectTransform _shipTransform;
        public override float Speed { get; protected set; } = 120;
        public override int RewardScore { get; protected set; } = 1;

        public override void Init(Vector3 position, Vector3 rotation, EnemyManager enemyManager)
        {
            _transform.anchoredPosition = position;
            _shipTransform = GamePresenter.Spaceship.ShipTransform;

            base.Init(position, rotation, enemyManager);
        }

        protected override void Move()
        {
            _transform.position += (_shipTransform.position - _transform.position).normalized * Speed * Time.deltaTime;
        }
    }
}
