using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Level2.Scripts
{
    public class LevelRestarter : MonoBehaviour
    {
        [SerializeField] private SnakeIntersectionChecker _intersectionChecker;

        private void Start() =>
            _intersectionChecker.OnLose += RestartLevel;

        private void RestartLevel() => 
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
