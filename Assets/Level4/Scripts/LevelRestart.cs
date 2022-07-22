using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Level4.Scripts
{
    public class LevelRestart : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        private void Start() => 
            _playerHealth.OnLose += Restart;
        public void Restart() => 
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        private void OnDisable() => 
            _playerHealth.OnLose -= Restart;
    }
}

