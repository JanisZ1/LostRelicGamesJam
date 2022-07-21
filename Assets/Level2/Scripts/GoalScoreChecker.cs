using System;
using UnityEngine;
using TMPro;

namespace Assets.Level2.Scripts
{
    public class GoalScoreChecker : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goalScoreText;
        public event Action OnGoalScoreReached;
        [SerializeField] private int _scoreGoal = 20;
        private void Start() =>
            _goalScoreText.text += _scoreGoal;
        public void CheckFinishCondition(int currentScore)
        {
            if (_scoreGoal == currentScore)
                OnScoreReached();
        }
        private void OnScoreReached() =>
            OnGoalScoreReached?.Invoke();
    }
}
