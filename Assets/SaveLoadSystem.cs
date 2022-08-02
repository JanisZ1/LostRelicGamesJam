using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadSystem : MonoBehaviour
{
    public int _openedLevelsCount = 1;
    private OpenLevelsUI _openLevelsUI;
    private const string _saveLoadKey = "OpenedLevels";
    private bool _firstTimeInGame;
    private void Awake() =>
        DontDestroyOnLoad(this);
    private void Start() =>
        CheckForFirstTimeInGame();
    private void Update() =>
        CheckCurrentSceneForMenu();
    private void CheckForFirstTimeInGame() =>
        _firstTimeInGame = !PlayerPrefs.HasKey(_saveLoadKey);

    private void OnApplicationQuit()
    {
        if (SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "01")
            PlayerPrefs.SetInt(_saveLoadKey, _openedLevelsCount);
    }

    public void CheckCurrentSceneForMenu()
    {
        if (_firstTimeInGame && SceneManager.GetActiveScene().name == "Menu")
        {
            _openLevelsUI = FindObjectOfType<OpenLevelsUI>();
            _openLevelsUI.ShowFirstTimeInGameLevelButton();
        }
        else if (SceneManager.GetActiveScene().name == "Menu" && _openedLevelsCount >= PlayerPrefs.GetInt(_saveLoadKey))
        {
            PlayerPrefs.SetInt(_saveLoadKey, _openedLevelsCount);
            _openLevelsUI = FindObjectOfType<OpenLevelsUI>();
            _openLevelsUI.ShowOpenedLevels(_openedLevelsCount);
        }
        else if (SceneManager.GetActiveScene().name == "Menu")
        {
            _openedLevelsCount = PlayerPrefs.GetInt(_saveLoadKey);
            _openLevelsUI = FindObjectOfType<OpenLevelsUI>();
            _openLevelsUI.ShowOpenedLevels(_openedLevelsCount);
        }
    }
#if UNITY_EDITOR
    [MenuItem("Edit/DeleteSave1")]
    public static void DeleteSave() =>
        PlayerPrefs.DeleteKey(_saveLoadKey);
#endif
    public void SaveCompletedLevel()
    {
        int activeSceneName = int.Parse(SceneManager.GetActiveScene().name);
        int levelsToSaveForFirstTimeInGame = 1;
        if (_firstTimeInGame)
        {
            PlayerPrefs.SetInt(_saveLoadKey, levelsToSaveForFirstTimeInGame);
            _firstTimeInGame = false;
        }
        if (activeSceneName == _openedLevelsCount)
        {
            _openedLevelsCount++;
        }
        
    }

}
