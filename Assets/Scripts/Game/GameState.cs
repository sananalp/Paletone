using UnityEngine;

namespace Game
{
    public class GameState : MonoBehaviour
    {
        public enum State { Play, Lose }
        [SerializeField] private State _gameState;
        public delegate void StateHandler();
        public StateHandler[] OnPlayStateCalled = new StateHandler[3];
        public StateHandler[] OnWinStateCalled = new StateHandler[3];
        public StateHandler[] OnClickStateCalled = new StateHandler[3];
        public StateHandler[] OnMissClickStateCalled = new StateHandler[3];
        public event StateHandler OnLoseStateCalled;
        public State gameState { get { return _gameState; } }

        private void Start()
        {
            PlayState();
        }
        public void PlayState()
        {
            foreach (StateHandler state in OnPlayStateCalled)
            {
                state?.Invoke();
            }
            _gameState = State.Play;
        }
        public void WinState()
        {
            foreach (StateHandler state in OnWinStateCalled)
            {
                state?.Invoke();
            }
        }
        public void ClickState()
        {
            foreach (StateHandler state in OnClickStateCalled)
            {
                state?.Invoke();
            }
        }
        public void MissClickState()
        {
            foreach (StateHandler state in OnMissClickStateCalled)
            {
                state?.Invoke();
            }
        }
        public void LoseState()
        {
            OnLoseStateCalled?.Invoke();
            _gameState = State.Lose;
        }
    }
}