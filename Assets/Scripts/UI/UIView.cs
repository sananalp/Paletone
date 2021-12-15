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
            _state.OnWinStatesCalled[1] += ScoreView;
        }
        private void OnDisable()
        {
            _state.OnWinStatesCalled[1] -= ScoreView;
        }
        private void ScoreView()
        {
            var text = _playerController.player.score.ToString();
            _scoreText.text = text;
        }
    }
}