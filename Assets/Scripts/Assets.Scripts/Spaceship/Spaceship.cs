using Assets.Scripts.Core;
using Assets.Scripts.Weapon;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spaceship : MonoBehaviour
    {
        [SerializeField] private RectTransform _target;
        [SerializeField] private RectTransform _shipBody;
        private RectTransform _shipTransform;
        private PlayField _playField;

        private float _maxMoveSpeed;
        private float _acceleration;
        private float _rotatinSpeed;
        private float _stopSpeed;

        private float _currentSpeed;
        public float CurrentSpeed
        {
            get => _currentSpeed;
            private set
            {
                _currentSpeed = value;
                OnSpeedChanged?.Invoke(value);
            }
        }
        private float _currentRotationSpeed;
        private Vector3 _targetStartPosition;
        public RectTransform ShipTransform => _shipTransform;

        private bool _isAccelerate;
        private bool _isInited;

        public Action<float> OnRotationChanged;
        public Action<float> OnSpeedChanged;
        public Action<float, float> OnPositionChanged;
        public Action OnDamaged;
        public void Init(float maxMoveSpeed, float acceleration, float rotaionSpeed, float stopSpeed)
        {
            _playField = Game.PlayField;

            _maxMoveSpeed = maxMoveSpeed;
            _acceleration = acceleration;
            _rotatinSpeed = rotaionSpeed;
            _stopSpeed = stopSpeed;

            _shipTransform = GetComponent<RectTransform>();

            _targetStartPosition = _target.localPosition;
            _target.SetParent(ShipTransform);

            _isInited = true;
        }

        private void FixedUpdate()
        {
            if (!_isInited)
                return;

            Accelerate();
            RotateBody(_currentRotationSpeed);
            Move();
        }

        public void StartAccelerate()
        {
            _target.SetParent(_shipBody);
            if (CurrentSpeed <= 0.1f)
            {
                _target.localPosition = _targetStartPosition;
            }
            _isAccelerate = true;
        }
        public void StopAccelerate()
        {
            _target.SetParent(ShipTransform);
            _isAccelerate = false;
        }
        public void Move()
        {
            var targetPosition = _target.position;

            var tr = (RectTransform)transform;
            tr.position += (targetPosition - tr.position) * CurrentSpeed * Time.deltaTime;

            OnPositionChanged?.Invoke(tr.anchoredPosition.y, tr.anchoredPosition.x);
        }

        private void Accelerate()
        {
            if (_isAccelerate)
            {
                AddSpeed();
                MoveTargetToZero();
            }
            else
            {
                ReduceSpeed();
            }

            void MoveTargetToZero()
            {
                _target.localPosition += (_targetStartPosition - _target.localPosition).normalized * CurrentSpeed * 25 * Time.deltaTime;
            }
        }
        private void AddSpeed()
        {
            if (CurrentSpeed + _acceleration >= _maxMoveSpeed)
                CurrentSpeed = _maxMoveSpeed;
            else
                CurrentSpeed += _acceleration;
        }

        private void ReduceSpeed()
        {
            if (CurrentSpeed - _stopSpeed <= 0)
                CurrentSpeed = 0;
            else
                CurrentSpeed -= _stopSpeed;
        }

        private void RotateBody(float value)
        {
            _shipBody.Rotate(new Vector3(0, 0, -value), _rotatinSpeed);
            OnRotationChanged?.Invoke(_shipBody.rotation.eulerAngles.z);
        }

        public void OnPortalEnter()
        {
            var position = _shipTransform.anchoredPosition;

            Vector3 newPosition = position;

            if (position.x <= _playField.MinX)
                newPosition.x = _playField.MaxX;
            else if ((position.x >= _playField.MaxX))
                newPosition.x = _playField.MinX;


            if (position.y <= _playField.MinY)
                newPosition.y = _playField.MaxY;

            else if (position.y >= _playField.MaxY)
                newPosition.y = _playField.MinY;


            _shipTransform.anchoredPosition = newPosition;
            OnPositionChanged?.Invoke(newPosition.y, newPosition.x);
        }

        public void Shoot(Bullet bullet)
        {
            Instantiate(bullet, _shipTransform.position, _shipBody.rotation, _playField.Rect);
        }
        public void StopRotation()
        {
            _currentRotationSpeed = 0;
        }
        public void SetRotationSpeed(float value)
        {
            _currentRotationSpeed = value;
        }

        public void Restart()
        {
            CurrentSpeed = 0;
            StopRotation();

            _shipTransform.anchoredPosition = Vector2.zero;
            _shipTransform.rotation = Quaternion.identity;

            _shipBody.rotation = Quaternion.identity;

            _target.localRotation = Quaternion.identity;
            _target.localPosition = _targetStartPosition;

            _isInited = true;

        }

        public void OnGameOver()
        {
            _isInited = false;
        }
    }
}



