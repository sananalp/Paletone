using UnityEngine;

namespace Game
{
    public class GameState : MonoBehaviour
    {
        public delegate void StateHandler();
        public StateHandler[] OnPlayStatesCalled = new StateHandler[3];
        public StateHandler[] OnWinStatesCalled = new StateHandler[3];
        public StateHandler[] OnClickStatesCalled = new StateHandler[3];

        private void Start()
        {
            PlayState();
        }
        public void PlayState()
        {
            foreach (StateHandler state in OnPlayStatesCalled)
            {
                state?.Invoke();
            }
        }
        public void WinState()
        {
            foreach (StateHandler state in OnWinStatesCalled)
            {
                state?.Invoke();
            }
        }
        public void ClickState()
        {
            foreach (StateHandler state in OnClickStatesCalled)
            {
                state?.Invoke();
            }
        }
    }
}