using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class EnemyBoundsChecker : MonoBehaviour, IPlayFieldBoundsCheckable
    {
        public Enemy _enemy;

        void Awake()
        {
            _enemy = GetComponentInParent<Enemy>();
        }
        public void OnBoundCross()
        {
            _enemy.OnBoundsCross?.Invoke(_enemy);
        }
    }
}
