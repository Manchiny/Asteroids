using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Weapon
{
    public class WeaponManager
    {
        private const int MAX_LASER_BULLETS = 10;
        private const int LASER_COOLDAWN_SECONDS = 10;
        private Type _defaultBulletType = typeof(SimpleBullet);

        private List<Bullet> _bullets;

        private int _currentBulletId;
        private Bullet _currentBullet;

        private int _cooldawnTimer;
        public int CooldawnTimer { 
            get => _cooldawnTimer; 
            private set 
            { 
                _cooldawnTimer = value;
                OnLaserCooldawnUpdated?.Invoke(_cooldawnTimer);
            } 
        }

        private int _laserBullets;
        public int LaserBullets
        {
            get => _laserBullets;
            private set
            {
                _laserBullets = value;
                OnLaserBulletsChanged?.Invoke(value);
            }
        }

        public Action<int> OnLaserCooldawnUpdated;
        public Action<int> OnLaserBulletsChanged;

        public WeaponManager(List<Bullet> bullets)
        {
            _bullets = bullets;
        }

        public void StartGame()
        {
            SetWeaponNext();

            CooldawnTimer = LASER_COOLDAWN_SECONDS;
            LaserBullets = MAX_LASER_BULLETS;
        }

        public void DecreaseCooldawnTimer()
        {
            CooldawnTimer -= 1;
            UpdateTimer();
        }
        private IEnumerator LaserCooldawnTimer()
        {
            OnLaserCooldawnUpdated?.Invoke(CooldawnTimer);

            yield return new WaitForSeconds(1);
            CooldawnTimer -= 1;
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            if (CooldawnTimer <= 0)
            {
                CooldawnTimer = LASER_COOLDAWN_SECONDS;
                OnLaserCooldawnEnd();
            }
        }

        public void SetWeaponNext()
        {
            if (_currentBullet == null)
            {
                for (int i = 0; i < _bullets.Count; i++)
                {
                    var bullet = _bullets[i];
                    if (bullet.GetType() == _defaultBulletType)
                    {
                        _currentBullet = bullet;
                        _currentBulletId = i;
                        return;
                    }
                }
            }

            int count = _bullets.Count;
            _currentBulletId = _currentBulletId + 1 >= count ? 0 : _currentBulletId + 1;
            _currentBullet = _bullets[_currentBulletId];
        }

        public Bullet GetBullet()
        {
            if (_currentBullet.GetType() == typeof(LaserBullet))
            {
                if (LaserBullets <= 0)
                    SetWeaponNext();
                else
                    LaserBullets--;
            }
            return _currentBullet;
        }

        private void OnLaserCooldawnEnd()
        {
            LaserBullets = MAX_LASER_BULLETS;
        }

        public void OnGameOver()
        {

        }

        public void Restart()
        {
            _currentBullet = null;
            StartGame();
        }
    }
}
