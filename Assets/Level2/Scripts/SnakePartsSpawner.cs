using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Level2.Scripts
{
    public class SnakePartsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private SnakeParts _snakeParts;
        [SerializeField] private Transform _snakePartPrefab;
        [SerializeField] private SnakeIntersectionChecker _snakeIntersectionChecker;
        private int _scoreToAdd = 1;
        public event Action<int> OnPartSpawn;
        private void Start() => 
            _snakeIntersectionChecker.OnFoodEat += SpawnNewPart;
        //Second parameter isnt used because of delegate
        public void SpawnNewPart(Vector3Int snakeHeadPosition, List<Vector3Int> collection)
        {
            Transform newPart = Instantiate(_snakePartPrefab, snakeHeadPosition, Quaternion.identity, _parent);
            _snakeParts.AddSnakePartToLists(newPart);
            OnPartSpawn?.Invoke(_scoreToAdd);
        }
    }
}