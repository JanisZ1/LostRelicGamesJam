using UnityEngine;
using TMPro;
using System;

namespace Assets.Level4.Scripts
{
    public class TextHider : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        public event Action OnTextHide;
        private void Start() => 
            Invoke(nameof(HideText), 3f);
        private void HideText()
        {
            _text.enabled = false;
            OnTextHide?.Invoke();
        }
    }
}

