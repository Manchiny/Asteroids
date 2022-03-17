using UnityEngine;

namespace Assets.Scripts.Core
{
   public class PlayField : MonoBehaviour
    {
        private RectTransform _rect;
        public RectTransform Rect => _rect;

        private float _minX;
        private float _maxX;

        private float _minY;
        private float _maxY;

        public float MinX => _minX;
        public float MaxX => _maxX;
        public float MinY => _minY;
        public float MaxY => _maxY;

        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
            UpdatePlayFieldBounds(_rect);
        }
        private void UpdatePlayFieldBounds(RectTransform playfield)
        {
            _minX = playfield.rect.xMin;
            _maxX = playfield.rect.xMax;

            _minY = playfield.rect.yMin;
            _maxY = playfield.rect.yMax;
        }
    }
}


