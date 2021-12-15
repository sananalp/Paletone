using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

namespace Circle
{
    public class CircleBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform _targetObject;
        private Vector3 _point;
        private float _x, _y;
        private CircleModel _circle;
        [SerializeField] private GameState _state;
        public CircleModel circle { get { return _circle; } set { _circle = value; } }
        public Transform targetObject { get { return _targetObject; } set { _targetObject = value; } }

        private void OnEnable()
        {
            StartCoroutine(RotateCoroutine());   
        }
        private void OnDisable()
        {
            StopCoroutine(RotateCoroutine());
        }
        private void RotateAround()
        {
            _circle.Angle += Mathf.Deg2Rad * _circle.Speed * Time.deltaTime;
            _x = Mathf.Cos(_circle.Angle) * _circle.Distance;
            _y = Mathf.Sin(_circle.Angle) * _circle.Distance;
            _point.x = _x;
            _point.y = _y;
            transform.position = new Vector3(_point.x, _point.y, _targetObject.position.z);
        }
        public void StopRotate()
        {
            StopCoroutine(RotateCoroutine());
        }
        IEnumerator RotateCoroutine()
        {
            while (true)
            {
                yield return null;
                RotateAround();
            }
        }
    }
}