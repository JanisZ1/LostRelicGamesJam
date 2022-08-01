using System;
using UnityEngine;

namespace Assets.Level1.Scripts
{
    public class PuzzleCompletion : MonoBehaviour
    {
        private Piece[] _allPieces;
        [SerializeField] private int _currentPiecesCompleted;
        [SerializeField] private float _distanceToAttach = 0.3f;
        public Action OnPuzzleCompleted;
        private void Start() =>
            _allPieces = FindObjectsOfType<Piece>();
        public void CheckDistanceToRightPosition(Piece piece)
        {
            float distanceToRightPosition = Vector3.Distance(piece.RightPosition, piece.transform.position);
            Debug.Log(distanceToRightPosition);
            if (distanceToRightPosition < _distanceToAttach)
            {
                GetToRightPosition(piece);
                piece.ResetSortingOrder();
            }
        }
        private void GetToRightPosition(Piece piece)
        {
            piece.BoxCollider.enabled = false;
            piece.transform.position = piece.RightPosition;
            UpdatePuzzleCompletion();
        }
        private void UpdatePuzzleCompletion()
        {
            _currentPiecesCompleted++;
            if (_allPieces.Length == _currentPiecesCompleted)
            {
                OnPuzzleCompleted?.Invoke();
            }
        }
    }
}

