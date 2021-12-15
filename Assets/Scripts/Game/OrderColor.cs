using UnityEngine;

namespace Game
{
    public class OrderColor : MonoBehaviour
    {
        [SerializeField] private GameState _state;
        [SerializeField] private CircleMatcher _circleMatcher;

        private void OnEnable()
        {
            _state.OnPlayStatesCalled[2] += SetOrderColor;
            _state.OnClickStatesCalled[2] += SetOrderColor;
        }
        private void OnDisable()
        {
            _state.OnPlayStatesCalled[2] -= SetOrderColor;
            _state.OnClickStatesCalled[2] -= SetOrderColor;
        }
        public void SetOrderColor()
        {
            var circleA = _circleMatcher.circleA;
            var circleB = _circleMatcher.circleB;
            var colorA = circleA.GetComponent<SpriteRenderer>().color;
            var colorB = circleB.GetComponent<SpriteRenderer>().color;
            colorA.a = 1.0f;
            colorB.a = 1.0f;
            GetComponent<SpriteRenderer>().color = Color.Lerp(colorA, colorB, 0.5f);
        }
    }
}