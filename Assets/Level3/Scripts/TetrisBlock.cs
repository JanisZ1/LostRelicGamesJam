using System;
using UnityEngine;

namespace Assets.Level3.Scripts
{
    public class TetrisBlock : MonoBehaviour
    {
        public Vector3 RotationPoint;
        private float _previousTime;
        private float _fallTime = 0.8f;
        public static int Height = 16;
        public static int Width = 10;
        private static Transform[,] _grid = new Transform[Width, Height];
        [SerializeField] private ScoreManager _scoreManager;
        private LoseChecker _loseChecker;
        private void Start()
        {
            _scoreManager = FindObjectOfType<ScoreManager>();
            _loseChecker = FindObjectOfType<LoseChecker>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left;
                if (!ValidMove())
                    transform.position -= Vector3.left;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += Vector3.right;
                if (!ValidMove())
                    transform.position -= Vector3.right;
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Rotate(0, 0, 90f);
                if (!ValidMove())
                    transform.Rotate(0, 0, -90f);
            }
            if (Time.time - _previousTime > (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ? _fallTime / 10 : _fallTime))
            {
                transform.position += Vector3.down;
                if (!ValidMove())
                {
                    transform.position -= Vector3.down;
                    AddToGrid();
                    CheckForLines();
                    enabled = false;
                    FindObjectOfType<TetraminoSpawner>().NewTetramino();
                }
                _previousTime = Time.time;
            }

        }
        private void CheckForLines()
        {
            for (int i = Height - 1; i >= 0; i--)
            {
                if (HasLine(i))
                {
                    DeleteLine(i);
                    RowDown(i);
                }
            }
        }
        private bool HasLine(int i)
        {
            for (int j = 0; j < Width; j++)
            {
                if (_grid[j, i] == null) return false;
            }
            return true;
        }
        private void DeleteLine(int i)
        {
            for (int j = 0; j < Width; j++)
            {
                _scoreManager.OnScoreAdd?.Invoke(1);
                Destroy(_grid[j, i].gameObject);
                _grid[j, i] = null;
            }
        }
        private void RowDown(int i)
        {
            for (int y = i; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (_grid[x, y] != null)
                    {
                        _grid[x, y - 1] = _grid[x, y];
                        _grid[x, y] = null;
                        _grid[x, y - 1].transform.position += Vector3.down;
                    }
                }
            }
        }
        private void AddToGrid()
        {
            foreach (Transform children in transform)
            {
                _loseChecker.CheckLose(this);
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);
                if (children.position.y < Height)
                {
                    _grid[roundedX, roundedY] = children;
                }
                
            }
        }
        private bool ValidMove()
        {
            foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);
                if (roundedX < 0 || roundedX >= Width || roundedY < 0 || roundedY >= Height)
                {
                    return false;
                }
                if (_grid[roundedX, roundedY] != null) return false;
            }
            return true;
        }
    }
}
