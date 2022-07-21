using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadSystem : MonoBehaviour
{
    public int _openedLevelsCount = 1;
    private OpenLevelsUI _openLevelsUI;
    private void Awake() => 
        DontDestroyOnLoad(this);
    private void Start() =>
        CheckForFirstTimeInGame();
    private void Update() =>
        CheckCurrentSceneForMenu();
    private void CheckForFirstTimeInGame()
    {
        if (!PlayerPrefs.HasKey("OpenedLevels")) SceneManager.LoadSceneAsync("01");
    }
    private void OnApplicationQuit() =>
       PlayerPrefs.SetInt("OpenedLevels", _openedLevelsCount);
    public void CheckCurrentSceneForMenu()
    {
        if (SceneManager.GetActiveScene().name == "Menu" && _openedLevelsCount >= PlayerPrefs.GetInt("OpenedLevels"))
        {
            PlayerPrefs.SetInt("OpenedLevels", _openedLevelsCount);
            _openLevelsUI = FindObjectOfType<OpenLevelsUI>();
            _openLevelsUI.ShowOpenedLevels(_openedLevelsCount);
        }
        else if (SceneManager.GetActiveScene().name == "Menu")
        {
            _openedLevelsCount = PlayerPrefs.GetInt("OpenedLevels");
            _openLevelsUI = FindObjectOfType<OpenLevelsUI>();
            _openLevelsUI.ShowOpenedLevels(_openedLevelsCount);
        }
    }
#if UNITY_EDITOR
    [MenuItem("Edit/DeleteSave1")]
    public static void DeleteSave() =>
        PlayerPrefs.DeleteKey("OpenedLevels");
#endif
    public void SaveCompletedLevel()
    {
        int activeSceneName = int.Parse(SceneManager.GetActiveScene().name);
        if (activeSceneName == _openedLevelsCount)
        {
            _openedLevelsCount++;
        }
    }
   
}
