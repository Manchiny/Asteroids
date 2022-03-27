using Assets.Scripts.Core;
using Assets.Scripts.Weapon;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpaceshipPresenter
    {
        private Spaceship _spaceship;
        private SpaceshipInput _input;
        private WeaponManager _weaponManager;
        private PlayField _playField;

        private float _maxMoveSpeed = 8f;
        private float _acceleration = 0.5f;
        private float _rotatinSpeed = 5f;
        private float _stopSpeed = 0.05f;

        private const int MAX_LIVES_COUNT = 0;
        private int _lives;

        public Action OnShipDied;
        public SpaceshipPresenter(Spaceship spaceship, WeaponManager weaponManager)
        {
            _spaceship = spaceship;
            _weaponManager = weaponManager;

            _playField = GamePresenter.PlayField;
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
            _spaceship.ShipBoundsChecker.OnBoundCrossed += OnPortalEnter;
        }

        private void Shoot()
        {
            var bullet = _weaponManager.GetBullet();
            UnityEngine.Object.Instantiate(bullet, _spaceship.ShipTransform.position, _spaceship.ShipBody.rotation, _playField.Rect);
        }

        public void OnSpaceshipDamaged()
        {
            _lives--;
            if (_lives < 0)
                OnShipDied?.Invoke();
        }
        public void OnPortalEnter()
        {
            var position = _spaceship.ShipTransform.anchoredPosition;

            Vector3 newPosition = position;

            if (position.x <= _playField.MinX)
                newPosition.x = _playField.MaxX;
            else if ((position.x >= _playField.MaxX))
                newPosition.x = _playField.MinX;

            if (position.y <= _playField.MinY)
                newPosition.y = _playField.MaxY;

            else if (position.y >= _playField.MaxY)
                newPosition.y = _playField.MinY;


            _spaceship.ShipTransform.anchoredPosition = newPosition;
            _spaceship.OnPositionChanged?.Invoke(newPosition.y, newPosition.x);
        }
        public void StartGame()
        {
            _lives = MAX_LIVES_COUNT;
            _weaponManager.StartGame();
        }
        public void Restart()
        {
            _lives = MAX_LIVES_COUNT;

            _spaceship.Restart();
            _weaponManager.Restart();
            _input.Enable();
        }
        public void OnGameOver()
        {
            _input.Disable();
            _spaceship.OnGameOver();
        }

        public void OnExit()
        {
            _input.Spaceship.Rotation.performed -= obj => _spaceship.SetRotationSpeed(obj.ReadValue<float>());
            _input.Spaceship.Rotation.canceled -= _ => _spaceship.StopRotation();

            _input.Spaceship.Accelerate.performed -= _ => _spaceship.StartAccelerate();
            _input.Spaceship.Accelerate.canceled -= _ => _spaceship.StopAccelerate();

            _input.Spaceship.Shoot.performed -= _ => Shoot();
            _input.Spaceship.SwitchWeapon.performed -= _ => _weaponManager.SetWeaponNext();

            _spaceship.ShipBoundsChecker.OnBoundCrossed -= OnPortalEnter;
        }
    }
}