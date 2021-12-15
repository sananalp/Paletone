using UnityEngine;
using Game;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameState _state;
        private PlayerModel _player;
        public PlayerModel player { get { return _player; } }

        private void OnEnable()
        {
            _player = new PlayerModel();
            _state.OnWinStatesCalled[0] += ScoreChange;
        }
        private void OnDisable()
        {
            _state.OnWinStatesCalled[0] -= ScoreChange;
        }
        private void ScoreChange()
        {
            ++_player.score;
        }
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                _state.ClickState();
            }
        }
    }
    public class PlayerModel
    {
        private int _health;
        private int _score;

        public int health { get { return _health; } set { _health = value; } }
        public int score { get { return _score; } set { _score = value; } }
    }
}
