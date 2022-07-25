using UnityEngine;

namespace Assets.Level1.Scripts
{
    public class StartingObjectsChanger : MonoBehaviour
    {
        [SerializeField] private PlatformerPlayerMove _playerMove;
        [SerializeField] private Camera _puzzleCamera;
        [SerializeField] private Camera _platformerCamera;
        private void Start()
        {
            _puzzleCamera.enabled = true;
            _platformerCamera.enabled = false;
            _playerMove.gameObject.SetActive(false);
        }

    }
}

