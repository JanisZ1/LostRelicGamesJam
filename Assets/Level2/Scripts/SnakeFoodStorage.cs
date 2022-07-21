using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Level2.Scripts
{
    public class SnakeFoodStorage : MonoBehaviour
    {
        private Vector3Int _snakeHeadPosition;
        [SerializeField] private SnakeMove _snakeMove;
        [SerializeField] private SnakeFoodSpawner _foodSpawner;
        [SerializeField] private List<Vector3Int> _foodPositions;
        public event Action<Vector3Int, List<Vector3Int>> OnDataChange;
        private void Start() =>
            _snakeMove.OnMove += RefreshPositions;
        private void RefreshPositions()
        {
            _snakeHeadPosition = Vector3Int.RoundToInt(_snakeMove.transform.position);
            _foodPositions = _foodSpawner.SpawnedFoodPositions;
            OnDataChange?.Invoke(_snakeHeadPosition, _foodPositions);
        }
        private void OnDisable() =>
            _snakeMove.OnMove -= RefreshPositions;
    }
}