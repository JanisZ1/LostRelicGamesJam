using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class DamageScreen : MonoBehaviour
{
    [SerializeField] private Image _image;
    public void ScreenEffect()
    {
        StartCoroutine(TakeDamageEffect());
    }
    private IEnumerator TakeDamageEffect()
    {
        _image.enabled = true;
        for (float i = 0; i < 0.5; i += Time.deltaTime)
        {
            yield return new WaitForEndOfFrame();
            _image.color = new Color(i, 0, 0, 0.5f);
        }
        _image.enabled = false;
    }
}
