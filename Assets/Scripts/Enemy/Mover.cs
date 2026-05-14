using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

   public void TravelToTarget( Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
