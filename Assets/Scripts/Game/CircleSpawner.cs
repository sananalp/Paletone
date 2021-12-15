using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Circle;

namespace Game
{
    public class CircleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _spawnPrefab;
        [SerializeField] private Transform _spawnParent;
        [SerializeField] private Transform _targetObject;
        [SerializeField] private int _spawnCount;
        private List<CircleBehaviour> _circleList = new List<CircleBehaviour>();
        [SerializeField] private List<CircleBehaviour> _removeCircleList = new List<CircleBehaviour>();
        [SerializeField] private GameState _state;
        public List<CircleBehaviour> circleList { get { return _circleList; } }
        public List<CircleBehaviour> removeCircleList { get { return _removeCircleList; } }

        private void OnEnable()
        {
            _state.OnPlayStatesCalled[0] += CreateCircle;
            _state.OnWinStateCalled += DestroyAllCircles;
        }
        private void OnDisable()
        {
            _state.OnPlayStatesCalled[0] -= CreateCircle;
            _state.OnWinStateCalled -= DestroyAllCircles;
        }
        private void CreateCircle()
        {
            for (int i = 0; i < _spawnCount; i++)
            {
                var spawnObject = Instantiate(_spawnPrefab, _spawnParent);
                var speedRange = Random.Range(20, 50);
                var angleRange = Random.Range(0, 360.0f);
                var behaviour = spawnObject.AddComponent<CircleBehaviour>();
                var spriteRenderer = spawnObject.GetComponent<SpriteRenderer>();
                behaviour.targetObject = _targetObject;
                behaviour.circle = new CircleModel();
                var step = i % 2;
                behaviour.circle.Speed = step == 0 ? speedRange : -speedRange;
                behaviour.circle.Angle = angleRange;
                behaviour.circle.Distance = 3;
                spriteRenderer.sortingOrder = step == 0 ? 0 : 1;
                var colorAlpha = step == 0 ? 1.0f : 0.5f;
                behaviour.circle.Color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f), colorAlpha);
                spriteRenderer.color = behaviour.circle.Color;
                _circleList.Add(behaviour);
            }
        }
        private void DestroyAllCircles()
        {
            foreach (CircleBehaviour circle in _removeCircleList)
            {
                Destroy(circle.gameObject);
            }
            _removeCircleList.Clear();
        }
    }
}