using UnityEngine;

namespace Assets.Level1.Scripts
{
    public class DoubleJumpTrigger : MonoBehaviour
    {
        [SerializeField] private CanvasShow _canvasShow;
        private const int _showPeriod = 3;
        private void OnTriggerEnter2D(Collider2D collider)
        {
            _canvasShow.ShowDoubleJump(_showPeriod);
            gameObject.SetActive(false);
        }
    }
}
