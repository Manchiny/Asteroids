using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShipBoundsChecker : MonoBehaviour, IPlayFieldBoundsCheckable
    {
        private Spaceship _ship;

        private void Awake()
        {
            _ship = FindObjectOfType<Spaceship>();
        }
        public void OnBoundCross()
        {
            _ship.OnPortalEnter();
        }
    }
}
