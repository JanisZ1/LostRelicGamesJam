using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private SurviveTimer _surviveTimer;
    private bool _winkeysEnabled;
    private void Start()
    {
        Time.timeScale = 1;
        _surviveTimer.Onwin += EnableText;
        _surviveTimer.Onwin += EnableWinKeys;
        
    }
    
    private void EnableText()
    {
        _winText.enabled = true;
    }
    private void EnableWinKeys()
    {
        _winkeysEnabled = true;
    }
    private void Update()
    {
        if (_winkeysEnabled)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadSceneAsync("Menu");
            }
        }
           
        
    }
    private void OnDisable()
    {
        _surviveTimer.Onwin -= EnableText;
        _surviveTimer.Onwin -= EnableWinKeys;
        
    }
}
