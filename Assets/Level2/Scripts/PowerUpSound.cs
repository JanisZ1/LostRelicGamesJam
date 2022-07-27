using System.Collections.Generic;
using UnityEngine;

namespace Assets.Level2.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    public class PowerUpSound : MonoBehaviour
    {
        [SerializeField] private SnakeIntersectionChecker _intersectionChecker;
        [SerializeField] private AudioSource _audioSource;
        private void Start() =>
            _intersectionChecker.OnFoodEat += PlaySound;

        private void PlaySound(Vector3Int snakeHead, List<Vector3Int> foodCollection) =>
            _audioSource.Play();
    }
}

