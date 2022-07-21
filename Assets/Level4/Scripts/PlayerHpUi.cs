using UnityEngine;
using TMPro;
namespace Assets.Level4.Scripts
{
    public class PlayerHpUi : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        private string _hpStartText;
        [SerializeField] private TextMeshProUGUI _hpText;
        private void Start()
        {
            _hpStartText = _hpText.text;
            _playerHealth.OnTakeDamage += SetHpUi;
        }
        private void SetHpUi(int health) => 
            _hpText.text = _hpStartText + health.ToString();
        private void OnDisable() => 
            _playerHealth.OnTakeDamage -= SetHpUi;
    }
}

