using System.Collections;
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
            _circle.angle += Mathf.Deg2Rad * _circle.speed * Time.deltaTime;
            _x = Mathf.Cos(_circle.angle) * _circle.distance;
            _y = Mathf.Sin(_circle.angle) * _circle.distance;
            _point.x = _x;
            _point.y = _y;
            transform.position = new Vector3(_point.x, _point.y, _targetObject.position.z);
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