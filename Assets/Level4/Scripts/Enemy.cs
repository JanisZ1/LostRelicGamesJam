using System.Collections;
using UnityEngine;

namespace Assets.Level4.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private ShooterPlayerMove _playerMove;
        [SerializeField] private float _speed;
        [SerializeField] private int _damage = 1;
        private bool _playerDamaged;
        private void Start()
        {
            _playerMove = FindObjectOfType<ShooterPlayerMove>();
        }
        private void Update()
        {
            if (_playerMove != null)
            {
                transform.LookAt(_playerMove.transform.position);
                transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                _playerDamaged = true;
                StartCoroutine(DamageDelay(playerHealth));
            }
        }
        private IEnumerator DamageDelay(PlayerHealth playerHealth)
        {
            if (_playerDamaged)
            {
                GetComponent<Collider>().enabled = false;
                playerHealth.TakeDamage(_damage);
                yield return new WaitForSeconds(1);
                GetComponent<Collider>().enabled = true;
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth)
                _playerDamaged = false;
        }
    }
}