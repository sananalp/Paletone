using UnityEngine;

namespace Circle
{
    public class CircleModel
    {
        private float _distance;
        private int _speed;
        private float _angle;
        private Color _color;

        public float distance { get { return _distance; } set { _distance = value; } }
        public int speed { get { return _speed; } set { _speed = value; } }
        public float angle { get { return _angle; } set { _angle = value; } }
        public Color color { get { return _color; } set { _color = value; } }
    }
}