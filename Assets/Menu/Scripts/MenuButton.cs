using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Menu.Scripts
{
    public abstract class MenuButton : MonoBehaviour
    {
        public Action OnLevelCompleted;
        public GameObject[] SceneObjects;
        public virtual void Start()
        {
            OnLevelCompleted += EnableLevel;
        }
        public void EnableLevel()
        {
            OnLevelCompleted -= EnableLevel;
        }
        public void TryEnterLevel(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
