using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void UpdateVisuals(float horizontalInput, bool isGrounded)
    {
        _animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        _animator.SetBool("IsJumping", !isGrounded);

        if (horizontalInput > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
