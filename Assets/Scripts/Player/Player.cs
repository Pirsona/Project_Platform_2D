using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerInput _input;
    [SerializeField] PlayerMover _mover;
    [SerializeField] PlayerAnimation _animation;
    [SerializeField] GroundDetector _detector;

    public float HorizontalInput => _input.HorizontalInput;
    public bool IsJumping => _input.IsJumping;
    public bool IsGrounded => _detector.IsGrounded;

    private void Update()
    {
        _mover.Move(HorizontalInput);

        if (IsJumping && IsGrounded)
        {
            _mover.Jump();
        }

        _animation.UpdateVisuals(HorizontalInput, IsGrounded);
    }
}
