using UnityEngine;

namespace Assets.Level1.Scripts
{
    public class PuzzleMove : MonoBehaviour
    {
        [SerializeField] private Camera _puzzleCamera;
        [SerializeField] private PuzzleCompletion _puzzleCompletion;
        private Piece _takenPiece;
        private bool _soundIsPlaying;
        [SerializeField] private AudioSource _puzzlePickSound;
        [SerializeField] private AudioSource _puzzlePutSound;
        private void Update()
        {
            Vector3 startRay = _puzzleCamera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButton(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(startRay, Vector2.zero);
                if (_takenPiece == null)
                {
                    if (hit.collider != null)
                    {
                        _takenPiece = hit.collider.GetComponent<Piece>();
                        _takenPiece.UpSortingOrder();
                        if (!_soundIsPlaying)
                        {
                            _puzzlePickSound.Play();
                            _soundIsPlaying = true;
                        }

                    }
                }
            }
            if (_takenPiece != null)
            {
                float distanceFromCamera = 10;
                Vector3 positionToMove = _puzzleCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera));
                _takenPiece.transform.position = positionToMove;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (_takenPiece != null)
                {
                    if (_takenPiece.GetComponent<Collider2D>().enabled)
                    {
                        _puzzleCompletion.CheckDistanceToRightPosition(_takenPiece);
                    }
                    _takenPiece.DownSortingOrder();
                    _takenPiece = null;
                    if (_soundIsPlaying)
                    {
                        _puzzlePutSound.Play();
                        _soundIsPlaying = false;
                    }

                }

            }

        }
    }
}

