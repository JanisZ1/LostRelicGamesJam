using UnityEngine;
using TMPro;
using System;

namespace Assets.Level4.Scripts
{
    public class SurviveTimer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextHider _textHider;
        private const float SurviveTime = 60;
        private float _leftTimeToSurvive;
        private bool _timerStarted;
        public event Action Onwin;
        private void Start()
        {
            _leftTimeToSurvive = SurviveTime;
            _textHider.OnTextHide += StartTimer;
        }
        private void StartTimer() =>
            _timerStarted = true;
        void Update()
        {
            if (_timerStarted)
            {
                if (_leftTimeToSurvive > 0)
                {
                    _leftTimeToSurvive -= Time.deltaTime;
                }
                else
                {
                    _leftTimeToSurvive = 0;
                    _timerStarted = false;
                    Onwin?.Invoke();
                }
                _timerText.text = "Time Left : " + _leftTimeToSurvive.ToString("000.00");
            }
        }
        private void OnDisable() =>
            _textHider.OnTextHide -= StartTimer;
    }
}

