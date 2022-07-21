using UnityEngine;

namespace Assets.Level4.Scripts
{
    public class CameraRotate : MonoBehaviour
    {
        [SerializeField] private Transform _rotationPoint;
        [SerializeField] private PlayerRotate _playerRotate;

        [SerializeField] private float _speed;
    }
}