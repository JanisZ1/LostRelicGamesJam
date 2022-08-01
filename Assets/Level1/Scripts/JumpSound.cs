using UnityEngine;

namespace Assets.Level1.Scripts
{
    public class JumpSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _jumpSound;
        [SerializeField] private PlatformerPlayerMove _playerMove;
        private void Start() => _playerMove.OnJump += PlaySound;
        private void OnEnable() =>
            _playerMove.OnJump += PlaySound;
        private void OnDisable() =>
            _playerMove.OnJump -= PlaySound;
        private void PlaySound() =>
            _jumpSound.Play();
    }
}
