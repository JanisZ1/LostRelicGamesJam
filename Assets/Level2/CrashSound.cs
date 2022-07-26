using UnityEngine;

namespace Assets.Level2.Scripts
{
    public class CrashSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _crashSound;
        [SerializeField] private SnakeIntersectionChecker _intersectionChecker;
        private void Start() =>
            _intersectionChecker.OnLose += PlaySound;

        private void PlaySound() =>
            _crashSound.Play();
    }
}

