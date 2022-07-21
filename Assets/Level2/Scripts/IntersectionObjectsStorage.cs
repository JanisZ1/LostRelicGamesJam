using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Level2.Scripts
{
    public class IntersectionObjectsStorage : MonoBehaviour
    {
        private Vector3Int _snakeHeadPosition;
        public List<Vector3Int> SnakePositions { get; private set; }
        [SerializeField] private SnakeMove _snakeMove;
        [SerializeField] private SnakeParts _snakeParts;
        [SerializeField] private List<Wall> _walls;
        [SerializeField] private List<Wall> _wallsToDelete;
        [SerializeField] private GoalScoreChecker _goalScoreChecker;
        public List<Vector3Int> WallPositions { get; private set; } = new List<Vector3Int>();
        public event Action<Vector3Int, IEnumerable<Vector3Int>> OnDataChange;
        private void Start()
        {
            _goalScoreChecker.OnGoalScoreReached += DeleteWalls;
            _snakeMove.OnMove += RefreshPositionOfSnake;
            InitializeWallPositions();
        }
        private void DeleteWalls()
        {
            var wallsToDelete = _walls.Intersect(_wallsToDelete).ToList();
            Debug.Log("WallsToDelete" + wallsToDelete.Count);
            for (int i = 0; i < wallsToDelete.Count; i++)
            {
                Destroy(wallsToDelete[i].gameObject);
                WallPositions.Remove(Vector3Int.RoundToInt(wallsToDelete[i].transform.position));
            }
            for (int i = 0; i < wallsToDelete.Count; i++)
            {
                _walls.Remove(wallsToDelete[i]);
            }

        }
        private void InitializeWallPositions()
        {
            _walls = FindObjectsOfType<Wall>().ToList();
            for (int i = 0; i < _walls.Count; i++)
                WallPositions.Add(Vector3Int.RoundToInt(_walls[i].transform.position));
        }
        private void RefreshPositionOfSnake()
        {
            _snakeHeadPosition = Vector3Int.RoundToInt(_snakeMove.transform.position);
            SnakePositions = _snakeParts.SnakepartsPositions;
            OnDataChange?.Invoke(_snakeHeadPosition, WallPositions);
            OnDataChange?.Invoke(_snakeHeadPosition, SnakePositions);
        }
        private void OnDisable()
        {
            _snakeMove.OnMove -= RefreshPositionOfSnake;
            _goalScoreChecker.OnGoalScoreReached -= DeleteWalls;
        }
    }
}