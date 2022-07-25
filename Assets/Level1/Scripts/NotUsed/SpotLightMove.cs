using UnityEngine;

namespace Assets.Level1.NotUsedScripts
{
    public class SpotLightMove : MonoBehaviour
    {
        [SerializeField] private Transform _playerMove;
        private void Update() =>
            transform.position = new Vector3(_playerMove.position.x - 10, _playerMove.position.y + 6, _playerMove.position.z - 2);
    }

}
