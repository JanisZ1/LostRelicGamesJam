using UnityEngine;
using System.Collections.Generic;
using System.Collections;

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
           StartCoroutine(EatEffect(snakeheadPosition));
        private IEnumerator EatEffect(Vector3Int snakeheadPosition)
        {
            ParticleSystem newParticles = Instantiate(_particleSystem, snakeheadPosition, Quaternion.identity);
            newParticles.Play();
            yield return new WaitWhile(() => newParticles.isPlaying);
            Destroy(newParticles.gameObject);
        }
    }
}