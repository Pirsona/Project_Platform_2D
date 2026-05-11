using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerRotate _rotate;
    [SerializeField] private PlayerAnimation _animation;
    [SerializeField] private GroundDetector _detector;

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

        _rotate.Rotate(HorizontalInput);
        _animation.SetSpeed(HorizontalInput);
        _animation.SetJump(IsGrounded);
    }
}
