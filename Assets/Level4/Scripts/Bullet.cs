using UnityEngine;

namespace Assets.Level4.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float _shotSpeed;
        [SerializeField] private int _damage = 1;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddRelativeForce(Vector3.forward * _shotSpeed);
            Invoke(nameof(DeleteBullet), 4f);
        }
        private void OnCollisionEnter(Collision collision)
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            if (enemyHealth) 
            {
                enemyHealth.TakeDamage(_damage);
                DeleteBullet();

            } 
        }
        private void DeleteBullet()
        {
            Destroy(gameObject);
        }
    }
}