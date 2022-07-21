using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Level1.Scripts
{
    public class CanvasShow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _controlsText;
        [SerializeField] private TextMeshProUGUI _doubleJumpText;
        private void Start()
        {
            _controlsText.enabled = false;
            _doubleJumpText.enabled = false;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                _controlsText.enabled = !_controlsText.enabled;
        }
        public void ShowDoubleJump(int duration) =>
            StartCoroutine(ShowDoubleJumpText(duration));
        private IEnumerator ShowDoubleJumpText(int duration)
        {
            _doubleJumpText.enabled = true;
            yield return new WaitForSeconds(duration);
            _doubleJumpText.enabled = false;
        }
    }
}
