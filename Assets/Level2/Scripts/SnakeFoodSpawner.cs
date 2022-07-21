using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets.Level2.Scripts
{
    public class SnakeFoodSpawner : MonoBehaviour
    {
        [SerializeField] private Food _foodPrefab;
        [SerializeField] private SnakeIntersectionChecker _snakeIntersectionChecker;
        public List<Vector3Int> SpawnedFoodPositions = new List<Vector3Int>();
        public List<Transform> SpawnedFood = new List<Transform>();
        [SerializeField] private List<Vector3Int> _allPositions = new List<Vector3Int>();
        private void Start()
        {
            SpawnedFoodPositions.Add(Vector3Int.RoundToInt(SpawnedFood[0].position));

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
            for (int i = 0; i < SpawnedFood.Count; i++)
            {
                if (foodPosition == Vector3Int.RoundToInt(SpawnedFood[i].transform.position))
                {
                    Destroy(SpawnedFood[i].gameObject);
                    SpawnedFoodPositions.Remove(foodPosition);
                    SpawnedFood.Remove(SpawnedFood[i]);
                }
            }
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
            SpawnedFoodPositions.Add(Vector3Int.RoundToInt(newFood.transform.position));
            SpawnedFood.Add(newFood.transform);
        }
        private void OnDisable() =>
            _snakeIntersectionChecker.OnFoodEat -= SpawnNewFood;
    }
}