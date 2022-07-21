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

        private void Start() => 
            _scoreManager = FindObjectOfType<ScoreManager>();
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position += Vector3.left;
                if (!ValidMove())
                    transform.position -= Vector3.left;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += Vector3.right;
                if (!ValidMove())
                    transform.position -= Vector3.right;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.Rotate(0, 0, 90f);
                if (!ValidMove())
                    transform.Rotate(0, 0, -90f);
            }
            if (Time.time - _previousTime > (Input.GetKey(KeyCode.S) ? _fallTime / 10 : _fallTime))
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
                        _grid[x, y - 1].transform.position -= Vector3.up;
                    }
                }
            }
        }
        private void AddToGrid()
        {
            foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);
                _grid[roundedX, roundedY] = children;
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