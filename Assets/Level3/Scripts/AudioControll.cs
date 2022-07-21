using UnityEngine;

namespace Assets.Level3.Scripts
{
    public class AudioControll : MonoBehaviour
    {
        private AudioSource audioSource;
        void Start() => 
            audioSource = GetComponent<AudioSource>();
    }
}
