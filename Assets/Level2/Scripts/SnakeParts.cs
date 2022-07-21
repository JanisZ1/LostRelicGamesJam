using System.Collections.Generic;
using UnityEngine;

namespace Assets.Level2.Scripts
{
    public class SnakeParts : MonoBehaviour
    {
        public List<Vector3Int> SnakepartsPositions { get; private set; } = new List<Vector3Int>();
        [SerializeField] private List<Transform> _snakeParts = new List<Transform>();

        [SerializeField] private Transform _snakePartPrefab;
        private void Start()
        {
            foreach (Transform snake in _snakeParts)
                SnakepartsPositions.Add(Vector3Int.RoundToInt(snake.position));
        }
        public void AddSnakePartToLists(Transform newPart)
        {
            _snakeParts.Add(newPart);
            SnakepartsPositions.Add(Vector3Int.RoundToInt(newPart.position));
        }

        public void Move(Vector3 position)
        {
            SnakepartsPositions.Insert(0, Vector3Int.RoundToInt(position));
            SnakepartsPositions.RemoveAt(SnakepartsPositions.Count - 1);
            for (int i = 0; i < _snakeParts.Count; i++)
                _snakeParts[i].position = new Vector3(SnakepartsPositions[i].x, SnakepartsPositions[i].y, 0);
        }
    }
}