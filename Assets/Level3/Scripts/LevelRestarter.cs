using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Level3.Scripts
{
    public class LevelRestarter : MonoBehaviour
    {
        [SerializeField] private LoseChecker _loseChecker;
        private void Start() =>
            _loseChecker.OnLose += RestartLevel;
        private void OnEnable() => 
            _loseChecker.OnLose += RestartLevel;
        private void OnDisable() => 
            _loseChecker.OnLose -= RestartLevel;
        private void RestartLevel() =>
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}