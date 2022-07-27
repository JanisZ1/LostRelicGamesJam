using UnityEngine;

namespace Assets.Level2.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    public class CrashSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private SnakeIntersectionChecker _intersectionChecker;
        public AudioSource AudioSource
        {
            get
            {
                return _audioSource;
            }
        }
        private void Start() =>
            _intersectionChecker.OnLose += PlaySound;

        private void PlaySound() =>
            _audioSource.Play();
    }
}

