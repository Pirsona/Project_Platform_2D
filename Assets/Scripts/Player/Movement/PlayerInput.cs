using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private KeyCode _jumpButton = KeyCode.W;
    private KeyCode _attackButton = KeyCode.Mouse0;
    private KeyCode _abilityButton = KeyCode.E;
    private float _horizontalInput;
    private bool _isJumping;
    private bool _isAttacking;
    private bool _isAbilityApplying;

    public float HorizontalInput => _horizontalInput;
    public bool IsJumping => _isJumping;
    public bool IsAttacking => _isAttacking;
    public bool IsAbilityApplying => _isAbilityApplying;

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
        if(Input.GetKeyDown(_abilityButton))
        {
            _isAbilityApplying = true;
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

    public void ConsumeAbility()
    {
        _isAbilityApplying = false;
    }
}
