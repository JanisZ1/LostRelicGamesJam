using System;
using UnityEngine;

namespace Assets.Level4.Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        public int Health { get; private set; } = 10;
        [SerializeField] private DamageScreen _damageScreen;
        public event Action<int> OnTakeDamage;
        public event Action OnLose;
        public void TakeDamage(int damage)
        {
            Health -= damage;
            OnTakeDamage?.Invoke(Health);
            _damageScreen.ScreenEffect();
            if (Health <= 0)
            {
                Destroy(gameObject);
                OnLose?.Invoke();
            }

        }
    }
}

