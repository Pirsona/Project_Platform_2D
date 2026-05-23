using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private GameObject _leg;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float _slopeRayLength;

    public bool IsGrounded {get; private set;}

    private void FixedUpdate()
    {
       CheckIsGround();
    }
    private void CheckIsGround()
    {
        Collider2D hit = Physics2D.OverlapCircle(_leg.transform.position, _slopeRayLength, _layer);

        IsGrounded = hit != null;
    }
}
