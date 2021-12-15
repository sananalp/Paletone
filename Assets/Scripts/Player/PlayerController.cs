using UnityEngine;
using Game;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameState _state;
        private PlayerModel _player;
        public PlayerModel player { get { return _player; } }

        private void Awake()
        {
            _player = new PlayerModel();
        }
        private void OnEnable()
        {
            _state.OnWinStateCalled[0] += ScoreChange;
            _state.OnMissClickStateCalled[0] += HealthChange;
        }
        private void OnDisable()
        {
            _state.OnWinStateCalled[0] -= ScoreChange;
            _state.OnMissClickStateCalled[0] -= HealthChange;
        }
        private void ScoreChange()
        {
            _player.score++;
        }
        private void HealthChange()
        {
            _player.health--;
        }
        private void Update()
        {
            if (Input.GetMouseButtonUp(0) && _state.gameState == GameState.State.Play)
            {
                _state.ClickState();
            }
        }
    }
    public class PlayerModel
    {
        private int _health = 3;
        private int _score;

        public int health { get { return _health; } set { _health = value; } }
        public int score { get { return _score; } set { _score = value; } }
    }
}
