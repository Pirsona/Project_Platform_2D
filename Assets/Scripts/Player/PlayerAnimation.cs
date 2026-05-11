using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private const string IsJumping = nameof(IsJumping);

    private Animator _animator;

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
        _animator.SetBool(PlayerAnimatorData.Params.IsJumping, !IsGrounded);
    }
}
