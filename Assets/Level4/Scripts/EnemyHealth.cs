using UnityEngine;

namespace Assets.Level4.Scripts
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int _health = 3;
        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
                Destroy(gameObject);
        }
    }
}