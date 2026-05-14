using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private bool _isJumping = false;    

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
}