using UnityEngine;

namespace Assets.Level1.Scripts
{
    public class DoubleJumpTrigger : MonoBehaviour
    {
        [SerializeField] private CanvasShow _canvasShow;
        private const int _showTime = 3;
        private void OnTriggerEnter2D(Collider2D collider)
        {
            PlatformerPlayerMove playerMove;
            if (collider.TryGetComponent(out playerMove))
                playerMove.EnableDoubleJump();

            _canvasShow.ShowDoubleJump(_showTime);
            gameObject.SetActive(false);
        }
    }
}
