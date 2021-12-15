using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameState _state;
        
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                _state.ClickState();
            }
        }
    }
}
