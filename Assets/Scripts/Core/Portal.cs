using UnityEngine;

namespace Assets.Scripts.Core
{
    public class Portal : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent(typeof(IPlayFieldBoundsCheckable)) == true)
            {
                var checkable = collision.gameObject.GetComponent<IPlayFieldBoundsCheckable>();
                checkable.OnBoundCross();
            }
        }
    }
}
