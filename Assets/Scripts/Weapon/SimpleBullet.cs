namespace Assets.Scripts.Weapon
{
    public class SimpleBullet : Bullet
    {
        public override void OnDamage()
        {
            base.OnDamage();
            Destroy(gameObject);
        }
    }
}
