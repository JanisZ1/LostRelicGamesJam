using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Level1.Scripts
{
    public class LevelFinish : MonoBehaviour
    {
        private SaveLoadSystem _saveLoadSystem;
        private PuzzleCompletion _puzzleCompletion;
        private const string _sceneName = "02";
        private void Start()
        {
            _saveLoadSystem = FindObjectOfType<SaveLoadSystem>();
            _puzzleCompletion = FindObjectOfType<PuzzleCompletion>();
            _puzzleCompletion.OnPuzzleCompleted += SaveLevel;
        }
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.GetComponent<PlatformerPlayerMove>())
            {
                _saveLoadSystem.SaveCompletedLevel();
                SceneManager.LoadSceneAsync(_sceneName);
            }
        }
        private void SaveLevel() =>
            _saveLoadSystem.SaveCompletedLevel();
    }
}
