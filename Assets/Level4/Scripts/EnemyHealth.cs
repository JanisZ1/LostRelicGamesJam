using UnityEngine;
using System;

namespace Assets.Level4.Scripts
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int _health = 3;
        private int _maxHealth;
        public event Action<int,int> OnHealthChange;
        private void Start() => 
            _maxHealth = _health;

        public void TakeDamage(int damage)
        {
            _health -= damage;
            OnHealthChange?.Invoke(_health,_maxHealth);
            if (_health <= 0)
                Destroy(gameObject);
        }
    }
}