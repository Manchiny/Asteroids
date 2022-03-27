using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spaceship : MonoBehaviour
    {
        [SerializeField] private RectTransform _target;
        [SerializeField] private RectTransform _shipBody;
        [SerializeField] private ShipBoundsChecker _boundsChecker;

        private RectTransform _shipTransform;

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
        public ShipBoundsChecker ShipBoundsChecker => _boundsChecker;
        public RectTransform ShipBody => _shipBody;

        private bool _isAccelerate;
        private bool _isInited;

        public Action<float> OnRotationChanged;
        public Action<float> OnSpeedChanged;
        public Action<float, float> OnPositionChanged;

        public void Init(float maxMoveSpeed, float acceleration, float rotaionSpeed, float stopSpeed)
        {
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
        private void Move()
        {
            var targetPosition = _target.position;

            ShipTransform.position += (targetPosition - ShipTransform.position) * CurrentSpeed * Time.deltaTime;

            OnPositionChanged?.Invoke(ShipTransform.anchoredPosition.y, ShipTransform.anchoredPosition.x);
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

            ShipTransform.anchoredPosition = Vector2.zero;
            ShipTransform.rotation = Quaternion.identity;

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



