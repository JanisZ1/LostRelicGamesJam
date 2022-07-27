using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

namespace Assets.Level1.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SortingGroup))]
    public class Piece : MonoBehaviour
    {
        private Vector3 _rightPosition;
        [SerializeField] private float _distanceToAttach = 0.3f;
        [SerializeField] private PuzzleCompletion _puzzleCompletion;
        private SortingGroup _sortingGroup;
        private BoxCollider2D _boxCollider;
        private void Start()
        {
            _sortingGroup = GetComponent<SortingGroup>();
            _boxCollider = GetComponent<BoxCollider2D>();

            _rightPosition = transform.position;
            float minX = -29;
            float maxX = -25;
            float minY = 37;
            float maxY = 45;
            transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        }
        private void GetToRightPosition()
        {
            _boxCollider.enabled = false;
            transform.position = _rightPosition;
            _puzzleCompletion.UpdatePuzzleCompletion();
        }
        private void ResetSortingOrder() =>
            _sortingGroup.sortingOrder = 0;
        public void CheckDistanceToRightPosition()
        {
            float distanceToRightPosition = Vector3.Distance(_rightPosition, transform.position);
            Debug.Log(distanceToRightPosition);
            if (distanceToRightPosition < _distanceToAttach)
            {
                GetToRightPosition();
                ResetSortingOrder();
            }
        }
        public void UpSortingOrder() =>
            _sortingGroup.sortingOrder++;
        public void DownSortingOrder()
        {
            if (_sortingGroup.sortingOrder > 0)
                _sortingGroup.sortingOrder--;
        }
    }
}

