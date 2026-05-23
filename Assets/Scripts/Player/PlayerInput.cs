using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private KeyCode _jumpButton = KeyCode.Space;
    private KeyCode _attackButton = KeyCode.Mouse0;
    private float _horizontalInput;
    private bool _isJumping;
    private bool _isAttacking;

    public float HorizontalInput => _horizontalInput;
    public bool IsJumping => _isJumping;
    public bool IsAttacking => _isAttacking;

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        _horizontalInput = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(_jumpButton))
        {
            _isJumping = true;
        }

        if(Input.GetKeyDown(_attackButton))
        {
            _isAttacking = true;
        }
    }

    public void ConsumeJump()
    {
        _isJumping = false;
    }

    public void ConsumeAttack()
    {
        _isAttacking = false;
    }
}
