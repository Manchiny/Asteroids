using Assets.Scripts.UI;
using Assets.Scripts.Weapon;

namespace Assets.Scripts
{
    public class SpaceshipPresenter
    {
        private Spaceship _spaceship;
//        private HUDView _hudView;
        private SpaceshipInput _input;
        private WeaponManager _weaponManager;

        private float _maxMoveSpeed = 8f;
        private float _acceleration = 0.5f;
        private float _rotatinSpeed = 5f;
        private float _stopSpeed = 0.05f;

        private const int MAX_LIVES_COUNT = 0;
        private int _lives;

        public SpaceshipPresenter(Spaceship spaceship, HUDView hudView, WeaponManager weaponManager)
        {
            _spaceship = spaceship;
            _spaceship.OnDamaged += OnSpaceshipDamaged;
     //       _hudView = hudView;
            _weaponManager = weaponManager;

            Init();
        }
        private void Init()
        {

            InitSpaceship();

            _input = new SpaceshipInput();

            _input.Spaceship.Rotation.performed += obj => _spaceship.SetRotationSpeed(obj.ReadValue<float>());
            _input.Spaceship.Rotation.canceled += _ => _spaceship.StopRotation();

            _input.Spaceship.Accelerate.performed += _ => _spaceship.StartAccelerate();
            _input.Spaceship.Accelerate.canceled += _ => _spaceship.StopAccelerate();

            _input.Spaceship.Shoot.performed += _ => Shoot();
            _input.Spaceship.SwitchWeapon.performed += _ => _weaponManager.SetWeaponNext();

            _input.Enable();
        }

        private void InitSpaceship()
        {
            _spaceship.Init(_maxMoveSpeed, _acceleration, _rotatinSpeed, _stopSpeed);
        }

        public void StartGame()
        {
            _lives = MAX_LIVES_COUNT;
            _weaponManager.StartGame();
        }

        private void Shoot()
        {
            var bullet = _weaponManager.GetBullet();
            _spaceship.Shoot(bullet);
        }

        private void OnSpaceshipDamaged()
        {
            _lives--;
            if (_lives < 0)
                Game.Instance.OnShipDied();
        }

        public void OnGameOver()
        {
            _input.Disable();
            _spaceship.OnGameOver();
            _weaponManager.OnGameOver();
        }

        public void Restart()
        {
            _lives = MAX_LIVES_COUNT;

            _spaceship.Restart();
            _weaponManager.Restart();
            _input.Enable();
        }
    }
}