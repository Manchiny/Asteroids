using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Asteroid : Enemy
    {
        protected override void Move()
        {
            _transform.Translate(Direction * Speed * Time.deltaTime);
        }

        public override void Init(Vector3 position, Vector3 rotation)
        {
            Speed = 100f;
            RewardScore = 1;
            _transform.anchoredPosition = position;
            _transform.Rotate(rotation);

            base.Init(position, rotation);
        }
    }
}
