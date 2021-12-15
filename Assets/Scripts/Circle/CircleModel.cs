using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Circle
{
    public class CircleModel
    {
        private float _distance;
        private int _speed;
        private float _angle;
        private Color _color;

        public float Distance { get { return _distance; } set { _distance = value; } }
        public int Speed { get { return _speed; } set { _speed = value; } }
        public float Angle { get { return _angle; } set { _angle = value; } }
        public Color Color { get { return _color; } set { _color = value; } }
    }
}