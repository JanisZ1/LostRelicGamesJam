using System;
using System.Collections;
using UnityEngine;

namespace Assets.Level4.Scripts
{
    public class Blink : MonoBehaviour
    {
        [SerializeField] EnemyHealth _enemyHealth;
        [SerializeField] private Renderer[] _renderers;
        private void Start() => 
            _enemyHealth.OnHealthChange += StartBlink;
        private void OnDisable() =>
            _enemyHealth.OnHealthChange -= StartBlink;
        private void StartBlink(int health, int maxHealth) =>
            StartCoroutine(BlinkEffect());

        private IEnumerator BlinkEffect()
        {          
            for (float t = 0; t < 1; t += Time.deltaTime)
            {
                for (int i = 0; i < _renderers.Length; i++)
                {
                    for (int m = 0; m < _renderers[i].materials.Length; m++)
                    {
                        _renderers[i].materials[m].SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));
                    }
                }
                yield return null;

            }
            
        }
    }
}