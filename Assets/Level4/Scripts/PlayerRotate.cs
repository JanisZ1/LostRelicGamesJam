using UnityEngine;

namespace Assets.Level4.Scripts
{
    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private float _mouseX;
        private float _mouseY;
        private Camera _camera;
        [SerializeField] private LayerMask _whatpassesThroughCamera;
        private void Start() => 
            _camera = Camera.main;
        private void Update()
        {
            _mouseX += _speed * Input.GetAxis("Mouse X");
            Vector3 playerRotation = new Vector3(0, _mouseX, 0);
            transform.eulerAngles = playerRotation;

            _mouseY -= _speed * Input.GetAxis("Mouse Y");
            _mouseY = Mathf.Clamp(_mouseY, -30, 30);
            _camera.transform.eulerAngles = new Vector3(_mouseY, _mouseX, 0);
        }
    }
}