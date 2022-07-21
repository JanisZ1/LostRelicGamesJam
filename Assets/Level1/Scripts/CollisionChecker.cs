using UnityEngine;

namespace Assets.Level1.Scripts
{
    public class CollisionChecker : MonoBehaviour
    {
        public bool IsGrounded { get; private set; }
        private PlatformerPlayerMove _platformerPlayerMove;
        private void Awake() =>
            _platformerPlayerMove = GetComponent<PlatformerPlayerMove>();
        private void CheckNormalSurface(Collision2D collision)
        {
            Vector2 normal = collision.contacts[0].normal;
            IsGrounded = Vector2.Angle(Vector2.up, normal) < 65f;
            _platformerPlayerMove.CheckCurrentJumps();
        }
        private void OnCollisionExit2D() =>
            IsGrounded = false;
        private void OnCollisionEnter2D(Collision2D collision) =>
            CheckNormalSurface(collision);
    }
}
