using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Level1.Scripts
{
    public class Piece : MonoBehaviour
    {
        private Vector3 _rightPosition;
        [SerializeField] private float _distanceToAttach = 0.3f;
        public bool IsInRightPosition { get; private set; }
        [SerializeField] private PuzzleCompletion _puzzleCompletion;
        private void Start()
        {
            _rightPosition = transform.position;
            transform.position = new Vector3(Random.Range(-29, -25), Random.Range(37, 45), 0);
        }
        public void CheckDistanceToRightPosition()
        {
            float distanceToRightPosition = Vector3.Distance(_rightPosition, transform.position);
            Debug.Log(distanceToRightPosition);
            if (distanceToRightPosition < _distanceToAttach)
            {
                IsInRightPosition = true;
            }
        }
        public void GetToRightPosition()
        {
            if (IsInRightPosition)
            {
                GetComponent<Collider2D>().enabled = false;
                transform.position = _rightPosition;
                _puzzleCompletion.UpdatePuzzleCompletion();
            }
        }
    }
}

