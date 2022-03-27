using Assets.Scripts.Core;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShipBoundsChecker : MonoBehaviour, IPlayFieldBoundsCheckable
    {
        public Action OnBoundCrossed;

        public void OnBoundCross()
        {
            OnBoundCrossed?.Invoke();
        }
    }
}
