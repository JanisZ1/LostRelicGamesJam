using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

namespace Assets.Level3.Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        private const string _levelName = "04";
        [SerializeField] private TextMeshProUGUI _goalScoreText;
        [SerializeField] private TextMeshProUGUI _currentScoreText;
        private string _scoreText;
        [SerializeField] private int _goalScore = 10;
        private int _currentScore;
        public Action<int> OnScoreAdd;
        public event Action OnWin;
        private SaveLoadSystem _saveLoadSystem;
        private void Start()
        {
            _saveLoadSystem = FindObjectOfType<SaveLoadSystem>();
            _goalScoreText.text += _goalScore;
            _scoreText = _currentScoreText.text;
            OnScoreAdd += AddScore;
            OnWin += GotoNextScene;
        }
        private void AddScore(int score)
        {
            _currentScore += score;
            _currentScoreText.text = _scoreText + _currentScore;
            if (_goalScore == _currentScore) OnWin?.Invoke();
        }
        private void GotoNextScene()
        {
            _saveLoadSystem.SaveCompletedLevel();
            SceneManager.LoadSceneAsync(_levelName);
        }

        private void OnDisable()
        {
            OnWin -= GotoNextScene;
            OnScoreAdd -= AddScore;
        }
    }
}
