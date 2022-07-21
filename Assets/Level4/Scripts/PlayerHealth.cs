using System;
using UnityEngine;
namespace Assets.Level4.Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _health = 10;
        [SerializeField] private DamageScreen _damageScreen;
        public event Action<int> OnTakeDamage;
        public event Action OnLose;
        public void TakeDamage(int damage)
        {
            _health -= damage;
            OnTakeDamage?.Invoke(_health);
            _damageScreen.ScreenEffect();
            if (_health <= 0)
            {
                Destroy(gameObject);
                OnLose?.Invoke();
            }

        }
    }
}

