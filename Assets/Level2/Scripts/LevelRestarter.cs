using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Level2.Scripts
{
    public class LevelRestarter : MonoBehaviour
    {
        [SerializeField] private SnakeIntersectionChecker _intersectionChecker;
        [SerializeField] private CrashSound _crashSound;
        private void Start() =>
            _intersectionChecker.OnLose += RestartCurrentLevel;
        private void RestartCurrentLevel() =>
            StartCoroutine(RestartLevel());
        private IEnumerator RestartLevel()
        {
            yield return new WaitWhile(() => _crashSound.AudioSource.isPlaying);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}
