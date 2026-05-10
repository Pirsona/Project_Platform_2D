using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]
[RequireComponent (typeof (SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _leg;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _slopeRayLength;

    private const string Horizontal = "Horizontal";

    private Vector2 _direction;
    private float _horizontalInput;
    private bool _isGrounded;
    private Rigidbody2D _physicsBody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _direction = Vector2.zero;
        _physicsBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _horizontalInput = Input.GetAxis(Horizontal);
        _direction.x = _horizontalInput * _speed;
        _isGrounded = IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _physicsBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

        }

        _physicsBody.velocity = new Vector2(_direction.x, _physicsBody.velocity.y);

        UpdateVisuals();
    }   

    private bool IsGrounded()
    {
        float rayDistance = _slopeRayLength;

        RaycastHit2D hit = Physics2D.Raycast(_leg.transform.position, Vector2.down, rayDistance);

        return hit.collider != null;
    }

    private void UpdateVisuals()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_horizontalInput));
        _animator.SetBool("IsJumping", !_isGrounded);

        if (_horizontalInput > 0)
        {
            _spriteRenderer.flipX = false;
        } 
        else if (_horizontalInput < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}