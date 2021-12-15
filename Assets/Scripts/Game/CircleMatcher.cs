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
            var distanceX = Mathf.Abs(_circleA.transform.position.x - _circleB.transform.position.x);
            var distanceY = Mathf.Abs(_circleA.transform.position.y - _circleB.transform.position.y);
            var sum = distanceX * distanceY;
            
            return sum;
        }
        private int GetCircleCount()
        {
            var circleCount = _circleSpawner.circleList.Count;
            
            return circleCount;
        }
        private void TryMatchCircles()
        {
            var distance = GetDistance();

            if (distance < 0.25f)
            {
                _circleSpawner.circleList.Remove(_circleA);
                _circleSpawner.circleList.Remove(_circleB);
                _circleSpawner.removeCircleList.Add(_circleA);
                _circleSpawner.removeCircleList.Add(_circleB);
                _circleA.StopAllCoroutines();
                _circleB.StopAllCoroutines();
                _circleA.transform.position = _circleB.transform.position;
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
            else if(_state.gameState != GameState.State.Lose)
            {
                _state.PlayState();
                _state.WinState();
            }
        }
    }
}