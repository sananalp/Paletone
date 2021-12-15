using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameState : MonoBehaviour
    {
        public delegate void StateHandler();
        public StateHandler[] OnPlayStatesCalled = new StateHandler[3];
        public event StateHandler OnWinStateCalled;
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
            OnWinStateCalled?.Invoke();
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