using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OpenLevelsUI : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Image[] _images;
    [SerializeField] private TextMeshProUGUI[] _texts;
    [SerializeField] private Button _firstTimeInGameButton;
    [SerializeField] private Image _firstTimeInGameImage;
    [SerializeField] private TextMeshProUGUI _firstTimeInGameText;
    public void ShowOpenedLevels(int openedLevelsCount)
    {
        for (int i = 0; i < openedLevelsCount; i++)
        {
            _buttons[i].enabled = true;
            _images[i].enabled = true;
            _texts[i].enabled = true;
        }
    }
    public void ShowFirstTimeInGameLevelButton()
    {
        _firstTimeInGameButton.enabled = true;
        _firstTimeInGameImage.enabled = true;
        _firstTimeInGameText.enabled = true;
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].enabled = false;
            _images[i].enabled = false;
            _texts[i].enabled = false;
        }
    }
}
