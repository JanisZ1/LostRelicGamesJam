using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Level4.Scripts
{
    public class DamageScreen : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private AudioSource _damageSound;
        public void ScreenEffect()
        {
            StartCoroutine(TakeDamageEffect());
        }
        private IEnumerator TakeDamageEffect()
        {
            _image.enabled = true;
            _damageSound.Play();
            for (float i = 0; i < 0.5; i += Time.deltaTime)
            {
                yield return new WaitForEndOfFrame();
                _image.color = new Color(i, 0, 0, 0.5f);
            }
            _image.enabled = false;
        }
    }
}

