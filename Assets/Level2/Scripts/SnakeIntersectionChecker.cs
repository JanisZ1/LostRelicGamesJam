using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Level2.Scripts
{
    public class SnakeIntersectionChecker : MonoBehaviour
    {
        [SerializeField] private IntersectionObjectsStorage _intersectionObjectsStorage;
        [SerializeField] private SnakeFoodStorage _snakeFoodStorage;
        public event Action OnLose;
        public event Action<Vector3Int, List<Vector3Int>> OnFoodEat;
        private void Start()
        {
            _intersectionObjectsStorage.OnDataChange += CheckIntersection;
            _snakeFoodStorage.OnDataChange += CheckIntersectionWithFood;
        }
        private void OnEnable()
        {
            _intersectionObjectsStorage.OnDataChange += CheckIntersection;
            _snakeFoodStorage.OnDataChange += CheckIntersectionWithFood;
        }
        private void OnDisable()
        {
            _intersectionObjectsStorage.OnDataChange -= CheckIntersection;
            _snakeFoodStorage.OnDataChange -= CheckIntersectionWithFood;
        }
        public void CheckIntersection(Vector3Int snakeHeadPosition, IEnumerable<Vector3Int> collection)
        {
            Debug.Log(collection.Count());
            if (collection.Contains(snakeHeadPosition))
                OnLose?.Invoke();
        }
        public void CheckIntersectionWithFood(Vector3Int snakeHeadPosition, List<Vector3Int> foodCollection)
        {

            if (foodCollection.Contains(snakeHeadPosition))
            {
                Vector3Int foodPosition = snakeHeadPosition;
                OnFoodEat?.Invoke(foodPosition, _intersectionObjectsStorage.SnakePositions);
            }

        }

    }
}