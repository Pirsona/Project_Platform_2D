using UnityEngine;

public class EnemySearch : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _radiusDetected;

    public Transform TargetPosition {  get; private set; }

    private void FixedUpdate()
    {
        TargetSearch();
    }

    private void TargetSearch()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _radiusDetected, _targetLayer);

        TargetPosition = hit?.transform;
    }
}
