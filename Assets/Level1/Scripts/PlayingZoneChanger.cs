using UnityEngine;

namespace Assets.Level1.Scripts
{
    public class PlayingZoneChanger : MonoBehaviour
    {
        [SerializeField] private PuzzleCompletion _puzzleCompletion;
        [SerializeField] private Camera _puzzleCamera;
        [SerializeField] private Camera _platformerCamera;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private PlatformerPlayerMove _playerMove;
        private void Start() =>
            _puzzleCompletion.OnPuzzleCompleted += ChangePlayZone;
        private void OnDisable() =>
           _puzzleCompletion.OnPuzzleCompleted -= ChangePlayZone;
        private void ChangePlayZone()
        {
            _puzzleCamera.enabled = false;
            _platformerCamera.enabled = true;
            _canvas.gameObject.SetActive(true);
            _playerMove.gameObject.SetActive(true);
        }
    }
}

