using System.Collections.Generic;
using UnityEngine;

namespace Assets.Level2.Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        private float _timer;
        [SerializeField] private float _delayBeforeMove;
        [SerializeField] private SnakeMove _snakeMove;
        private int _keysToRemember = 2;
        [SerializeField] private List<Vector3> _pressedKeysList = new List<Vector3>();
        private Dictionary<KeyCode, Vector3Int> _directions = new Dictionary<KeyCode, Vector3Int>()
        {
            {KeyCode.W,Vector3Int.up },
            {KeyCode.S,Vector3Int.down },
            {KeyCode.A,Vector3Int.left },
            {KeyCode.D,Vector3Int.right },
        };
        private Vector3 _direction;
        private void Start() =>
            _direction = Vector3.right;
        private void Update()
        {
            
            _timer += Time.deltaTime;
            if (_timer > _delayBeforeMove)
            {
                _timer = 0;
                DirectionChangeAvailability();
                _snakeMove.Move(_direction);
            }
            foreach (var direction in _directions)
            {
                if (_pressedKeysList.Count < _keysToRemember)
                {
                    if (Input.GetKeyDown(direction.Key))
                    {
                        _pressedKeysList.Insert(0, direction.Value);
                    }
                }
            }
        }
        private void DirectionChangeAvailability()
        {
            if (_pressedKeysList.Count >= 1)
            {
                Vector3 directionToChange = _pressedKeysList[_pressedKeysList.Count - 1];
                if (_direction != -directionToChange)
                {
                    _direction = _pressedKeysList[_pressedKeysList.Count - 1];
                }
                _pressedKeysList.RemoveAt(_pressedKeysList.Count - 1);
            }
        }
    }
}