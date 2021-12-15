using UnityEngine;
using UnityEngine.UI;
using Game;

namespace Player
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private GameState _state;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Image[] _healthSprites = new Image[3];
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private Text _messageText;

        private void OnEnable()
        {
            _state.OnWinStateCalled[1] += ScoreView;
            _state.OnMissClickStateCalled[1] += HealthView;
            _state.OnLoseStateCalled += LoseView;
            _state.OnPlayStateCalled[1] += PlayView;
        }
        private void OnDisable()
        {
            _state.OnWinStateCalled[1] -= ScoreView;
            _state.OnMissClickStateCalled[1] -= HealthView;
            _state.OnLoseStateCalled -= LoseView;
            _state.OnPlayStateCalled[1] -= PlayView;
        }
        private void ScoreView()
        {
            var text = _playerController.player.score.ToString();
            _scoreText.text = text;
        }
        private void HealthView()
        {
            var health = _playerController.player.health;

            if(health >= 0) _healthSprites[health].color = Color.black;
            if(health == 0) { _state.LoseState(); }
        }
        private void LoseView()
        {
            _messageText.text = "Game Over";
            _restartButton.SetActive(true);
        }
        private void PlayView()
        {
            _messageText.text = "Try to match colors to get a order color";
            _restartButton.SetActive(false);
        }
    }
}