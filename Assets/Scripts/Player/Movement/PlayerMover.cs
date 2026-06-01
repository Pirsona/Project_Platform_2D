using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _physicsBody;
    private Vector2 _direction;

    private void Start()
    {
        _direction = Vector2.zero;
        _physicsBody = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalInput)
    {
        _direction.x = horizontalInput * _speed;

        _physicsBody.velocity = new Vector2(_direction.x, _physicsBody.velocity.y);
    }

    public void Jump()
    {
        _physicsBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
