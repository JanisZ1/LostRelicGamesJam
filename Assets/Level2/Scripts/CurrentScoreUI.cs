using TMPro;
using UnityEngine;

namespace Assets.Level2.Scripts
{
    public class CurrentScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private GoalScoreChecker _goalScoreChecker;
        private int _score;
        private string _currentScoreText;
        [SerializeField] private SnakePartsSpawner _spawner;
        private void Start()
        {
            _currentScoreText = _scoreText.text;
            _spawner.OnPartSpawn += AddScore;
        }
        private void AddScore(int score)
        {
            _score += score;
            _scoreText.text = _currentScoreText + _score;
            _goalScoreChecker.CheckFinishCondition(_score);
        }

        private void OnDisable() =>
            _spawner.OnPartSpawn -= AddScore;

    }
}
