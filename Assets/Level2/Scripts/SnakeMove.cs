using System;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Assets.Level2.Scripts
{
    public class SnakeMove : MonoBehaviour
    {
        private const string _levelName = "03";
        [SerializeField] private SnakeParts _snakeParts;
        [SerializeField] private SnakePartsSpawner _snakePartsSpawner;
        [SerializeField] private CurrentScoreUI _currentScoreUI;
        public event Action OnMove;
        private SaveLoadSystem _saveLoadSystem;
        [SerializeField] private int _exitYPosition = -1;
        private void Start() =>
            _saveLoadSystem = FindObjectOfType<SaveLoadSystem>();
        public void Move(Vector3 direction)
        {
            Vector3 positionBeforeMove = transform.position;
            transform.position += direction;
            _snakeParts.Move(positionBeforeMove);
            OnMove?.Invoke();
            CheckExit();
        }

        private void CheckExit()
        {
            if (transform.position.y < _exitYPosition)
            {
                _saveLoadSystem.SaveCompletedLevel();
                SceneManager.LoadSceneAsync(_levelName);
            }
        }
    }
}
