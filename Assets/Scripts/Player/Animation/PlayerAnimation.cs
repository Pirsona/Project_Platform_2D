using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private bool _isJumping = false;
    private bool _isCharging = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float horizontalInput)
    {
        _animator.SetFloat(PlayerAnimatorData.Params.Speed, Mathf.Abs(horizontalInput));
    }

    public void SetJump(bool IsGrounded)
    {
        if(_isJumping != IsGrounded)
        {
            _animator.SetBool(PlayerAnimatorData.Params.IsJumping, !IsGrounded);
            _isJumping = IsGrounded;
        }
    }

    public void SetAttack(bool IsAttack)
    {
        if(_isCharging != IsAttack)
        {
            _animator.SetBool(PlayerAnimatorData.Params.IsAttacking, IsAttack);
            _isCharging = IsAttack;
        }
    }
}