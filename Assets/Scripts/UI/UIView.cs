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

        private void OnEnable()
        {
            _state.OnWinStateCalled[1] += ScoreView;
            _state.OnMissClickStateCalled[1] += HealthView;
            _state.OnLoseStateCalled += LoseView;
        }
        private void OnDisable()
        {
            _state.OnWinStateCalled[1] -= ScoreView;
            _state.OnMissClickStateCalled[1] -= HealthView;
            _state.OnLoseStateCalled -= LoseView;
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

        }
    }
}