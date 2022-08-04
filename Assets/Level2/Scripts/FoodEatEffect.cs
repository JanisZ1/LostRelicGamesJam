using UnityEngine;
using System.Collections.Generic;

namespace Assets.Level2.Scripts
{
    public class FoodEatEffect : MonoBehaviour
    {
        [SerializeField] private SnakeIntersectionChecker _intersectionChecker;
        [SerializeField] private ParticleSystem _particleSystem;
        private void Start() =>
            _intersectionChecker.OnFoodEat += PlayEffect;
        private void OnDisable() =>
            _intersectionChecker.OnFoodEat -= PlayEffect;
        private void PlayEffect(Vector3Int snakeheadPosition, List<Vector3Int> collection) =>
            _particleSystem.Play();
    }
}