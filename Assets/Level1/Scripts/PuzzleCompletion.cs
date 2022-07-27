using System;
using UnityEngine;

namespace Assets.Level1.Scripts
{
    public class PuzzleCompletion : MonoBehaviour
    {
        private Piece[] _allPieces;
        private int _currentPiecesCompleted;
        [SerializeField] private PuzzleMove _puzzleMove;
        public Action OnPuzzleCompleted;
        private void Start() =>
            _allPieces = FindObjectsOfType<Piece>();
        public void UpdatePuzzleCompletion()
        {
            _currentPiecesCompleted++;
            if (_allPieces.Length == _currentPiecesCompleted)
            {
                OnPuzzleCompleted?.Invoke();
                Debug.Log("Puzzle Completed");
            }
        }
    }
}

