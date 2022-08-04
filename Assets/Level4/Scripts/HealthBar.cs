using UnityEngine;

namespace Assets.Level4.Scripts
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Transform _backGround;
        [SerializeField] private EnemyHealth _enemyHealth;
        private void Start() =>
            _enemyHealth.OnHealthChange += SetScale;
        private void SetScale(int health, int maxHealth) =>
            _backGround.localScale = new Vector3((float)health / maxHealth, 1, 1);
        private void OnDisable() =>
            _enemyHealth.OnHealthChange -= SetScale;
    }
}