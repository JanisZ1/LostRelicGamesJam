using System.Collections;
using UnityEngine;

namespace Assets.Level4.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Enemy _enemyPrefab;
        private Vector3 _currentSpawnPoint;
        [SerializeField] private float _spawnDelay;
        private void Start()
        {
            StartCoroutine(SpawnEnemy());
        }
        private IEnumerator SpawnEnemy()
        {
            yield return new WaitForSeconds(_spawnDelay);
            RandomSpawnPoints();
            StartCoroutine(SpawnEnemy());
        }
        private void RandomSpawnPoints()
        {
            int randomSpawnPoint = Random.Range(0, _spawnPoints.Length);
            _currentSpawnPoint = _spawnPoints[randomSpawnPoint].position;
            Spawn();
        }
        private void Spawn()
        {
            Instantiate(_enemyPrefab.gameObject, _currentSpawnPoint, Quaternion.identity);
        }
    }
}