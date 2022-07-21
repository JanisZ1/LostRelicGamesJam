using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Level3.Scripts
{
    public class LevelRestarter : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}