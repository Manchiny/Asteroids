using UnityEngine;


namespace Assets.Scripts.Enemies
{
    public class MiniAsteroid : Enemy
    {
        public override void Init(Vector3 position, Vector3 rotation)
        {
            Speed = 150f;
            RewardScore = 2;
            _transform.anchoredPosition = position;
            _transform.Rotate(rotation);

            base.Init(position, rotation);
        }
        protected override void Move()
        {
            _transform.Translate(Direction * Speed * Time.deltaTime);
        }
    }
}
