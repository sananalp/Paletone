using UnityEngine;
using Circle;

namespace Game
{
    public class CircleMatcher : MonoBehaviour
    {
        [SerializeField] private CircleSpawner _circleSpawner;
        [SerializeField] private GameState _state;
        private CircleBehaviour _circleA, _circleB;
        public CircleBehaviour circleA { get { return _circleA; } }
        public CircleBehaviour circleB { get { return _circleB; } }

        private void OnEnable()
        {
            _state.OnPlayStatesCalled[1] += TryGetCircles;
            _state.OnClickStatesCalled[0] += TryMatchCircles;
            _state.OnClickStatesCalled[1] += TryGetCircles;
        }
        private void OnDisable()
        {
            _state.OnPlayStatesCalled[1] -= TryGetCircles;
            _state.OnClickStatesCalled[0] -= TryMatchCircles;
            _state.OnClickStatesCalled[1] -= TryGetCircles;
        }
        private float GetDistance()
        {
            var distance = Mathf.Abs(_circleA.transform.position.y - _circleB.transform.position.y);
            
            return distance;
        }
        private int GetCircleCount()
        {
            var circleCount = _circleSpawner.circleList.Count;
            
            return circleCount;
        }
        private void TryMatchCircles()
        {
            var distance = GetDistance();

            if (distance < 0.5f)
            {
                _circleSpawner.circleList.Remove(_circleA);
                _circleSpawner.circleList.Remove(_circleB);
                _circleSpawner.removeCircleList.Add(_circleA);
                _circleSpawner.removeCircleList.Add(_circleB);
                _circleA.StopAllCoroutines();
                _circleB.StopAllCoroutines();
                _circleA.transform.position = _circleB.transform.position;
            }
        }
        private void TryGetCircles()
        {
            var circleCount = GetCircleCount();
            
            if (circleCount != 0)
            {
                _circleA = _circleSpawner.circleList[0];
                _circleB = _circleSpawner.circleList[1];
            }
            else
            {
                _state.PlayState();
                _state.WinState();
            }
        }
    }
}