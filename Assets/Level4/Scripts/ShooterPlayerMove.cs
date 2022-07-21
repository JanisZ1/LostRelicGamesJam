using UnityEngine;

namespace Assets.Level4.Scripts
{
    public class ShooterPlayerMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpSpeed;
        public int _numberOfJumps;
        public bool _isGrounded;
        public bool DoubleJumpEnabled;
        private void Start() =>
            Cursor.lockState = CursorLockMode.Locked;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _numberOfJumps++;
                DoJump();
            }
            if (Input.GetKeyDown(KeyCode.Space) && !_isGrounded)
            {
                _numberOfJumps++;
                DoJump();
            }
        }

        public void DoJump()
        {
            if (!DoubleJumpEnabled && _numberOfJumps == 1)
            {
                Debug.Log("First Jump");
                _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode.Impulse);
            }

            if (DoubleJumpEnabled && _numberOfJumps < 3)
            {
                Debug.Log("Second Jump");
                _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode.Impulse);
            }
        }
        private void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            _rigidbody.velocity = transform.right * _moveSpeed * horizontalInput + transform.forward * _moveSpeed * verticalInput;
        }

        private void OnCollisionExit() =>
            _isGrounded = false;

        private void OnCollisionEnter(Collision collision) => 
            CheckNormalSurface(collision);

        private void OnCollisionStay(Collision collision) =>
            CheckNormalSurface(collision);
        private void CheckNormalSurface(Collision collision)
        {
            Vector2 normal = collision.contacts[0].normal;
            if (Vector2.Angle(Vector2.up, normal) > 65f)
                _isGrounded = false;
            else
                _isGrounded = true;
        }
    }
}