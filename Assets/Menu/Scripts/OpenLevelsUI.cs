using UnityEngine;
using UnityEngine.UI;

public class OpenLevelsUI : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Image[] _images;
    public void ShowOpenedLevels(int openedLevelsCount)
    {
        for (int i = 0; i < openedLevelsCount ; i++)
        {
            _buttons[i].enabled = true;
            _images[i].enabled = true;
        }
    }
}
