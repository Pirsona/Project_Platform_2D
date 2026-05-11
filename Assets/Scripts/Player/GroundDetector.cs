using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private GameObject _leg;
    [SerializeField] private float _slopeRayLength;

    public bool IsGrounded => CheckIsGround();

    private bool CheckIsGround()
    {
        float rayDistance = _slopeRayLength;

        RaycastHit2D hit = Physics2D.Raycast(_leg.transform.position, Vector2.down, rayDistance);

        return hit.collider != null;
    }
}
