using UnityEngine;

namespace Assets.Level1.Scripts
{
    [RequireComponent(typeof(CollisionChecker))]
    public class PlatformerPlayerMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private int _maxNumberOfJumps;
        private int _currentJumps;
        private CollisionChecker _collisionChecker;
        private void Awake() =>
            _collisionChecker = GetComponent<CollisionChecker>();
        private void Update() =>
            ChecKeyCode();
        private void ChecKeyCode()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                TryDoJump();
        }
        private void TryDoJump()
        {
            if (_currentJumps < _maxNumberOfJumps)
            {
                _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                _currentJumps++;
            }
        }
        private void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            _rigidbody.velocity = new Vector2(_moveSpeed * horizontalInput, _rigidbody.velocity.y);
        }
        public void CheckCurrentJumps()
        {
            if (_currentJumps == _maxNumberOfJumps && _collisionChecker.IsGrounded)
                _currentJumps = 0;
        }
        public void EnableDoubleJump() => 
            _maxNumberOfJumps = 2;
    }
}
