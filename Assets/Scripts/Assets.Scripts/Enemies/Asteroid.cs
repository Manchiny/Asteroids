using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Asteroid : Enemy
    {
        public override float Speed { get; protected set; } = 100;
        public override int RewardScore { get; protected set; } = 1;

        public override void Init(Vector3 position, Vector3 rotation, EnemyManager enemyManager)
        {
            _transform.anchoredPosition = position;
            _transform.Rotate(rotation);

            base.Init(position, rotation, enemyManager);
        }
        protected override void Move()
        {
            _transform.Translate(Direction * Speed * Time.deltaTime);
        }
    }
}
