using UnityEngine;

namespace Assets.Level1.Scripts
{
    public class PuzzleMove : MonoBehaviour
    {
        [SerializeField] private Camera _puzzleCamera;
        private Piece _takenPiece;
        private bool _pieceIsTaken;
        private void Update()
        {
            Vector3 startRay = _puzzleCamera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButton(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(startRay, Vector2.zero);
                if (!_pieceIsTaken)
                {
                    if (hit.collider != null)
                    {
                        _takenPiece = hit.collider.GetComponent<Piece>();
                        if (_takenPiece)
                        {
                            _pieceIsTaken = true;
                            _takenPiece.GetComponent<SpriteRenderer>().sortingOrder++;
                        }

                    }
                }
            }
            if (_pieceIsTaken)
            {
                Vector3 positionToMove = _puzzleCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                _takenPiece.transform.position = positionToMove;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (_takenPiece != null)
                {
                    //_takenPiece.GetComponent<SpriteRenderer>().sortingOrder--;
                    if (_takenPiece.GetComponent<Collider2D>().enabled)
                    {
                        _takenPiece.CheckDistanceToRightPosition();
                        _takenPiece.GetToRightPosition();
                    }
                }
                _pieceIsTaken = false;

            }

        }

    }
}

