using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;

namespace Assets.Level2.Scripts
{
    public class SnakeFoodSpawner : MonoBehaviour
    {
        [SerializeField] private Food _foodPrefab;
        [SerializeField] private SnakeIntersectionChecker _snakeIntersectionChecker;
        private List<Vector3Int> _spawnedFoodPositions = new List<Vector3Int>();
        [SerializeField] private List<Transform> _spawnedFood = new List<Transform>();
        [SerializeField] private List<Vector3Int> _allPositions = new List<Vector3Int>();
        public event Action OnFoodSpawn;
        private void Start()
        {
            _spawnedFoodPositions.Add(_spawnedFood[0].position.ToVector3Int());

            _snakeIntersectionChecker.OnFoodEat += SpawnNewFood;
            for (int x = 0; x < 21; x++)
            {
                for (int y = 0; y < 11; y++)
                {
                    _allPositions.Add(new Vector3Int(x, y, 0));
                }
            }
        }

        private void DestroyEatedFood(Vector3Int foodPosition)
        {
            for (int i = 0; i < _spawnedFood.Count; i++)
            {
                if (foodPosition == _spawnedFood[i].transform.position.ToVector3Int())
                {
                    Destroy(_spawnedFood[i].gameObject);
                    _spawnedFoodPositions.Remove(foodPosition);
                    _spawnedFood.Remove(_spawnedFood[i]);
                }
            }
        }

        private void OnDisable() =>
            _snakeIntersectionChecker.OnFoodEat -= SpawnNewFood;
        public IEnumerable<Transform> GetFood()
        {
            foreach (var food in _spawnedFood)
                yield return food;
        }
        public IEnumerable<Vector3Int> GetFoodPositions()
        {
            foreach (var food in _spawnedFoodPositions)
                yield return food;
        }
        public void SpawnNewFood(Vector3Int foodPosition, List<Vector3Int> snakePositions)
        {
            DestroyEatedFood(foodPosition);


            var freePositions = _allPositions.Except(snakePositions);
            int count = freePositions.Count();
            var randomValue = Random.Range(0, count);
            var randomPosition = freePositions.ElementAt(randomValue);
            Debug.Log(count);
            Food newFood = Instantiate(_foodPrefab, randomPosition, Quaternion.identity);
            _spawnedFoodPositions.Add(newFood.transform.position.ToVector3Int());
            _spawnedFood.Add(newFood.transform);
            OnFoodSpawn?.Invoke();
        }
    }
}