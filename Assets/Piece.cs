using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

namespace Assets.Level1.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SortingGroup))]
    public class Piece : MonoBehaviour
    {
        public Vector3 RightPosition { get; private set; }
        private SortingGroup _sortingGroup;  
        public BoxCollider2D BoxCollider { get; private set; }
        private void Start()
        {
            RightPosition = transform.position;
            _sortingGroup = GetComponent<SortingGroup>();
            BoxCollider = GetComponent<BoxCollider2D>();
            MoveToRandomPosition();
        }
        private void MoveToRandomPosition()
        {
            float minX = -29;
            float maxX = -25;
            float minY = 37;
            float maxY = 45;
            transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        }

        public void ResetSortingOrder() =>
            _sortingGroup.sortingOrder = 0;

        public void UpSortingOrder() =>
            _sortingGroup.sortingOrder++;
        public void DownSortingOrder()
        {
            if (_sortingGroup.sortingOrder > 0)
                _sortingGroup.sortingOrder--;
        }
    }
}

