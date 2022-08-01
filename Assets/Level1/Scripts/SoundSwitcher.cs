using UnityEngine;

namespace Assets.Level1.Scripts
{
    public class SoundSwitcher : MonoBehaviour
    {
        [SerializeField] private AudioSource _puzzleSound;
        [SerializeField] private AudioSource _platformerSound;
        [SerializeField] private PuzzleCompletion _puzzleCompletion;
        private const string _saveLoadKey = "OpenedLevels";
        private void Start()
        {
            _puzzleCompletion.OnPuzzleCompleted += SwitchSoundOnPuzzleCompleted;

            if (!PlayerPrefs.HasKey(_saveLoadKey))
                _puzzleSound.Play();
            else
                _platformerSound.Play();
        }

        private void OnEnable() => 
            _puzzleCompletion.OnPuzzleCompleted += SwitchSoundOnPuzzleCompleted;

        private void OnDisable() => 
            _puzzleCompletion.OnPuzzleCompleted -= SwitchSoundOnPuzzleCompleted;

        private void SwitchSoundOnPuzzleCompleted()
        {
            _puzzleSound.Stop();
            _platformerSound.Play();
        }
    }
}