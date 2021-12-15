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
            _state.OnPlayStateCalled[1] += TryGetCircles;
            _state.OnClickStateCalled[0] += TryMatchCircles;
            _state.OnClickStateCalled[1] += TryGetCircles;
        }
        private void OnDisable()
        {
            _state.OnPlayStateCalled[1] -= TryGetCircles;
            _state.OnClickStateCalled[0] -= TryMatchCircles;
            _state.OnClickStateCalled[1] -= TryGetCircles;
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

            if (distance < 0.3f)
            {
                _circleSpawner.circleList.Remove(_circleA);
                _circleSpawner.circleList.Remove(_circleB);
                _circleSpawner.removeCircleList.Add(_circleA);
                _circleSpawner.removeCircleList.Add(_circleB);
                _circleA.StopAllCoroutines();
                _circleB.StopAllCoroutines();
            }
            else
            {
                _state.MissClickState();
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